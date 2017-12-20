using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Syph.Core.Models;

namespace Syph.Core.Manager
{
    public class GameManager
    {
        //TODO

        private static Player[] players;

        public static void NewGame(byte numberOfPlayers = 2)
        {
            players = new Player[numberOfPlayers];

            //TODO
        }
    }
}
