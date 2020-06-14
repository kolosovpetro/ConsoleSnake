using System;
using System.Threading;

namespace ConsoleSnake.Auxiliaries
{
    internal class Snake
    {
        // position of snake
        public IPoint Position { get; } = new Point();

        // instance of food
        private readonly Food _food = new Food();

        // snake symbol
        public string SnakeChar { get; set; }

        public Snake()
        {
            _food.ChangeFoodPosition();
            SnakeChar = "*";
        }

        public void MoveX(int val)
        {
            while (!Console.KeyAvailable)
            {
                Console.Clear();
                DisplaySnake();
                Position.IncrementX(val);
                _food.DisplayFood();
                if (Position.X == _food.Position.X && Position.Y == _food.Position.Y)
                {
                    _food.ChangeFoodPosition();
                    SnakeChar += "*";
                }
                Thread.Sleep(200);
            }
        }

        public void MoveY(int val)
        {
            while (!Console.KeyAvailable)
            {
                Console.Clear();
                DisplaySnake();
                Position.IncrementY(val);
                _food.DisplayFood();
                if (Position.X == _food.Position.X && Position.Y == _food.Position.Y)
                {
                    _food.ChangeFoodPosition();
                    SnakeChar += "*";
                }
                Thread.Sleep(200);
            }
        }

        private void DisplaySnake()
        {
            Console.SetCursorPosition(Position.X, Position.Y);
            Console.Write(SnakeChar);
        }
    }
}
