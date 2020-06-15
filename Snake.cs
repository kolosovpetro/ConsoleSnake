using System.Collections.Generic;

namespace ConsoleSnake
{
    internal class Snake
    {
        // snake body
        private List<Point> SnakeBody { get; } = new List<Point>();

        // get snake length
        private int Length => SnakeBody.Count;

        // get head coordinates
        public int X => SnakeBody[0].X;
        public int Y => SnakeBody[0].Y;

        public Snake()
        {
            InitializeBody();
        }

        // initialize snake body
        private void InitializeBody()
        {
            for (int i = 0; i < 5; i++)
                SnakeBody.Add(new Point(5, 2 + i));
        }

        // print snake
        public void DisplaySnake()
        {
            foreach (var point in SnakeBody)
                point.PrintPoint();
        }

        public void MoveSnakeX(int val)
        {
            // remove tail element
            SnakeBody.RemoveAt(Length - 1);
            // get head
            var next = SnakeBody[0];
            // get next based on head
            next = new Point(next.X + val, next.Y);
            SnakeBody.Insert(0, next);
        }

        public void MoveSnakeY(int val)
        {
            // remove tail element
            SnakeBody.RemoveAt(Length - 1);
            // get head
            var next = SnakeBody[0];
            // get next based on head
            next = new Point(next.X, next.Y + val);
            SnakeBody.Insert(0, next);
        }

        public void AddTailX(int val)
        {
            var currentTail = SnakeBody[Length - 1];
            currentTail = new Point(currentTail.X + val, currentTail.Y);
            SnakeBody.Insert(Length - 1, currentTail);
        }

        public void AddTailY(int val)
        {
            var currentTail = SnakeBody[Length - 1];
            currentTail = new Point(currentTail.X, currentTail.Y + val);
            SnakeBody.Insert(Length - 1, currentTail);
        }
    }
}
