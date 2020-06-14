namespace ConsoleSnake.Auxiliaries
{
    internal interface IPoint
    {
        int X { get; set; }
        int Y { get; set;  }
        void IncrementX(int val);
        void IncrementY(int val);
        void Reset();
    }
}