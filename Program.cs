using System;
using System.Collections.Generic;
using System.Threading;
using ConsoleSnake.Auxiliaries;

namespace ConsoleSnake
{
    internal class Program
    {
        private static void Main()
        {
            var snake = new Snake();

            //int t = 0;
            //while (t < 20)
            //{
            //    snake.PrintSnake();
            //    snake.MoveSnakeX(1);
            //    t++;
            //    Thread.Sleep(200);
            //    Console.Clear();
            //}

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
                                snake.MoveSnakeY(1);
                                snake.PrintSnake();
                                Thread.Sleep(344);
                            }
                            break;
                        case ConsoleKey.UpArrow:
                            while (!Console.KeyAvailable)
                            {
                                Console.Clear();
                                snake.MoveSnakeY(-1);
                                snake.PrintSnake();
                                Thread.Sleep(344);
                            }
                            break;
                        case ConsoleKey.LeftArrow:
                            while (!Console.KeyAvailable)
                            {
                                Console.Clear();
                                snake.MoveSnakeX(-1);
                                snake.PrintSnake();
                                Thread.Sleep(344);
                            }
                            break;
                        case ConsoleKey.RightArrow:
                            while (!Console.KeyAvailable)
                            {
                                Console.Clear();
                                snake.MoveSnakeX(1);
                                snake.PrintSnake();
                                Thread.Sleep(344);
                            }
                            break;
                    }
                }
            }
        }
    }
}
