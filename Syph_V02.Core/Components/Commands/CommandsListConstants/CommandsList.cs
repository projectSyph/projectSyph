using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syph_V02.Core.Components.Commands
{
    public static class CommandsList //needs to be static, apparently
    {
        private static IList<string> basicCommandsLibrary = new List<string>()
        {
              "help",
              "menu",
              "guide",
              "credits",
              "about",
              "new game",
              "exit"
        };

        //private static IList<string> battleCommandsLibrary = new List<string>()
        //{
        //    "help",
        //    "attack",
        //    "surrender",
        //    "sacrifice",
        //    "attack",
        //    "inventory",
        //    "summon",
        //    "skip",
        //    "add player",
        //    "exit"
        //};

        public static IList<string> BasicCommandsLibrary => basicCommandsLibrary;
    }
}
