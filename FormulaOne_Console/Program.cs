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
            bool isConstraintPresent = false;
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
                Console.WriteLine("| 6 - Create Foreign Keys");
                Console.WriteLine("| 7 - Delete Foreign Keys");
                Console.WriteLine("------------------");
                Console.WriteLine("| A - Show Tables");
                Console.WriteLine("| B - Backup Database");
                Console.WriteLine("| R - Restore Database");
                Console.WriteLine("| D - Drop Table");
                Console.WriteLine("| C - Clear Database");
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
                        Console.WriteLine("Creating Races Table....");
                        DbTools.ExecuteSqlScript("Races");

                        Console.WriteLine("\nCreating RacesPoints Table....");
                        DbTools.ExecuteSqlScript("RacesPoints");

                        Console.WriteLine("\nCreating Scores Table....");
                        DbTools.ExecuteSqlScript("Scores");
                        break;
                    case '6':
                        if (DbTools.getTables().Count == 1)
                            Console.WriteLine("Cannot create foreign keys because the database is empty!!");
                        else
                        {
                            DbTools.ExecuteSqlScript("setConstraints");
                            if(!isConstraintPresent)
                                Console.WriteLine("Foreign Keys created!!");
                            isConstraintPresent = true;                            
                        }
                        break;
                    case '7':
                        if (DbTools.getTables().Count == 1)
                            Console.WriteLine("Database is empty!!");
                        else
                        {
                            if (isConstraintPresent)
                            {
                                DbTools.ExecuteSqlScript("deleteConstraints");
                                isConstraintPresent = false;
                                Console.WriteLine("Foreign Keys deleted!!");
                            }
                            else
                                Console.WriteLine("There aren't foreign keys to delete!!");
                        }
                        break;
                    case 'A':
                    case 'a':
                        if (DbTools.getTables().Count == 1)
                            Console.WriteLine("Database is empty!!");
                        else
                        {
                            Console.WriteLine("Tables present in db: ");
                            foreach (var item in DbTools.getTables())
                                if (!item.StartsWith("-"))
                                    Console.WriteLine("--" + item);
                        }
                        break;
                    case 'B':
                    case 'b':
                        DbTools.BackupDb();
                        break;
                    case 'R':
                    case 'r':
                        DbTools.RestoreDb();
                        break;
                    case 'D':
                    case 'd':
                        if (DbTools.getTables().Count == 1)
                            Console.WriteLine("You can't drop a table because the database is empty!!");
                        else
                        {
                            Console.WriteLine("Tables present in db: ");
                            foreach (var item in DbTools.getTables())
                                if (!item.StartsWith("-"))
                                    Console.WriteLine("--" + item);

                            Console.Write("\nInsert table name to drop: ");
                            string table = Console.ReadLine();
                            DbTools.DropTable(table);
                        }
                        break;
                    case 'C':
                    case 'c':
                        if (DbTools.getTables().Count == 1)
                            Console.WriteLine("You can't drop a table because the database is empty!!");
                        else
                        {
                            if (isConstraintPresent)
                            {
                                DbTools.ExecuteSqlScript("deleteConstraints");
                                isConstraintPresent = false;
                                DbTools.clearDb();
                            }
                            else
                                DbTools.clearDb();
                        }
                        break;
                    default:
                        if (scelta != 'X' && scelta != 'x') Console.WriteLine("\nUncorrect Choice - Try Again\n");
                        break;
                }
            } while (scelta != 'X' && scelta != 'x');
        }
    }
}
