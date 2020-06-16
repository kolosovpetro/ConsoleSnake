using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleSnake.Statistics
{
    [Serializable]
    internal class Player
    {
        public string PlayerName { get; private set; }
        public List<int> GameResults { get; }

        public Player()
        {
            GameResults = new List<int>();
            PlayerName = "DefaultName";
        }

        public void SetPlayerName(string name)
        {
            PlayerName = name;
        }

        public void AddResult(int result)
        {
            // if player name not in list - ADD
            // if player name in list - merge results
            GameResults.Add(result);
        }

        public override string ToString()
        {
            return $"Player name: {PlayerName}, Total games: {GameResults}, Best score: {GameResults.Max()}";
        }
    }
}
