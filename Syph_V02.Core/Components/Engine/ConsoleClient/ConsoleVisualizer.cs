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
        public string ReadTextFile(string filenames, bool clear = true)
        {          
            if (clear)
            {
                Console.Clear();
            }

           if (!File.Exists($"./../../../content/{filenames}.txt"))
           {
               throw new ArgumentException("File doesnt exist");
           }

           string text = File.ReadAllText($"./../../../content/{filenames}.txt");

           return text;
        }

      
    }
}
