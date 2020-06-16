using System;

namespace ConsoleSnake.Game
{
    internal class Food
    {
        // position of food
        public Point Position { get; } = new Point();

        // random instance
        private Random Random { get; } = new Random();

        public Food()
        {
            Reset();
        }

        // set new coordinates
        public void Reset()
        {
            Position.X = Random.Next(30);
            Position.Y = Random.Next(20);
        }

        // display food
        public void DisplayFood()
        {
            Console.SetCursorPosition(Position.X, Position.Y);
            Console.ForegroundColor = ConsoleColor.Cyan; 
            Console.Write(ToString(), Console.ForegroundColor);
        }

        public override string ToString()
        {
            return "*";
        }
    }
}
