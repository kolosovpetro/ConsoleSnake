using System;
using System.Collections.Generic;

namespace ConsoleSnake.Statistics
{
    [Serializable]
    internal class Player
    {
        public string PlayerName { get; private set; }
        public List<int> Results { get; }

        public Player()
        {
            Results = new List<int>();
            PlayerName = "DefaultName";
        }

        public void SetPlayerName(string name)
        {
            PlayerName = name;
        }

        public void AddResult(int result)
        {
            Results.Add(result);
        }
    }
}
