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
                    string[] tableNames = { "Country", "Driver", "Team" };

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
