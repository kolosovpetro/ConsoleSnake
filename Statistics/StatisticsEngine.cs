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

        // to show current player name in options
        public Player GetCurrentPlayer()
        {
            int length = PlayerList.Count;
            return PlayerList[length - 1];
        }

        public void Serialize()
        {

        }

        public StatisticsEngine Deserialize()
        {
            return null;
        }
    }
}
