using System;
using System.Collections.Generic;
using ConsoleMineSweeper.Core.Enum;

namespace ConsoleMineSweeper.Core.Interfaces
{
    public interface IMovementController
    {
        KeyValuePair<string, int> Move(MovementDirection direction, KeyValuePair<string, int> currentLocation);
    }
}
