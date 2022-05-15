using ConsoleMineSweeper.Core.Interfaces;
using Moq;
using NUnit.Framework;

namespace ConsoleMineSweeper.Test
{
    public class Tests
    {
        Mock<IMineCreatorService> _minecreatorMock;
        Mock<IMineCreatorService> _movementMock;


        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}
