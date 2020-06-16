using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace ConsoleSnake.Statistics
{
    [Serializable]
    internal class StatisticsEngine
    {
        public List<Player> PlayerList { get; private set; } = new List<Player>();
        private string FilePath { get; } = "../../../Statistics/stats.json";

        public StatisticsEngine()
        {
            Deserialize();
        }

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
            // serialize JSON to a string and then write string to a file
            File.WriteAllText(FilePath, JsonConvert.SerializeObject(PlayerList));

            // serialize JSON directly to a file
            using var file = File.CreateText(FilePath);
            var serializer = new JsonSerializer();
            serializer.Serialize(file, PlayerList);
        }

        public void Deserialize()
        {
            try
            {
                using var file = File.OpenText(FilePath);
                var serializer = new JsonSerializer();
                PlayerList = (List<Player>)serializer.Deserialize(file, typeof(List<Player>));
            }
            catch (Exception)
            {
                PlayerList = new List<Player>();
            }
        }
    }
}
