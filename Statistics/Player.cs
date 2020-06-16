using System;
using System.Collections.Generic;

namespace ConsoleSnake.Statistics
{
    [Serializable]
    internal class Player
    {
        public string PlayerName { get; set; }
        public List<int> Results { get; }
    }
}
