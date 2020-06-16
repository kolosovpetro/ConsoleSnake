using System;

namespace ConsoleSnake.Statistics
{
    [Serializable]
    internal class Player
    {
        public string PlayerName { get; set; }
        public int Score { get; set; }

        public Player()
        {
            PlayerName = "DefaultName";
        }

        public void SetPlayerName(string name)
        {
            PlayerName = name;
        }

        public void SetScore(int result)
        {
            Score = result;
        }

        public override string ToString()
        {
            return $"Player name: {PlayerName}, Score: {Score}";
        }
    }
}
