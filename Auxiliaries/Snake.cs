using System;
using System.Collections.Generic;
using System.Threading;

namespace ConsoleSnake.Auxiliaries
{
    internal class Snake
    {
        // snake body
        public List<Point> SnakeBody { get; } = new List<Point>();

        // get snake length
        public int Length => SnakeBody.Count;

        public Snake()
        {
            InitializeBody();
        }

        // initialize snake body
        public void InitializeBody()
        {
            for (int i = 0; i < 5; i++)
                SnakeBody.Add(new Point(5, 2 + i));
        }

        // print snake
        public void PrintSnake()
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
    }
}
