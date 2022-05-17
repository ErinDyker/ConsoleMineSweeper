using System;
using System.Linq;
using ConsoleMineSweeper.Core.Services;
using NUnit.Framework;

namespace ConsoleMineSweeper.Test
{
    public class MineCreatorTests
    {

        [Test]
        public void CreateMines_Easy()
        {
            MineCreatorService mineCreator = new MineCreatorService();

            var mines = mineCreator.CreateMines(Core.Enum.GameDifficulty.Easy);

            Assert.IsNotNull(mines);
            Assert.IsNotEmpty(mines);
            Assert.IsTrue(mines.Count == 2);
        }

        [Test]
        public void CreateMines_Medium()
        {
            MineCreatorService mineCreator = new MineCreatorService();

            var mines = mineCreator.CreateMines(Core.Enum.GameDifficulty.Medium);

            Assert.IsNotNull(mines);
            Assert.IsNotEmpty(mines);
            Assert.IsTrue(mines.Count == 10);
        }

        [Test]
        public void CreateMines_Hard()
        {
            MineCreatorService mineCreator = new MineCreatorService();

            var mines = mineCreator.CreateMines(Core.Enum.GameDifficulty.Hard);

            Assert.IsNotNull(mines);
            Assert.IsNotEmpty(mines);
            Assert.IsTrue(mines.Count == 25);
        }

        [Test]
        public void CreateMines_Impossible()
        {
            MineCreatorService mineCreator = new MineCreatorService();

            var mines = mineCreator.CreateMines(Core.Enum.GameDifficulty.Impossible);

            Assert.IsNotNull(mines);
            Assert.IsNotEmpty(mines);
            Assert.IsTrue(mines.Count == 50);
        }

        [Test]
        public void CreateMines_All_Mines_Different()
        {
            MineCreatorService mineCreator = new MineCreatorService();

            var mines = mineCreator.CreateMines(Core.Enum.GameDifficulty.Impossible);


            //Todo Check this test is accurate, seems unlikely at this momemnt
            Assert.IsTrue(mines.Distinct().Count() == mines.Count());

            
        }
    }
}
