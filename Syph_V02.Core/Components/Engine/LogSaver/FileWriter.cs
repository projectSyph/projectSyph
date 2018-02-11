using Syph_V02.Core.Components.Engine.LogSaver.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syph_V02.Core.Components.Engine.LogSaver
{
    public class FileWriter : IFileRenderer
    {
        public void WriteToFile(IEnumerable<string> info)
        {
            string fileName = $"{DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss")}.txt";

            string file = $@"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\projectSyph\logs\{fileName}";

            if (!Directory.Exists($@"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\projectSyph\logs\"))
            {
                Directory.CreateDirectory($@"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\projectSyph\logs\");
            }

            using (StreamWriter Writer = File.AppendText(file))
            {               
                foreach (string line in info)
                {
                    Writer.WriteLine(line);
                }
            }
        }
    }
}
