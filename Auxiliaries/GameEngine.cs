using System;
using System.Threading;

namespace ConsoleSnake.Auxiliaries
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
                            while (!Console.KeyAvailable)
                            {
                                Console.Clear();
                                _snake.MoveSnakeY(1);
                                _snake.PrintSnake();
                                _food.DisplayFood();
                                if (_snake.X == _food.X && _snake.Y == _food.Y)
                                {
                                    _food.ChangeFoodPosition();
                                    _snake.AddTailY(1);
                                }
                                Thread.Sleep(344);
                            }

                            break;
                        case ConsoleKey.UpArrow:
                            while (!Console.KeyAvailable)
                            {
                                Console.Clear();
                                _snake.MoveSnakeY(-1);
                                _snake.PrintSnake();
                                _food.DisplayFood();
                                if (_snake.X == _food.X && _snake.Y == _food.Y)
                                {
                                    _food.ChangeFoodPosition();
                                    _snake.AddTailY(-1);
                                }
                                Thread.Sleep(344);
                            }

                            break;
                        case ConsoleKey.LeftArrow:
                            while (!Console.KeyAvailable)
                            {
                                Console.Clear();
                                _snake.MoveSnakeX(-1);
                                _snake.PrintSnake();
                                _food.DisplayFood();
                                if (_snake.X == _food.X && _snake.Y == _food.Y)
                                {
                                    _food.ChangeFoodPosition();
                                    _snake.AddTailX(-1);
                                }
                                Thread.Sleep(344);
                            }

                            break;
                        case ConsoleKey.RightArrow:
                            while (!Console.KeyAvailable)
                            {
                                Console.Clear();
                                _snake.MoveSnakeX(1);
                                _snake.PrintSnake();
                                _food.DisplayFood();
                                if (_snake.X == _food.X && _snake.Y == _food.Y)
                                {
                                    _food.ChangeFoodPosition();
                                    _snake.AddTailX(1);
                                }
                                Thread.Sleep(344);
                            }

                            break;
                    }
                }
            }
        }
    }
}
