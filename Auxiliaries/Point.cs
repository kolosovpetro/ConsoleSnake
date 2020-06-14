namespace ConsoleSnake.Auxiliaries
{
    internal class Point : IPoint
    {
        public int X { get; set; }
        public int Y { get; set; }

        public void IncrementX(int val)
        {
            X += val;
        }

        public void IncrementY(int val)
        {
            Y += val;
        }

        public void Reset()
        {
            X = 0;
            Y = 0;
        }
    }
}
