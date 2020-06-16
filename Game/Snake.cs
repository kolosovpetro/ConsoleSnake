using System;
using System.Collections.Generic;
using ConsoleSnake.Exceptions;

namespace ConsoleSnake.Game
{
    internal class Snake
    {
        // snake body
        public List<Point> SnakeBody { get; private set; }
        public Point Head => SnakeBody[0];
        public Point Tail => SnakeBody[Length - 1];

        // get snake length
        private int Length => SnakeBody.Count;

        // get head coordinates
        public int X => SnakeBody[0].X;
        public int Y => SnakeBody[0].Y;

        public Snake()
        {
            Reset();
        }

        // initialize snake body
        public void Reset()
        {
            SnakeBody = new List<Point>();
            for (var i = 0; i < 10; i++)
                SnakeBody.Add(new Point(5, 15 + i));
        }

        // print snake
        public void DisplaySnake()
        {
            foreach (var point in SnakeBody)
            {
                if (point == Head)
                {
                    // this if makes head of snake to be colored
                    point.PrintPoint(ConsoleColor.DarkMagenta);
                    continue;
                }

                point.PrintPoint(ConsoleColor.Gray);
            }
        }

        public void MoveSnakeX(int val)
        {
            RemoveTail();
            var next = new Point(Head.X + val, Head.Y);
            if (!LegalMove(next))
                throw new SnakeException("Game Over");
            SnakeBody.Insert(0, next);
        }

        public void MoveSnakeY(int val)
        {
            RemoveTail();
            var next = new Point(Head.X, Head.Y + val);
            if (!LegalMove(next))
                throw new SnakeException("Game Over");
            SnakeBody.Insert(0, next);
        }

        private void RemoveTail()
        {
            SnakeBody.RemoveAt(Length - 1);
        }

        public void AddTail(int val)
        {
            var tail = new Point(Tail.X + val, Tail.Y);
            SnakeBody.Insert(Length - 1, tail);
        }

        public bool LegalMove(Point point)
        {
            return !SnakeBody.Contains(point);
        }
    }
}
