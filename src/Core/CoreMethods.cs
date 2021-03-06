using System;
using Microsoft.Data.Sqlite;

namespace My_Contac_Manager_Min.Core
{
    static class CoreMethods
    {
        //Help Method For Interduction Methods
        public static void Help()
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            System.Console.WriteLine("Welcome To Help Method\n" +
            "1- -help \t\t\tHelp\n" +
            "2- -about \t\t\tAbout Programmer\n" +
            "3- -add <firstname> < lastname > < phone > \t\t\tFor Create Contact\n" +
            "4- -edit <phone> <firstname> <lastname> \t\t\tFor Update Contact\n" +
            "5- -remove <phone> \t\t\t For Delete Contact\n" +
            "6- -show \t\t\tFor Show All Contacts\n" +
            "7- -search <type> <value> \t\t\t For Search Contact\n" +
            "8- -example <command> \t\t\tFor Show Target Command Example \n" +
            "9- -quit \t\t\tFor Quit\n" +
            "** Phone Number Is Basic ID For Validate Contact You aren't Change This **");
            Console.ResetColor();
            ChoiseMethod();
        }
        public static void Quit()
        {
            System.Console.WriteLine("Bye");
            Environment.Exit(0);
        }
        //About Method For Interduction Me
        public static void About()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            System.Console.WriteLine("Im Amir Ali Shokri This Is My Git Hub Profile https://github.com/AmirAliShokri");
            Console.ResetColor();
            ChoiseMethod();
        }
        //Choise Method For Connect The Command To Methods
        public static void ChoiseMethod()
        {
            System.Console.WriteLine("Enter Method If You Don't Have Any Opinion Write '-help' ");
            string[] com = Console.ReadLine().Split(' ');
            var conn = new SqliteConnection("Data Source=../../../src.db");
            QueryMethods qm = new QueryMethods(conn);
            CRUDMethods cRUDMethods = new CRUDMethods(conn);
            switch (com[0])
            {
                case "-help":
                    Help();
                    break;
                case "-about":
                    About();
                    break;
                case "-add":
                    cRUDMethods.Create(com);
                    break;
                case "-quit":
                    Quit();
                    break;
                case "-edit":
                    cRUDMethods.Edit(com);
                    break;
                case "-remove":
                    cRUDMethods.Remove(com);
                    break;
                case "-show":
                    qm.Show();
                    break;
                case "-search":
                    qm.Search(com);
                    break;
                case "-example":
                    Example(com);
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    System.Console.WriteLine("Thats Not a Command ...");
                    Console.ResetColor();
                    break;
            }
            conn.Close();
            ChoiseMethod();
        }
        //Program Start Method
        public static void Start()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Welcome To My Contact Manager V 1.0\nFor More Informtion Of Me Write '-about'\nFor Help And Interduction Methods Write '-help' ");
            Console.ResetColor();
            ChoiseMethod();
        }

        public static void Example(string[] com)
        {
            switch (com[1])
            {
                case "-add":
                    System.Console.WriteLine("-add AmirAli Shokri 1234567890");
                    break;
                case "-edit":
                    System.Console.WriteLine("-edit 1234567890 Amir Shokri");
                    break;
                case "-remove":
                    System.Console.WriteLine("-remove 1234567890");
                    break;
                case "-search":
                    System.Console.WriteLine("-search firstname Ali");
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    System.Console.WriteLine("I Cant Found This Method");
                    Console.ResetColor();
                    break;
            }
            ChoiseMethod();
        }
    }
}
