using System;
using System.Collections.Generic;
using System.IO;
using Syph.Core.Contracts;

namespace Syph.Core.Engine
{
    public static class FileLogger
    {
        private static IList<string> log = new List<string>();

        public static void Log(string msg)
        {
            Console.WriteLine(msg);

            log.Add($"{msg}");
        }

        public static void Clear()
        {
            log.Clear();
        }

        public static void WriteLog()
        {
            string fileName = $"{DateTime.Now.ToString("ddMMyyyyHHmmss")}.txt";

            string file = $@"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\projectSyph\logs\{fileName}";

            if (!Directory.Exists($@"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\projectSyph\logs\"))
            {
                Directory.CreateDirectory($@"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\projectSyph\logs\");
            }

            using (StreamWriter Writer = File.AppendText(file))
            {
                foreach (string line in log)
                {
                    Writer.WriteLine(line);
                }
            }
        }

        public static void ConfirmWriteLog()
        {
            while (true)
            {
                ConsoleLogger.Print($"{Environment.NewLine}Write Log to file? (Yes/No): ");
                string choice = Console.ReadLine().ToLower();

                switch (choice)
                {
                    case "yes":
                    case "y":
                        FileLogger.WriteLog();
                        Console.Clear();
                        return;

                    case "no":
                    case "n":
                        FileLogger.Clear();
                        Console.Clear();
                        return;

                    default:
                        ConsoleLogger.Print("Invalid choice. Try again!");
                        break;
                }
            }
        }
    }
}
