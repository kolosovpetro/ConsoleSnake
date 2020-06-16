using System;

namespace ConsoleSnake.Game
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
