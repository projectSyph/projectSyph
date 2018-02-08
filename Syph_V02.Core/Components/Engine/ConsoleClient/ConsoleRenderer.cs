﻿using Syph_V02.Core.Components.Engine.ConsoleClient.Contracts;
using Syph_V02.Core.Components.Engine.Contracts;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Syph_V02.Core.Components.Engine.ConsoleClient
{
    public class ConsoleRenderer :  IRenderer
    {
        public static string[] data = new[]
      {
            "add",
            "add monster",
            "monster",
            "Bar",
            "Barbec",
            "Barbecue",
            "Batman",
        };

        public static void ClearCurrentLine()
        {
            var currentLine = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLine);
        }

        public static void HandleKeyInput(StringBuilder builder, IEnumerable<string> data, ConsoleKeyInfo input)
        {
            var currentInput = builder.ToString();
            if (input.Key == ConsoleKey.Backspace && currentInput.Length > 0)
            {
                builder.Remove(builder.Length - 1, 1);
                ClearCurrentLine();

                currentInput = currentInput.Remove(currentInput.Length - 1);
                Console.Write(currentInput);
            }
            else
            {
                var key = input.KeyChar;
                builder.Append(key);
                Console.Write(key);
            }
        }

        public  static void HandleTabInput(StringBuilder builder, IEnumerable<string> data)
        {
            var currentInput = builder.ToString();

            var match = data
                .FirstOrDefault(item => item != 
                currentInput &&
                item.StartsWith(currentInput, true, CultureInfo.InvariantCulture));

            if (string.IsNullOrEmpty(match))
            {
                return;
            }

            ClearCurrentLine();
            builder.Clear();

            Console.Write(match);
            builder.Append(match);
        }


        public IEnumerable<string> Input()
        {
            var builder = new StringBuilder();
            var input = Console.ReadKey(intercept: true);

            while (string.IsNullOrEmpty(input.Key.ToString()));
            {

                while (input.Key != ConsoleKey.Enter)
                {
                    if (input.Key == ConsoleKey.Tab)
                    {
                        HandleTabInput(builder, data);
                    }
                    else
                    {
                        HandleKeyInput(builder, data, input);
                    }

                    input = Console.ReadKey(intercept: true);
                }

                yield return builder.ToString();
            }
          
        }

        

        //public void Output(IEnumerable<string> output)
        //{
        //    throw new NotImplementedException();
        //}

        //IEnumerable<string> IRenderer.Input()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
