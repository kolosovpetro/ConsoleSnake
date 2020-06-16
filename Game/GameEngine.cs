using System;
using System.Collections.Generic;
using System.Threading;

namespace ConsoleSnake.Game
{
    internal class GameEngine
    {
        private Snake Snake { get; } = new Snake();
        private Food Food { get; } = new Food();
        private int PlayerCount { get; set; }
        private delegate void PerformMove(int val);

        public void GameProcess()
        {
            Console.WriteLine("Press any key to start");
            UpdateCount();
            Food.DisplayFood();
            Snake.DisplaySnake();

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    var command = Console.ReadKey().Key;
                    PerformMove performMove;
                    switch (command)
                    {
                        case ConsoleKey.DownArrow:
                            performMove = Snake.MoveSnakeY;
                            MoveSnakeSafe(1, performMove);
                            break;
                        case ConsoleKey.UpArrow:
                            performMove = Snake.MoveSnakeY;
                            MoveSnakeSafe(-1, performMove);
                            break;
                        case ConsoleKey.RightArrow:
                            performMove = Snake.MoveSnakeX;
                            MoveSnakeSafe(1, performMove);
                            break;
                        case ConsoleKey.LeftArrow:
                            performMove = Snake.MoveSnakeX;
                            MoveSnakeSafe(-1, performMove);
                            break;
                        default:
                            performMove = Snake.MoveSnakeX;
                            MoveSnake(1, performMove);
                            break;
                    }
                }
            }
        }

        private void MoveSnakeSafe(int val, PerformMove performMove)
        {
            try
            {
                MoveSnake(val, performMove);
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
                UpdateCount();
            }
        }

        private void MoveSnake(int value, PerformMove performMove)
        {
            while (!Console.KeyAvailable)
            {
                performMove(value);     // throws snake bite itself exception
                Food.DisplayFood();
                Snake.DisplaySnake();

                if (Snake.X == Food.X && Snake.Y == Food.Y)
                {
                    PlayerCount++;
                    UpdateCount();
                    Food.Reset();
                    // this is to check that food won't appear inside snake's body
                    while (Snake.SnakeBody.Contains(Food.Position))
                        Food.Reset();
                    Snake.AddTail(value);
                }

                Thread.Sleep(150);
                Console.Clear();
            }
        }

        private void UpdateCount()
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
    }
}
