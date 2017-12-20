using Syph.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

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

            File.Create(file);
        }

        public void WriteLog(string[] message)
        {
            //TODO
        }
    }
}
