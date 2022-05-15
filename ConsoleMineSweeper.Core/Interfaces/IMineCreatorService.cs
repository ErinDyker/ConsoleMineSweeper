using System;
using System.Collections.Generic;
using ConsoleMineSweeper.Core.Enum;
using ConsoleMineSweeper.Core.Models;

namespace ConsoleMineSweeper.Core.Interfaces
{
    public interface IMineCreatorService
    {
        List<Mine> CreateMines(GameDifficulty difficulty);
    }
}
