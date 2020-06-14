using System;
using System.Threading;

namespace ConsoleSnake
{
    internal class GameEngine
    {
        private readonly Snake _snake = new Snake();
        private readonly Food _food = new Food();

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
                        case ConsoleKey.LeftArrow:
                            HorizontalMove(-1);
                            break;
                        case ConsoleKey.RightArrow:
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
                _snake.MoveSnakeX(value);
                _snake.PrintSnake();
                _food.DisplayFood();
                if (_snake.X == _food.X && _snake.Y == _food.Y)
                {
                    _food.ChangeFoodPosition();
                    _snake.AddTailX(value);
                }

                Thread.Sleep(150);
            }
        }

        private void VerticalMove(int value)
        {
            while (!Console.KeyAvailable)
            {
                Console.Clear();
                _snake.MoveSnakeY(value);
                _snake.PrintSnake();
                _food.DisplayFood();
                if (_snake.X == _food.X && _snake.Y == _food.Y)
                {
                    _food.ChangeFoodPosition();
                    _snake.AddTailY(value);
                }
                Thread.Sleep(150);
            }
        }
    }
}
