using System;
using System.Collections.Generic;

namespace ConsoleSnake.Statistics
{
    [Serializable]
    internal class Player : IEquatable<Player>
    {
        public string PlayerName { get; private set; }
        public List<int> Results { get; }

        public Player()
        {
            Results = new List<int>();
        }

        public void SetPlayerName(string name)
        {
            PlayerName = name;
        }


        public bool Equals(Player other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return PlayerName == other.PlayerName && Equals(Results, other.Results);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Player)obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(PlayerName, Results);
        }
    }
}
