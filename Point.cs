using System;

namespace ConsoleSnake
{
    internal class Point : IEquatable<Point>
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

        public void Reset()
        {
            X = 0;
            Y = 0;
        }

        // may be removed in future. Use only other overload
        public void PrintPoint()
        {
            Console.SetCursorPosition(X, Y);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write(ToString(), Console.ForegroundColor);
        }

        public void PrintPoint(ConsoleColor color)
        {
            Console.SetCursorPosition(X, Y);
            Console.ForegroundColor = color;
            Console.Write(ToString(), Console.ForegroundColor);
        }

        public bool Equals(Point other)
        {
            if (other == null)
                return false;
            return X.Equals(other.X) && Y.Equals(other.Y);
        }

        public override string ToString()
        {
            return "*";
        }
    }
}
