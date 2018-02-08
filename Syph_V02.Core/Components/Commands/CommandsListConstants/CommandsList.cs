using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syph_V02.Core.Components.Commands
{
    public static class CommandsList
    {
        public static string[] CommandsLibrary
        {
            get
            {
                return commandsLibrary;
            }
        }

        /// <summary>
        /// Some of the commands are set for testing
        /// </summary>
        private static string[] commandsLibrary = new[]
        {
              "help => commands help",
              "surrender",
              "sacrifice <monster_type> <monster_name>",
              "attack <opponent's_name> <monster_type> <monster_name> <my_monster_type> <my_monster_name>",
              "inventory <team_id> <player_id>",
              "summon <monster_type> <monster_name> <souls_for_monster>",
              "skip",
              "add player",
              "Player <name> ",
              "2<how many[2-4]> players game"
        };
    }
}
