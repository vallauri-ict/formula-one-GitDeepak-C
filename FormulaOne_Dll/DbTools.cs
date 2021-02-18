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

        private Dictionary<int, Driver> drivers;
        private Dictionary<string, Country> countries;
        private Dictionary<int, Team> teams;
        private Dictionary<int, Circuit> circuits;
        private Dictionary<int, RacePoints> racesPoints;
        private Dictionary<int, Score> scores;
        private Dictionary<int, Race> races;

        public Dictionary<int, Driver> Drivers { get => drivers; set => drivers = value; }
        public Dictionary<string, Country> Countries { get => countries; set => countries = value; }
        public Dictionary<int, Team> Teams { get => teams; set => teams = value; }
        public Dictionary<int, Circuit> Circuits { get => circuits; set => circuits = value; }
        public Dictionary<int, RacePoints> RacesPoints { get => racesPoints; set => racesPoints = value; }
        public Dictionary<int, Score> Scores { get => scores; set => scores = value; }
        public Dictionary<int, Race> Races { get => races; set => races = value; }

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
                if (i != 1) Console.WriteLine(errore ? "Errori durante l'esecuzione delle query!!" : "Query eseguita correttamente!!");
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

        public void GetListCountry()
        {
            using (SqlConnection dbConn = new SqlConnection())
            {
                dbConn.ConnectionString = CONNECTION_STRING;
                dbConn.Open();
                string sql = "SELECT * FROM Countries;";
                SqlCommand cmd = new SqlCommand(sql, dbConn);

                SqlDataReader reader = cmd.ExecuteReader();
                this.Countries = new Dictionary<string, Country>();
                while (reader.Read())
                {
                    string countryCode = reader.GetString(0);
                    string countryName = reader.GetString(1);
                    Country c = new Country(countryCode, countryName);
                    this.Countries.Add(c.CountryCode, c);
                }
            }
        }

        public void GetListCircuits()
        {
            using (SqlConnection dbConn = new SqlConnection())
            {
                dbConn.ConnectionString = CONNECTION_STRING;
                dbConn.Open();
                string sql = "SELECT * FROM Circuits;";
                SqlCommand cmd = new SqlCommand(sql, dbConn);

                SqlDataReader reader = cmd.ExecuteReader();
                this.Circuits = new Dictionary<int, Circuit>();
                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string name = reader.GetString(1);
                    int length = reader.GetInt32(2);
                    int nLaps = reader.GetInt32(3);
                    string extCountry = reader.GetString(4);
                    string recordLap = reader.GetString(5);
                    string imgCircuit = reader.GetString(6);
                    Circuit c = new Circuit(id, name, length, nLaps, extCountry, recordLap, imgCircuit);
                    this.Circuits.Add(c.Id, c);
                }
            }
        }

        public void GetListRaces()
        {
            using (SqlConnection dbConn = new SqlConnection())
            {
                dbConn.ConnectionString = CONNECTION_STRING;
                dbConn.Open();
                string sql = "SELECT * FROM Races;";
                SqlCommand cmd = new SqlCommand(sql, dbConn);

                SqlDataReader reader = cmd.ExecuteReader();
                this.Races = new Dictionary<int, Race>();
                while (reader.Read())
                {
                    int idRace = reader.GetInt32(0);
                    string name = reader.GetString(1);
                    int extCircuit = reader.GetInt32(2);
                    DateTime data = reader.GetDateTime(3);
                    Race r = new Race(idRace, name, extCircuit, data);
                    this.Races.Add(r.IdRace, r);
                }
            }
        }

        public void GetListScores()
        {
            using (SqlConnection dbConn = new SqlConnection())
            {
                dbConn.ConnectionString = CONNECTION_STRING;
                dbConn.Open();
                string sql = "SELECT * FROM Scores;";
                SqlCommand cmd = new SqlCommand(sql, dbConn);

                SqlDataReader reader = cmd.ExecuteReader();
                this.Scores = new Dictionary<int, Score>();
                while (reader.Read())
                {
                    int pos = reader.GetInt32(0);
                    int points = reader.GetInt32(1);
                    int extDriver = reader.GetInt32(2);
                    int extTeam = reader.GetInt32(3);
                    Score s = new Score(pos, points, extDriver, extTeam);
                    this.Scores.Add(s.Pos, s);
                }
            }
        }

        public void GetListRacePoints()
        {
            using (SqlConnection dbConn = new SqlConnection())
            {
                dbConn.ConnectionString = CONNECTION_STRING;
                dbConn.Open();
                string sql = "SELECT * FROM RacesPoints;";
                SqlCommand cmd = new SqlCommand(sql, dbConn);

                SqlDataReader reader = cmd.ExecuteReader();
                this.RacesPoints = new Dictionary<int, RacePoints>();
                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    int extDriver = reader.GetInt32(1);
                    int extPos = reader.GetInt32(2);
                    int extRace = reader.GetInt32(3);
                    string fastestLap = reader.GetString(4);
                    RacePoints r = new RacePoints(id, extDriver, extPos, extRace, fastestLap);
                    this.RacesPoints.Add(r.Id, r);
                }
            }
        }

        public void GetListDrivers()
        {
            using (SqlConnection dbConn = new SqlConnection())
            {
                dbConn.ConnectionString = CONNECTION_STRING;
                dbConn.Open();
                string sql = "SELECT * FROM Drivers;";
                SqlCommand cmd = new SqlCommand(sql, dbConn);

                SqlDataReader reader = cmd.ExecuteReader();
                this.Drivers = new Dictionary<int, Driver>();
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
                    this.Drivers.Add(d.DriverNumber, d);
                }
            }
        }

        public void GetListTeam()
        {
            using (SqlConnection dbConn = new SqlConnection())
            {
                dbConn.ConnectionString = CONNECTION_STRING;
                dbConn.Open();
                string sql = "SELECT * FROM Teams;";
                SqlCommand cmd = new SqlCommand(sql, dbConn);

                SqlDataReader reader = cmd.ExecuteReader();
                this.Teams = new Dictionary<int, Team>();
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
                    this.Teams.Add(t.Id, t);
                }
            }
        }

    }
}
