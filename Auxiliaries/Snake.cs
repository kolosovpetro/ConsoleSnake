using System;
using System.Threading;

namespace ConsoleSnake.Auxiliaries
{
    internal class Snake
    {
        // position of snake
        private readonly IPoint _position = new Point();

        public void MoveX(int val)
        {
            while (!Console.KeyAvailable)
            {
                Console.Clear();
                Console.SetCursorPosition(_position.X, _position.Y);
                Console.Write(this);
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
                Console.Write(this);
                _position.IncrementY(val);
                Thread.Sleep(200);
            }
        }

        public override string ToString()
        {
            return "*";
        }
    }
}
