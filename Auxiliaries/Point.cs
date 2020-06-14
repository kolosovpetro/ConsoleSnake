namespace ConsoleSnake.Auxiliaries
{
    internal class Point : IPoint
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public void IncrementX(int val)
        {
            X += val;
        }

        public void IncrementY(int val)
        {
            Y += val;
        }
    }
}
