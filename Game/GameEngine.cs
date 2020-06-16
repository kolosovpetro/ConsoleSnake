using System;
using System.Collections.Generic;
using System.Threading;
using ConsoleSnake.Statistics;

namespace ConsoleSnake.Game
{
    internal class GameEngine
    {
        private Snake Snake { get; } = new Snake();
        private Food Food { get; } = new Food();
        private static StatisticsEngine StatEngine { get; set; } = new StatisticsEngine();
        private Player CurrentPlayer { get; } = new Player();
        private int Difficulty { get; set; } = 150;
        private delegate void PerformMove(int val);

        public GameEngine()
        {
            CurrentPlayer.PlayerName = StatEngine.PlayerList[^1].PlayerName;
        }

        public void MainProcess()
        {
            var menuCommand = new ConsoleKey();
            while (menuCommand != ConsoleKey.D4)
            {
                DisplayMenu();
                menuCommand = Console.ReadKey().Key;

                switch (menuCommand)
                {
                    case ConsoleKey.D1:
                        Console.Clear();
                        GameProcess();
                        break;
                    case ConsoleKey.D2:
                        Console.Clear();
                        GameOptions();
                        break;
                    case ConsoleKey.D3:
                        Console.Clear();
                        GameStatistics();
                        break;
                    case ConsoleKey.D4:
                        menuCommand = ConsoleKey.D4;
                        break;
                }

                Console.Clear();
            }
        }

        public void GameProcess()
        {
            Console.WriteLine("Press any key to start... or X to quit");
            UpdateTitle();
            Food.DisplayFood();
            Snake.DisplaySnake();
            var gameCommand = new ConsoleKey();

            while (gameCommand != ConsoleKey.X)
            {
                if (Console.KeyAvailable)
                {
                    gameCommand = Console.ReadKey().Key;
                    PerformMove performMove;
                    switch (gameCommand)
                    {
                        case ConsoleKey.DownArrow:
                            performMove = Snake.MoveSnakeY;
                            MoveSnake(1, performMove);
                            break;
                        case ConsoleKey.UpArrow:
                            performMove = Snake.MoveSnakeY;
                            MoveSnake(-1, performMove);
                            break;
                        case ConsoleKey.RightArrow:
                            performMove = Snake.MoveSnakeX;
                            MoveSnake(1, performMove);
                            break;
                        case ConsoleKey.LeftArrow:
                            performMove = Snake.MoveSnakeX;
                            MoveSnake(-1, performMove);
                            break;
                        case ConsoleKey.X:
                            gameCommand = ConsoleKey.X;
                            break;
                        default:
                            performMove = Snake.MoveSnakeX;
                            MoveSnake(1, performMove);
                            break;
                    }
                }
            }
        }

        private void MoveSnake(int value, PerformMove performMove)
        {
            try
            {
                while (!Console.KeyAvailable)
                {
                    performMove(value);     // throws snake bite itself exception & index out of range exception
                    Food.DisplayFood();
                    Snake.DisplaySnake();

                    if (Snake.Head.Equals(Food.Position))
                    {
                        CurrentPlayer.Score++;
                        UpdateTitle();
                        Food.Reset();
                        // this is to check that food won't appear inside snake's body
                        while (Snake.SnakeBody.Contains(Food.Position))
                            Food.Reset();
                        Snake.AddTail(value);
                    }

                    Thread.Sleep(Difficulty);
                    Console.Clear();
                }
            }
            catch (Exception)
            {
                Console.SetCursorPosition(0, 0);
                Console.WriteLine("Game over. Press any key to play again");
                // save player result
                StatEngine.AddPlayer(CurrentPlayer);
                StatEngine.Serialize();
                // reset snake position and food position
                Snake.Reset();
                Snake.DisplaySnake();
                Food.Reset();
                Food.DisplayFood();
                // reset player count and update title
                CurrentPlayer.Score = 0;
                UpdateTitle();
            }
        }

        private void UpdateTitle()
        {
            Console.Title = $"Player name: {CurrentPlayer.PlayerName}. Current count: {CurrentPlayer.Score}";
        }

        private static IEnumerable<string> Menu()
        {
            return new[]
            {
                "1. New game",
                "2. Options",
                "3. Statistics",
                "4. Exit"
            };
        }

        private static void DisplayMenu()
        {
            foreach (var item in Menu()) Console.WriteLine(item);
        }

        public IEnumerable<string> OptionsMenu()
        {
            return new[]
            {
                "1. Change player name",
                "2. Change difficulty"
            };
        }

        public void DisplayOptionsMenu()
        {
            foreach (var option in OptionsMenu()) Console.WriteLine(option);
        }

        public void GameOptions()
        {
            DisplayOptionsMenu();
            var userCommand = Console.ReadKey().Key;
            switch (userCommand)
            {
                case ConsoleKey.D1:
                    Console.Clear();
                    Console.WriteLine($"Current player name: {CurrentPlayer.PlayerName}");
                    Console.WriteLine("Set new player name");
                    var playerName = Console.ReadLine();
                    CurrentPlayer.SetPlayerName(playerName);
                    Console.Clear();
                    break;
                case ConsoleKey.D2:
                    Console.Clear();
                    Console.WriteLine($"Current difficulty: {Difficulty}");
                    Console.WriteLine("Set new difficulty: 0 - 300");
                    var difficulty = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
                    Difficulty = difficulty;
                    Console.Clear();
                    break;
            }
        }

        public void GameStatistics()
        {
            StatEngine = new StatisticsEngine();
            foreach (var player in StatEngine.PlayerList) Console.WriteLine(player);
            Console.ReadKey();
        }
    }
}
