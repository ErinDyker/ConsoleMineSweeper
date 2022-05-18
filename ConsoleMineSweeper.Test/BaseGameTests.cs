using ConsoleMineSweeper.Core;
using ConsoleMineSweeper.Core.Interfaces;
using Moq;
using NUnit.Framework;

namespace ConsoleMineSweeper.Test
{
    public class Tests
    {
        Mock<IMineCreatorService> _minecreatorMock;
        Mock<IMovementController> _movementMock;
        Mock<IStringInputService> _stringInputMock;

        [SetUp]
        public void Setup()
        {
            _minecreatorMock = new Mock<IMineCreatorService>(MockBehavior.Default);
            _movementMock = new Mock<IMovementController>(MockBehavior.Default);
            _stringInputMock = new Mock<IStringInputService>(MockBehavior.Default);
        }

        [Test]
        public void DifficultySelector_Recognised_Easy()
        {

            _stringInputMock.Setup(x => x.GetStringInput()).Returns("easy");

            BaseGame basegame = new BaseGame(_minecreatorMock.Object, _movementMock.Object, _stringInputMock.Object);

            basegame.DifficultySelector();

            _minecreatorMock.Verify(x => x.CreateMines(Core.Enum.GameDifficulty.Easy));

        }

        [Test]
        public void DifficultySelector_Recognised_Medium()
        {

            _stringInputMock.Setup(x => x.GetStringInput()).Returns("medium");

            BaseGame basegame = new BaseGame(_minecreatorMock.Object, _movementMock.Object, _stringInputMock.Object);

            basegame.DifficultySelector();

            _minecreatorMock.Verify(x => x.CreateMines(Core.Enum.GameDifficulty.Medium));

        }

        [Test]
        public void DifficultySelector_Recognised_Hard()
        {

            _stringInputMock.Setup(x => x.GetStringInput()).Returns("hard");

            BaseGame basegame = new BaseGame(_minecreatorMock.Object, _movementMock.Object, _stringInputMock.Object);

            basegame.DifficultySelector();

            _minecreatorMock.Verify(x => x.CreateMines(Core.Enum.GameDifficulty.Hard));

        }

        [Test]
        public void DifficultySelector_Recognised_impossible()
        {

            _stringInputMock.Setup(x => x.GetStringInput()).Returns("impossible");

            BaseGame basegame = new BaseGame(_minecreatorMock.Object, _movementMock.Object, _stringInputMock.Object);

            basegame.DifficultySelector();

            _minecreatorMock.Verify(x => x.CreateMines(Core.Enum.GameDifficulty.Impossible));

        }

        [Test]
        public void DifficultySelector_Unrecognised()
        {
           
            _stringInputMock.Setup(x => x.GetStringInput()).Returns("wronginput");

            BaseGame basegame = new BaseGame(_minecreatorMock.Object, _movementMock.Object, _stringInputMock.Object);

            basegame.DifficultySelector();

            _stringInputMock.Verify(x => x.WriteString("INPUT UNRECOGNISED, TRY AGAIN"));

        }
    }
}
