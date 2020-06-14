using System;
using System.Threading;

namespace ConsoleSnake.Auxiliaries
{
    internal class Snake
    {
        private readonly IPoint _position;
        private string _snake = "*";

        public Snake()
        {
            _position = new Point();
        }

        public void MoveX(int val)
        {
            while (!Console.KeyAvailable)
            {
                Console.Clear();
                Console.SetCursorPosition(_position.X, _position.Y);
                Console.Write(_snake);
                _position.IncrementX(val);
                Thread.Sleep(200);
            }
        }

        public void MoveY(int val)
        {
            while (!Console.KeyAvailable)
            {
                Console.Clear();
                Console.SetCursorPosition(_position.X, _position.Y);
                Console.Write(_snake);
                _position.IncrementY(val);
                Thread.Sleep(200);
            }
        }
    }
}
