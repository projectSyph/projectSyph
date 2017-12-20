using Syph.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading;

namespace Syph.Core.Engine
{
    public class FileLogger : ILogger
    {
        private string fileName;
        private string file;

        public FileLogger()
        {
            this.fileName = $"{DateTime.Now.ToString("ddMMyyyyHHmmss")}.txt";

            this.file = $@"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\projectSyph\logs\{this.fileName}";
        }

        public void WriteLog(string[] log)
        {
            using (StreamWriter Writer = File.AppendText(file))
            {
                foreach (var line in log)
                {
                    Writer.WriteLine(line);
                }
            }
        }
    }
}
