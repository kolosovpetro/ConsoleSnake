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
        private Player CurrentPlayer { get; } = new Player();
        private StatisticsEngine StatEngine { get; } = new StatisticsEngine();
        private int PlayerCount { get; set; }
        private int Difficulty { get; set; } = 150;
        private delegate void PerformMove(int val);

        public void GameProcess()
        {
            Console.WriteLine("Press any key to start... or X to quit");
            UpdateTitle();
            Food.DisplayFood();
            Snake.DisplaySnake();
            var command = new ConsoleKey();

            while (command != ConsoleKey.X)
            {
                if (Console.KeyAvailable)
                {
                    command = Console.ReadKey().Key;
                    PerformMove performMove;
                    switch (command)
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
                            command = ConsoleKey.X;
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
                        PlayerCount++;
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
                Snake.Reset();
                Snake.DisplaySnake();
                Food.Reset();
                Food.DisplayFood();
                PlayerCount = 0;
                UpdateTitle();
            }
        }

        private void UpdateTitle()
        {
            Console.Title = $"Snake game. Current count: {PlayerCount}";
        }

        private static IEnumerable<string> MainMenu()
        {
            return new[]
            {
                "1. New game",
                "2. Options",
                "2. Statistics"
            };
        }

        private void DisplayMenu()
        {
            foreach (var item in MainMenu()) Console.WriteLine(item);
        }

        public void SetDifficulty(int difficulty)
        {
            Difficulty = difficulty;
        }

        public void SetPlayerName(string name)
        {
            CurrentPlayer.SetPlayerName(name);
        }
    }
}
