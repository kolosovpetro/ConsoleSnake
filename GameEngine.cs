using System;
using System.Threading;

namespace ConsoleSnake
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
            while (!Console.KeyAvailable)
            {
                Console.Clear();

                try
                {
                    performMove(value);     // throws snake bite itself exception
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message + "\nPress any key to play again");
                    Snake.InitializeBody();
                    Food.ChangeFoodPosition();
                    Food.DisplayFood();
                    Snake.DisplaySnake();
                    Console.ReadKey();
                    continue;
                }

                Food.DisplayFood();
                Snake.DisplaySnake();

                if (Snake.X == Food.X && Snake.Y == Food.Y)
                {
                    PlayerCount++;
                    UpdateCount();
                    Food.ChangeFoodPosition();
                    // this is to check that food won't appear inside snake's body
                    while (Snake.SnakeBody.Contains(Food.Position))
                        Food.ChangeFoodPosition();
                    Snake.AddTailX(value);
                }

                Thread.Sleep(150);
            }
        }

        private void UpdateCount()
        {
            Console.Title = $"Snake game. Current count: {PlayerCount}";
        }

        private string[] MainMenu()
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
