namespace ConsoleSnake.Auxiliaries
{
    internal interface IPoint
    {
        int X { get; }
        int Y { get; }
        void IncrementX(int val);
        void IncrementY(int val);
    }
}