using System;
using System.Threading;

namespace ConsoleSnake
{
    internal class GameEngine
    {
        private Snake Snake { get; } = new Snake();
        private Food Food { get; } = new Food();

        public void GameProcess()
        {
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
                    }
                }
            }
        }

        private void HorizontalMove(int value)
        {
            while (!Console.KeyAvailable)
            {
                Console.Clear();
                Snake.MoveSnakeX(value);
                Snake.PrintSnake();
                Food.DisplayFood();

                if (Snake.X == Food.X && Snake.Y == Food.Y)
                {
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
                Snake.MoveSnakeY(value);
                Snake.PrintSnake();
                Food.DisplayFood();

                if (Snake.X == Food.X && Snake.Y == Food.Y)
                {
                    Food.ChangeFoodPosition();
                    Snake.AddTailY(value);
                }

                Thread.Sleep(150);
            }
        }
    }
}
