using System;
using System.Threading;

namespace ConsoleSnake
{
    internal class GameEngine
    {
        private Snake Snake { get; } = new Snake();
        private Food Food { get; } = new Food();
        private int PlayerCount { get; set; }

        public void GameProcess()
        {
            // set resolution of console
            Console.WriteLine("Press any key to start");
            UpdateCount();
            Food.DisplayFood();
            Snake.DisplaySnake();

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    var command = Console.ReadKey().Key;
                    switch (command)
                    {
                        case ConsoleKey.DownArrow:
                            VerticalMove(1);
                            break;
                        case ConsoleKey.UpArrow:
                            VerticalMove(-1);
                            break;
                        case ConsoleKey.RightArrow:
                            HorizontalMove(1);
                            break;
                        case ConsoleKey.LeftArrow:
                            HorizontalMove(-1);
                            break;
                        default:
                            HorizontalMove(1);
                            break;
                    }
                }
            }
        }

        private void HorizontalMove(int value)
        {
            while (!Console.KeyAvailable)
            {
                Console.Clear();

                try
                {
                    Snake.MoveSnakeX(value);    // throws snake kill itself exception
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message + "\nPress any key to play again");
                    Snake.InitializeBody();
                    break;
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

        private void VerticalMove(int value)
        {
            while (!Console.KeyAvailable)
            {
                Console.Clear();

                try
                {
                    Snake.MoveSnakeY(value);    // throws snake killed itself exception
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message + "\nPress any key to play again");
                    Snake.InitializeBody();
                    break;
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
                    Snake.AddTailY(value);
                }

                Thread.Sleep(150);
            }
        }

        private void UpdateCount()
        {
            Console.Title = $"Snake game. Current count: {PlayerCount}";
        }
    }
}
