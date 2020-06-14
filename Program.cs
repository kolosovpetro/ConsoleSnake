using System;
using System.Threading;
using ConsoleSnake.Auxiliaries;

namespace ConsoleSnake
{
    internal class Program
    {
        static void Main()
        {
            var snake = new Snake();


            while (true)
            {
                if (Console.KeyAvailable)
                {
                    var command = Console.ReadKey().Key;

                    switch (command)
                    {
                        case ConsoleKey.DownArrow:
                            snake.MoveY(1);
                            break;
                        case ConsoleKey.UpArrow:
                            snake.MoveY(-1);
                            break;
                        case ConsoleKey.LeftArrow:
                            snake.MoveX(-1);
                            break;
                        case ConsoleKey.RightArrow:
                            snake.MoveX(1);
                            break;
                    }
                }
            }

        }
    }
}
