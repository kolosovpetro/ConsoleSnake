using System;

namespace ConsoleSnake.Exceptions
{
    class BorderCrossException : Exception
    {
        public BorderCrossException(string message) : base(message)
        {

        }
    }
}
