using System;

namespace ConsoleSnake
{
    internal class Food
    {
        // position of food
        private Point Position { get; } = new Point();

        // random instance
        private Random Random { get; }  = new Random();

        // get coordinates
        public int X => Position.X;
        public int Y => Position.Y;

        public Food()
        {
            ChangeFoodPosition();
        }

        // Generate new coordinates for food
        private (int, int) GenerateCoordinates()
        {
            var newX = Random.Next(20);
            var newY = Random.Next(20);
            return new ValueTuple<int, int>(newX, newY);
        }

        // set new coordinates
        public void ChangeFoodPosition()
        {
            Position.X = GenerateCoordinates().Item1;
            Position.Y = GenerateCoordinates().Item2;
        }

        // display food
        public void DisplayFood()
        {
            Console.SetCursorPosition(Position.X, Position.Y);
            Console.Write(this);
        }

        public override string ToString()
        {
            return "*";
        }
    }
}
