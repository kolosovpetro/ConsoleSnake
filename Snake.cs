using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleSnake.Exceptions;

namespace ConsoleSnake
{
    internal class Snake
    {
        // snake body
        public List<Point> SnakeBody { get; } = new List<Point>();
        public Point Head => SnakeBody[0];

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
            for (var i = 0; i < 10; i++)
                SnakeBody.Add(new Point(5, 2 + i));
        }

        // print snake
        public void DisplaySnake()
        {
            foreach (var point in SnakeBody)
            {
                if (SnakeBody.IndexOf(point) == 0)
                {
                    // this if makes head of snake to be red
                    point.PrintPoint(ConsoleColor.DarkMagenta);
                    continue;
                }

                point.PrintPoint();
            }
        }

        public void MoveSnakeX(int val)
        {
            RemoveTail();
            var next = new Point(Head.X + val, Head.Y);
            if (!LegalMove(next))
                throw new SnakeOverstepException("Game Over");
            SnakeBody.Insert(0, next);
        }

        public void MoveSnakeY(int val)
        {
            RemoveTail();
            var next = new Point(Head.X, Head.Y + val);
            if (!LegalMove(next))
                throw new SnakeOverstepException("Game Over");
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

        public bool LegalMove(Point point)
        {
            return !SnakeBody.Contains(point);
        }

        private void RemoveTail()
        {
            SnakeBody.RemoveAt(Length - 1);
        }
    }
}
