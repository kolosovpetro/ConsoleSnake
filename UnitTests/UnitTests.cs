using System.Linq;
using NUnit.Framework;

namespace ConsoleSnake.UnitTests
{
    [TestFixture]
    internal class UnitTests
    {
        private readonly GameEngine _engine = new GameEngine();
        private readonly Snake _snake = new Snake();

        [Test]
        public void SnakeContainsTest()
        {
            Assert.That(_snake.SnakeBody.Contains(new Point(5, 3)), Is.EqualTo(true));
        }

        [Test]
        public void CheckConditions()
        {
            var head = _snake.Head;
            var count = _snake.SnakeBody
                .Count(x => x == head);
            Assert.That(count, Is.EqualTo(1));
        }
    }
}
