using System;

namespace ConsoleSnake.Auxiliaries
{
    internal class Food
    {
        // position of food
        private readonly IPoint _foodPosition = new Point();

        // random instance
        private readonly Random _random = new Random();

        // reset food position
        public void ResetPosition()
        {
            _foodPosition.Reset();
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
            _foodPosition.X = GenerateCoordinates().Item1;
            _foodPosition.Y = GenerateCoordinates().Item2;
        }

        // display food
        public void DisplayFood()
        {
            Console.SetCursorPosition(_foodPosition.X, _foodPosition.Y);
            Console.Write(this);
        }

        public override string ToString()
        {
            return "*";
        }
    }
}
