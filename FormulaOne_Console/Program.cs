using FormulaOne_Dll;
using System;

namespace FormulaOne_Console
{
    class Program
    {
        static DbTools DbTools = new DbTools();

        static void Main(string[] args)
        {
            char scelta = ' ';
            do
            {
                Console.WriteLine("\n-----------------------------------");
                Console.WriteLine("*** FORMULA ONE - BATCH SCRIPTS ***");
                Console.WriteLine("-----------------------------------");
                Console.WriteLine("| 1 - Create Countries");
                Console.WriteLine("| 2 - Create Teams");
                Console.WriteLine("| 3 - Create Drivers");
                Console.WriteLine("| 4 - Create Circuits");
                Console.WriteLine("| 5 - Create Races");
                Console.WriteLine("------------------");
                Console.WriteLine("| B - Backup Database");
                Console.WriteLine("| R - Restore Database");
                Console.WriteLine("------------------");
                Console.WriteLine("| X - EXIT\n");
                scelta = Console.ReadKey(true).KeyChar;

                switch (scelta)
                {
                    case '1':
                        DbTools.ExecuteSqlScript("Countries");
                        break;
                    case '2':
                        DbTools.ExecuteSqlScript("Teams");
                        break;
                    case '3':
                        DbTools.ExecuteSqlScript("Drivers");
                        break;
                    case '4':
                        DbTools.ExecuteSqlScript("Circuits");
                        break;
                    case '5':
                        DbTools.ExecuteSqlScript("Races");
                        break;
                    case 'B':
                        DbTools.BackupDb();
                        break;
                    case 'R':
                        DbTools.RestoreDb();
                        break;
                    default:
                        if (scelta != 'X' && scelta != 'x') Console.WriteLine("\nUncorrect Choice - Try Again\n");
                        break;
                }
            } while (scelta != 'X' && scelta != 'x');
        }

        static bool callExecuteSqlScript(string scriptName)
        {
            try
            {
                DbTools.ExecuteSqlScript(scriptName + ".sql");
                Console.WriteLine("\nCreate " + scriptName + " - SUCCESS\n");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nCreate " + scriptName + " - ERROR: " + ex.Message + "\n");
                return false;
            }
        }
    }
}
