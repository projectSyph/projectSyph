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
        public void ScreanRender(string component)
        {
            PrintTextFile(false, component);
        }

        public static void PrintTextFile(bool clear, params string[] filenames)
        {
            if (clear)
            {
                Console.Clear();
            }

            foreach (var file in filenames)
            {
                if (!File.Exists($"./../../../content/{file}.txt"))
                {
                    throw new ArgumentException("File doesnt exist");
                }

                string text = File.ReadAllText($"./../../../content/{file}.txt");

                Print(text);
            }
        }

        public static void Print(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}
