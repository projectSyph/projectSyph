using Syph.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading;

namespace Syph.Core.Engine
{
    public sealed class FileLogger : IFileLogger
    {
        private string fileName;
        private string file;
        private IList<string> log;

        public FileLogger()
        {
            this.fileName = $"{DateTime.Now.ToString("ddMMyyyyHHmmss")}.txt";

            this.file = $@"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\projectSyph\logs\{this.fileName}";

            this.log = new List<string>();
        }

        public void Log(string msg)
        {
            Console.WriteLine(msg);
            this.log.Add($"{DateTime.Now.ToString("HH:mm:ss")} : {msg}");
        }

        public void WriteLog()
        {
            if (!Directory.Exists($@"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\projectSyph\logs\"))
            {
                Directory.CreateDirectory($@"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\projectSyph\logs\");
            }

            using (StreamWriter Writer = File.AppendText(file))
            {
                foreach (string line in this.log)
                {
                    Writer.WriteLine(line);
                }
            }
        }
    }
}
