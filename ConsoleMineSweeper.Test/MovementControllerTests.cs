using System;
using System.Collections.Generic;
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

            KeyValuePair<string, int> location = new KeyValuePair<string, int>("A", 3);

            var  newlocation = movementController.Move(Core.Enum.MovementDirection.Up, location);

            Assert.IsTrue(newlocation.Value == 2); 
        }

        [Test]
        public void Move_Up_AlreadyAtTop()
        {
            MovementController movementController = new MovementController();

            KeyValuePair<string, int> location = new KeyValuePair<string, int>("A", 1);

            var newlocation = movementController.Move(Core.Enum.MovementDirection.Up, location);

           Assert.IsTrue(newlocation.Equals(location));
        }


        [Test]
        public void Move_Down_Successful()
        {
            MovementController movementController = new MovementController();

            KeyValuePair<string, int> location = new KeyValuePair<string, int>("A", 3);

            var newlocation = movementController.Move(Core.Enum.MovementDirection.Down, location);

            Assert.IsTrue(newlocation.Value == 4);
        }

        [Test]
        public void Move_Down_AlreadyAtTop()
        {
            MovementController movementController = new MovementController();

            KeyValuePair<string, int> location = new KeyValuePair<string, int>("A", 8);

            var newlocation = movementController.Move(Core.Enum.MovementDirection.Down, location);

            Assert.IsTrue(newlocation.Equals(location));
        }


        [Test]
        public void Move_Right_Successful()
        {
            MovementController movementController = new MovementController();

            KeyValuePair<string, int> location = new KeyValuePair<string, int>("A", 3);

            var newlocation = movementController.Move(Core.Enum.MovementDirection.Right , location);

            Assert.IsTrue(newlocation.Key.Equals("B"));
        }

        //ToDo fix movement right
        [Test]
        public void Move_Right_AlreadyAtEnd()
        {
            MovementController movementController = new MovementController();

            KeyValuePair<string, int> location = new KeyValuePair<string, int>("H", 1);

            var newlocation = movementController.Move(Core.Enum.MovementDirection.Right, location);

            Assert.IsTrue(newlocation.Equals(location));
        }

        //ToDo fix movement left
        [Test]
        public void Move_Left_Successful()
        {
            MovementController movementController = new MovementController();

            KeyValuePair<string, int> location = new KeyValuePair<string, int>("B", 3);

            var newlocation = movementController.Move(Core.Enum.MovementDirection.Left, location);

            Assert.IsTrue(newlocation.Key.Equals("C"));
        }

        //ToDo fix movement left
        [Test]
        public void Move_Left_AlreadyAtStart()
        {
            MovementController movementController = new MovementController();

            KeyValuePair<string, int> location = new KeyValuePair<string, int>("A", 1);

            var newlocation = movementController.Move(Core.Enum.MovementDirection.Left, location);

            Assert.IsTrue(newlocation.Equals(location));
        }
    }
}
