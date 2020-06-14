using System;

namespace ConsoleSnake.Auxiliaries
{
    internal class Food
    {
        // position of food
        public Point Position { get; } = new Point();

        // random instance
        private readonly Random _random = new Random();

        // get coordinates
        public int X => Position.X;
        public int Y => Position.Y;

        public Food()
        {
            ChangeFoodPosition();
        }

        // reset food position
        public void ResetPosition()
        {
            Position.Reset();
        }

        // Generate new coordinates for food
        public (int, int) GenerateCoordinates()
        {
            int newX = _random.Next(20);
            int newY = _random.Next(20);
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
