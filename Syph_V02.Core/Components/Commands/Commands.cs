using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syph_V02.Core.Components.Commands
{
    /// <summary>
    /// Initialize Commands 
    /// TODO : Find other way to do this
    /// </summary>
    public static class Commands
    {
        public static string[] CommandsList
        {
            get
            {
                return commandsList;
            }
        }

        /// <summary>
        /// Some of the commands are set for testing
        /// </summary>
        private  static string[] commandsList = new[]
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
