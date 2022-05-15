using System;
using System.Collections.Generic;
using ConsoleMineSweeper.Core.Enum;
using ConsoleMineSweeper.Core.Interfaces;

namespace ConsoleMineSweeper.Core.Services
{
    public class MovementController: IMovementController
    {
        public MovementController()
        {
        }

        public KeyValuePair<string, int> Move(MovementDirection direction, KeyValuePair<string, int> CurrentLocation)
        {
            KeyValuePair<string, int> newLocation = CurrentLocation;
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

        KeyValuePair<string, int> Up(KeyValuePair<string, int> CurrentLocation)
        {
            var location = CurrentLocation;

            if(CurrentLocation.Value > 1)
            {
                location = new KeyValuePair<string, int>(CurrentLocation.Key, CurrentLocation.Value - 1);
            }

            return location;
        }

        KeyValuePair<string, int> Down(KeyValuePair<string, int> CurrentLocation)
        {
            var location = CurrentLocation;

            if (CurrentLocation.Value < 5)
            {
                location = new KeyValuePair<string, int>(CurrentLocation.Key, CurrentLocation.Value + 1);
            }

            return location;
        }

        KeyValuePair<string, int> Left(KeyValuePair<string, int> CurrentLocation)
        {
            var location = CurrentLocation;
            char[] letter = location.Key.ToCharArray();

            if (!letter[0].Equals("A"))
            {
                char nextChar = (char)(((int)letter[0]) - 1);

                location = new KeyValuePair<string, int>(nextChar.ToString(), CurrentLocation.Value);
            }

            return location;
        }

        KeyValuePair<string, int> Right(KeyValuePair<string, int> CurrentLocation)
        {
            var location = CurrentLocation;
            char[] letter = location.Key.ToCharArray();

            if (!letter[0].Equals("H"))
            {
                char nextChar = (char)(((int)letter[0]) + 1);
                location = new KeyValuePair<string, int>(nextChar.ToString(), CurrentLocation.Value);

            }

           
            return location;
        }
    }
}
