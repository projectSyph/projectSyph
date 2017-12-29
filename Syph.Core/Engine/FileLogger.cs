using System;
using System.Collections.Generic;
using System.IO;
using Syph.Core.Contracts;

namespace Syph.Core.Engine
{
    public sealed class FileLogger : IFileLogger
    {
        private string fileName;
        private string file;
        private static IList<string> log = new List<string>();

        public FileLogger()
        {
            this.fileName = $"{DateTime.Now.ToString("ddMMyyyyHHmmss")}.txt";

            this.file = $@"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\projectSyph\logs\{this.fileName}";
        }

        public static void Log(string msg)
        {
            Console.WriteLine(msg);

            log.Add($"{msg}");
        }

        public void WriteLog()
        {
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
    }
}
