using NUnit.Framework;

namespace ConsoleSnake.UnitTests
{
    [TestFixture]
    class UnitTests
    {
        private readonly GameEngine _engine = new GameEngine();
        private readonly Snake _snake = new Snake();

        [Test]
        public void SnakeContainsTest()
        {
            Assert.That(_snake.SnakeBody.Contains(new Point(5, 3)), Is.EqualTo(true));
        }
    }
}
