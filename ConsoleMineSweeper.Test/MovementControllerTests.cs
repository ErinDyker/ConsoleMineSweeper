using System;
using System.Collections.Generic;
using ConsoleMineSweeper.Core.Enum;
using ConsoleMineSweeper.Core.Models;
using ConsoleMineSweeper.Core.Services;
using NUnit.Framework;

namespace ConsoleMineSweeper.Test
{
    public class MovementControllerTests
    {
        

        [Test]
        public void Move_Up_Successful()
        {
            MovementController movementController = new MovementController();

            Coordinate location = new Coordinate() { XPosition = "A", YPosition = 3 };

            var  newlocation = movementController.Move(Core.Enum.MovementDirection.Up, location);

            Assert.IsTrue(newlocation.YPosition == 2); 
        }

        [Test]
        public void Move_Up_AlreadyAtTop()
        {
            MovementController movementController = new MovementController();

            Coordinate location = new Coordinate() { XPosition = "A", YPosition = 1 };

            var newlocation = movementController.Move(Core.Enum.MovementDirection.Up, location);

           Assert.IsTrue(newlocation.Equals(location));
        }


        [Test]
        public void Move_Down_Successful()
        {
            MovementController movementController = new MovementController();

            Coordinate location = new Coordinate() { XPosition = "A", YPosition = 3 };

            var newlocation = movementController.Move(Core.Enum.MovementDirection.Down, location);

            Assert.IsTrue(newlocation.YPosition == 4);
        }

        [Test]
        public void Move_Down_AlreadyAtBottom()
        {
            MovementController movementController = new MovementController();

            Coordinate location = new Coordinate() { XPosition = "A", YPosition = 9};

            var newlocation = movementController.Move(Core.Enum.MovementDirection.Down, location);

            Assert.IsTrue(newlocation.Equals(location));
        }


        [Test]
        public void Move_Right_Successful()
        {
            MovementController movementController = new MovementController();

            Coordinate location = new Coordinate() { XPosition = "A", YPosition = 3 };

            var newlocation = movementController.Move(Core.Enum.MovementDirection.Right , location);

            Assert.IsTrue(newlocation.XPosition.Equals("B"));
        }

      
        [Test]
        public void Move_Right_AlreadyAtEnd()
        {
            MovementController movementController = new MovementController();

            Coordinate location = new Coordinate() { XPosition = "H", YPosition = 1 };

            var newlocation = movementController.Move(Core.Enum.MovementDirection.Right, location);

            Assert.IsTrue(newlocation.Equals(location));
        }

      
        [Test]
        public void Move_Left_Successful()
        {
            MovementController movementController = new MovementController();

            Coordinate location = new Coordinate() { XPosition = "B", YPosition = 3 };

            var newlocation = movementController.Move(Core.Enum.MovementDirection.Left, location);

            Assert.IsTrue(newlocation.XPosition.Equals("A"));
        }

      
        [Test]
        public void Move_Left_AlreadyAtStart()
        {
            MovementController movementController = new MovementController();

            Coordinate location = new Coordinate() { XPosition = "A", YPosition = 1 };

            var newlocation = movementController.Move(Core.Enum.MovementDirection.Left, location);

            Assert.IsTrue(newlocation.Equals(location));
        }

        [Test]
        public void Parse_Success()
        {
            MovementController movementController = new MovementController();

            var movement = movementController.ParseDirection("up");

            Assert.IsNotNull(movement);
            Assert.IsTrue((MovementDirection)movement == MovementDirection.Up);
        }

        [Test]
        public void Parse_Success_Capitalised()
        {
            MovementController movementController = new MovementController();

            var movement = movementController.ParseDirection("UP");

            Assert.IsNotNull(movement);
            Assert.IsTrue((MovementDirection)movement == MovementDirection.Up);
        }

        [Test]
        public void Parse_Fail()
        {
            MovementController movementController = new MovementController();

            var movement = movementController.ParseDirection("wrong");

            Assert.IsNull(movement);
        }
    }
}
