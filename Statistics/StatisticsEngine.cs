using System;
using System.Collections.Generic;

namespace ConsoleSnake.Statistics
{
    [Serializable]
    internal class StatisticsEngine
    {
        public List<Player> PlayerList { get; } = new List<Player>();

        public void AddPlayer(Player player)
        {
            PlayerList.Add(player);
        }
    }
}
