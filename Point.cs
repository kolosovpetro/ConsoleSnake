using System;

namespace ConsoleSnake
{
    internal class Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point()
        {
        }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public void IncrementX(int val)
        {
            X += val;
        }

        public void IncrementY(int val)
        {
            Y += val;
        }

        public void Reset()
        {
            X = 0;
            Y = 0;
        }

        public void PrintPoint()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(this);
        }

        public override string ToString()
        {
            return "*";
        }
    }
}
