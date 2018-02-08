using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syph_V02.Core.Components.Commands
{
    public static class CommandsList
    {
        public static List<string>  CommandsLibrary
        {
            get
            {
                return commandsLibrary;
            }
        }

        /// <summary>
        /// Some of the commands are set for testing
        /// </summary>
        private static List<string> commandsLibrary = new List<string>()
        {
              "help => commands help",
              "menu",
              "guide",
              "surrender",
              "credits",
              "about",
              "sacrifice <monster_type> <monster_name>",
              "attack <opponent's_name> <monster_type> <monster_name> <my_monster_type> <my_monster_name>",
              "inventory <team_id> <player_id>",
              "summon <monster_type> <monster_name> <souls_for_monster>",
              "skip",
              "add player",
              "Player <name>",
              "new game",
              "new game <players count[2]> <player_one_Name> <player_two_Name>",           
              "exit"
        };
    }
}
