using System;
using System.Collections.Generic;
using ConsoleMineSweeper.Core.Enum;
using ConsoleMineSweeper.Core.Models;

namespace ConsoleMineSweeper.Core.Interfaces
{
    public interface IMovementController
    {
        Coordinate Move(MovementDirection direction, Coordinate currentLocation);
        object? ParseDirection(string move);
    }
}
