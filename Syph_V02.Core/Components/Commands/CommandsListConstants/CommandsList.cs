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

      
        private static List<string> commandsLibrary = new List<string>()
        {
              "help => commands help",
              "menu",
              "guide",
              "surrender",
              "credits",
              "about",            
              "new game 2 players ( DEMO EDITION )",                        
              "exit"
        };

        /* NOT IMPLEMENTED COMMANDS
         * 
              "attack",
              "sacrifice <monster_type> <monster_name>",
              "attack <opponent's_name> <monster_type> <monster_name> <my_monster_type> <my_monster_name>",
              "inventory <team_id> <player_id>",
              "summon <monster_type> <monster_name> <souls_for_monster>",
              "skip",
              "add player",
              "Player <name>"
        *
        */
    }
}
