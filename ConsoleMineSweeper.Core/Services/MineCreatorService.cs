using System;
using System.Collections.Generic;
using ConsoleMineSweeper.Core.Enum;
using ConsoleMineSweeper.Core.Interfaces;
using ConsoleMineSweeper.Core.Models;

namespace ConsoleMineSweeper.Core.Services
{
    public class MineCreatorService : IMineCreatorService
    {

        /// <summary>
        /// Creates the number of mines needed based on the difficulty level selected
        /// </summary>
        /// <param name="difficulty"></param>
        /// <returns></returns>
        public List<Mine> CreateMines(GameDifficulty difficulty)
        {
            List<Mine> mines = new List<Mine>();
            int mineCount = 0;

            switch (difficulty)
            {
                case GameDifficulty.Easy:
                    mineCount = 2;
                    break;
                case GameDifficulty.Medium:
                    mineCount = 10;
                    break;
                case GameDifficulty.Hard:
                    mineCount = 25;
                    break;
                case GameDifficulty.Impossible:
                    mineCount = 50;
                    break;
            }

            for (int i = 0; i < mineCount; i++)
            {
                mines.Add(new Mine() { Location = RandomisedLocation() });
            }

            return mines;
        }

        /// <summary>
        /// Creates a randomly generated location
        /// </summary>
        /// <returns></returns>
        KeyValuePair<string, int> RandomisedLocation()
        {
            Random rnd = new Random();
            char randomChar = (char)rnd.Next('a', 'h');
            int randomInt = (int)rnd.Next(1, 8);

            string key = randomChar.ToString();

            return new KeyValuePair<string, int>(key, randomInt);


        }


    }
}
