using Syph_V02.Core.AppConfigurations.Constants;
using Syph_V02.Core.Components.Engine.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syph_V02.Core.Components.Engine.ConsoleClient
{
    public class ConsoleVisualizer : IVisualizer
    {
        private IOConsoleSettings ioSettings;

        public ConsoleVisualizer(IOConsoleSettings ioSettings)
        {
            this.ioSettings = ioSettings;
        }

        public string ReadTextFile(string filenames, bool clear = true)
        {

            var currentFile = string.Format(ioSettings.ReadFileLocation, filenames);

            if (clear)
            {
                Console.Clear();
            }

           if (!File.Exists(currentFile))
           {
               throw new ArgumentException("File doesnt exist");
           }

           string text = File.ReadAllText(currentFile);

           return text;
        }

      
    }
}
