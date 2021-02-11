using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace FormulaOne_Dll
{
    public class DbTools
    {
        public const string WORKINGPATH = @"C:\Data\";
        private const string CONNECTION_STRING = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + WORKINGPATH + @"FormulaOne.mdf;Integrated Security=True";

        public void ExecuteSqlScript(string sqlScriptName)
        {
            var fileContent = File.ReadAllText(WORKINGPATH + sqlScriptName + ".sql");
            fileContent = fileContent.Replace("\r\n", "");
            fileContent = fileContent.Replace("\r", "");
            fileContent = fileContent.Replace("\n", "");
            fileContent = fileContent.Replace("\t", "");
            var sqlqueries = fileContent.Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries);

            SqlConnection con = new SqlConnection(CONNECTION_STRING);            

            using (con)
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("query", con);
                int i = 0;
                bool errore = false;

                foreach (var query in sqlqueries)
                {
                    cmd.CommandText = query; i++;
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (SqlException err)
                    {
                        if (err.Number == 2714)
                        {
                            if (query.StartsWith("ALTER"))
                                Console.WriteLine("Foreign keys already exists!!");
                            else
                                Console.WriteLine("Table already exists!!");
                            break;
                        }
                        else
                        {
                            errore = true;
                            Console.WriteLine("Errore in esecuzione della query numero: " + i);
                            Console.WriteLine("\tErrore SQL: " + err.Number + " - " + err.Message);
                        }
                    }
                }
                if(i != 1) Console.WriteLine(errore ? "Errori durante l'esecuzione delle query!!" : "Query eseguita correttamente!!");
            }
            con.Close();
        }

        public void DropTable(string tableName)
        {
            var con = new SqlConnection(CONNECTION_STRING);
            var cmd = new SqlCommand("Drop Table " + tableName + ";", con);
            con.Open();
            bool errore = false;
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (SqlException err)
            {
                errore = true;
                Console.WriteLine("\tErrore SQL: " + err.Number + " - " + err.Message);
            }
            con.Close();

            Console.WriteLine(errore ? "\nErrori durante l'esecuzione delle query!!" : "\nTabella eliminata correttamente!!");
        }

        public void clearDb()
        {
            var con = new SqlConnection(CONNECTION_STRING);
            con.Open();

            List<string> tables = getTables();
            bool errore = false;
            foreach (string table in tables)
            {
                if (!table.StartsWith("-"))
                {
                    var cmd = new SqlCommand("Drop Table " + table + ";", con);
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (SqlException err)
                    {
                        errore = true;
                        Console.WriteLine("\tErrore SQL: " + err.Number + " - " + err.Message);
                    }
                }
            }
            con.Close();

            Console.WriteLine(errore ? "Errori durante l'esecuzione delle query!!" : "Database pulito correttamente!!");
        }

        public static void BackupDb()
        {
            try
            {
                using (SqlConnection dbConn = new SqlConnection())
                {
                    dbConn.ConnectionString = CONNECTION_STRING;
                    dbConn.Open();

                    using (SqlCommand multiuser_rollback_dbcomm = new SqlCommand())
                    {
                        multiuser_rollback_dbcomm.Connection = dbConn;
                        multiuser_rollback_dbcomm.CommandText = @"ALTER DATABASE [" + WORKINGPATH + "FormulaOne.mdf" + "] SET MULTI_USER WITH ROLLBACK IMMEDIATE";

                        multiuser_rollback_dbcomm.ExecuteNonQuery();
                    }
                    dbConn.Close();
                }

                SqlConnection.ClearAllPools();

                using (SqlConnection backupConn = new SqlConnection())
                {
                    backupConn.ConnectionString = CONNECTION_STRING;
                    backupConn.Open();

                    using (SqlCommand backupcomm = new SqlCommand())
                    {
                        backupcomm.Connection = backupConn;
                        backupcomm.CommandText = @"BACKUP DATABASE [" + WORKINGPATH + "FormulaOne.mdf" + "] TO DISK='" + WORKINGPATH + @"\prova.bak'";
                        backupcomm.ExecuteNonQuery();
                    }
                    backupConn.Close();
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void RestoreDb()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(CONNECTION_STRING))
                {
                    string sqlStmt = "";
                    List<string> tableNames = getTables();

                    foreach (string table in tableNames)
                    {
                        sqlStmt += "TRUNCATE TABLE " + table + ";";
                        sqlStmt += "SELECT * INTO " + table + "_bck FROM " + table + ";";
                    }
                    sqlStmt = string.Format("RESTORE database FormulaOne.mdf FROM disk='{0}'", WORKINGPATH + "FormulaOneBackup.mdf");
                    using (SqlCommand bu2 = new SqlCommand(sqlStmt, con))
                    {
                        con.Open();
                        bu2.ExecuteNonQuery();
                        con.Close();

                        Console.WriteLine("Backup Restored Sucessfully");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public static List<string> getTables()
        {
            DataTable retVal = new DataTable();
            SqlConnection con = new SqlConnection(CONNECTION_STRING);
            string sql = "SELECT * FROM INFORMATION_SCHEMA.TABLES";
            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(retVal);

            List<string> retLst = new List<string>();
            retLst.Add("--- Selezionare la tabella desiderata ---");
            foreach (DataRow item in retVal.Rows)
                retLst.Add(item["TABLE_NAME"].ToString());

            return retLst;
        }

        public static DataTable GetDaTa(string dbName)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter adapter;

            try
            {
                using (SqlConnection dbCon = new SqlConnection())
                {
                    dbCon.ConnectionString = CONNECTION_STRING;
                    dbCon.Open();

                    string sql = "SELECT * FROM " + dbName;
                    SqlCommand command = new SqlCommand(sql, dbCon);
                    adapter = new SqlDataAdapter(command);
                    adapter.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
            return dt;
        }

        public List<Country> GetListCountry()
        {
            List<Country> retVal = new List<Country>();
            using (SqlConnection dbConn = new SqlConnection())
            {
                dbConn.ConnectionString = CONNECTION_STRING;
                dbConn.Open();
                string sql = "SELECT * FROM Countries;";
                SqlCommand cmd = new SqlCommand(sql, dbConn);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string countryCode = reader.GetString(0);
                    string countryName = reader.GetString(1);
                    Country c = new Country(countryCode, countryName);
                    retVal.Add(c);
                }
            }
            return retVal;
        }

        public List<Driver> GetListDriver()
        {
            List<Driver> retVal = new List<Driver>();
            using (SqlConnection dbConn = new SqlConnection())
            {
                dbConn.ConnectionString = CONNECTION_STRING;
                dbConn.Open();
                string sql = "SELECT * FROM Drivers;";
                SqlCommand cmd = new SqlCommand(sql, dbConn);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int driverNumber = reader.GetInt32(0);
                    string firstName = reader.GetString(1);
                    string lastName = reader.GetString(2);
                    DateTime dob = reader.GetDateTime(3);
                    string placeOfBirth = reader.GetString(4);
                    string extCountry = reader.GetString(5);
                    string biography = reader.GetString(6);
                    string imgDriver = reader.GetString(7);
                    int podiums = reader.GetInt32(8);
                    int totalPoints = reader.GetInt32(9);
                    int grandPrix = reader.GetInt32(10);
                    int worldChampionships = reader.GetInt32(11);
                    string highestRaceFinish = reader.GetString(12);
                    int highestGridFinish = reader.GetInt32(13);
                    Driver d = new Driver(driverNumber, firstName, lastName, dob, placeOfBirth, extCountry, biography, imgDriver, podiums, totalPoints, grandPrix, worldChampionships, highestRaceFinish, highestGridFinish);
                    retVal.Add(d);
                }
            }
            return retVal;
        }

        public List<Team> GetListTeam()
        {
            List<Team> retVal = new List<Team>();
            using (SqlConnection dbConn = new SqlConnection())
            {
                dbConn.ConnectionString = CONNECTION_STRING;
                dbConn.Open();
                string sql = "SELECT * FROM Teams;";
                SqlCommand cmd = new SqlCommand(sql, dbConn);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int teamId = reader.GetInt32(0);
                    string teamName = reader.GetString(1);
                    string fullTeamName = reader.GetString(2);
                    string teamBase = reader.GetString(3);
                    string extCountry = reader.GetString(4);
                    string teamChief = reader.GetString(5);
                    string techCheif = reader.GetString(6);
                    string powerUint = reader.GetString(7);
                    string chassis = reader.GetString(8);
                    int firstTeamEntry = reader.GetInt32(9);
                    int worldCham = reader.GetInt32(10);
                    int extFirstDriver = reader.GetInt32(11);
                    int extSecondDriver = reader.GetInt32(12);
                    string imgLogo = reader.GetString(13);
                    string imgCar = reader.GetString(14);
                    Team t = new Team(teamId, teamName, fullTeamName, teamBase, extCountry, teamChief, techCheif, powerUint, chassis, firstTeamEntry, worldCham, extFirstDriver, extSecondDriver, imgLogo, imgCar);
                    retVal.Add(t);
                }
            }
            return retVal;
        }

        public static List<string> GetDrivers()
        {
            List<string> retVal = new List<string>();
            using (SqlConnection dbCon = new SqlConnection())
            {
                dbCon.ConnectionString = CONNECTION_STRING;
                Console.WriteLine("\nQuery data example:");
                Console.WriteLine("==========================================\n");
                string sql = "SELECT * FROM Drivers";
                using (SqlCommand command = new SqlCommand(sql, dbCon))
                {
                    dbCon.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int number = reader.GetInt32(0);
                            string name = reader.GetString(1);
                            Console.WriteLine("(0) (1)", number, name);
                            retVal.Add(number + " - " + name);
                        }
                    }
                }
            }
            return retVal;
        }

        public static List<string> GetTeams()
        {
            List<string> retVal = new List<string>();
            using (SqlConnection dbCon = new SqlConnection())
            {
                dbCon.ConnectionString = CONNECTION_STRING;
                Console.WriteLine("\nQuery data example:");
                Console.WriteLine("==========================================\n");
                string sql = "SELECT * FROM Teams";
                using (SqlCommand command = new SqlCommand(sql, dbCon))
                {
                    dbCon.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32(0);
                            string name = reader.GetString(1);
                            Console.WriteLine("(0) (1)", id, name);
                            retVal.Add(id + " - " + name);
                        }
                    }
                }
            }
            return retVal;
        }

    }
}
