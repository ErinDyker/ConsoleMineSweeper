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

            while(mineCount != mines.Count)
            { 
                var mine = new Mine() { Location = RandomisedLocation() };

                int duplicates = mines.FindAll(x => x.Location.LocationString == mine.Location.LocationString).Count;
                //check its not already been added before
                if(duplicates == 0) mines.Add(mine);
            }

            return mines;
        }

        /// <summary>
        /// Creates a randomly generated location
        /// </summary>
        /// <returns></returns>
       Coordinate RandomisedLocation()
        {
            Random rnd = new Random();

            //creates 64 possible places
            char randomChar = (char)rnd.Next('A', 'I');
            int randomInt = (int)rnd.Next(1, 9);

            string key = randomChar.ToString();

            return new Coordinate(){ XPosition = key, YPosition = randomInt};


        }


    }
}
