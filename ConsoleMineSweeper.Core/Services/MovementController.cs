using System;
using System.Collections.Generic;
using ConsoleMineSweeper.Core.Enum;
using ConsoleMineSweeper.Core.Interfaces;
using ConsoleMineSweeper.Core.Models;

namespace ConsoleMineSweeper.Core.Services
{
    public class MovementController: IMovementController
    {
        public MovementController()
        {
        }

        public Coordinate Move(MovementDirection direction, Coordinate CurrentLocation)
        {
            Coordinate newLocation = CurrentLocation;
            switch(direction)
            {
                case MovementDirection.Up:
                    newLocation = Up(CurrentLocation);
                    break;
                case MovementDirection.Down:
                    newLocation = Down(CurrentLocation);
                    break;
                case MovementDirection.Left:
                    newLocation = Left(CurrentLocation);
                    break;
                case MovementDirection.Right:
                    newLocation = Right(CurrentLocation);
                    break;


            }

            return newLocation;
        }

        Coordinate Up(Coordinate CurrentLocation)
        {
            var location = CurrentLocation;

            if(CurrentLocation.YPosition > 1)
            {
                location = new Coordinate(){ XPosition = CurrentLocation.XPosition, YPosition = CurrentLocation.YPosition - 1};
            }

            return location;
        }

        Coordinate Down(Coordinate CurrentLocation)
        {
            var location = CurrentLocation;

            if (CurrentLocation.YPosition < 9)
            {
                location = new Coordinate() { XPosition = CurrentLocation.XPosition, YPosition = CurrentLocation.YPosition + 1 };
            }

            return location;
        }

        Coordinate Left(Coordinate CurrentLocation)
        {
            var location = CurrentLocation;
            char[] letter = location.XPosition.ToCharArray();

            if (!letter[0].ToString().Equals("A"))
            {
                char nextChar = (char)(((int)letter[0]) - 1);

                location = new Coordinate() { XPosition = nextChar.ToString(), YPosition = CurrentLocation.YPosition };
            }

            return location;
        }

        Coordinate Right(Coordinate CurrentLocation)
        {
            var location = CurrentLocation;
            char[] letter = location.XPosition.ToCharArray();

            if (!letter[0].ToString().Equals("H"))
            {
                char nextChar = (char)(((int)letter[0]) + 1);
                location = new Coordinate() { XPosition = nextChar.ToString(), YPosition = CurrentLocation.YPosition};

            }

           
            return location;
        }
    }
}
