using System;
using System.Threading;

namespace ConsoleSnake.Auxiliaries
{
    internal class Snake
    {
        // position of snake
        private readonly IPoint _position = new Point();

        // instance of food
        private readonly Food _food = new Food();

        public Snake()
        {
            _food.ChangeFoodPosition();
        }

        public void MoveX(int val)
        {
            while (!Console.KeyAvailable)
            {
                Console.Clear();
                DisplaySnake();
                _position.IncrementX(val);
                _food.DisplayFood();
                Thread.Sleep(200);
            }
        }

        public void MoveY(int val)
        {
            while (!Console.KeyAvailable)
            {
                Console.Clear();
                DisplaySnake();
                _position.IncrementY(val);
                _food.DisplayFood();
                Thread.Sleep(200);
            }
        }

        private void DisplaySnake()
        {
            Console.SetCursorPosition(_position.X, _position.Y);
            Console.Write(this);
        }

        public override string ToString()
        {
            return "*";
        }
    }
}
