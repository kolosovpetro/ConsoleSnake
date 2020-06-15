using System;

namespace ConsoleSnake.Exceptions
{
    class SnakeOverstepException : Exception
    {
        public SnakeOverstepException(string message) : base(message)
        {

        }
    }
}
