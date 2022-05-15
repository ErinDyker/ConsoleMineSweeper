using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ConsoleMineSweeper.Core.Enum;
using ConsoleMineSweeper.Core.Interfaces;
using ConsoleMineSweeper.Core.Models;

namespace ConsoleMineSweeper.Core.Services
{
    public class BaseGame
    {
        IMineCreatorService _mineCreatorService;
        IMovementController _movementController;

        public BaseGame(IMineCreatorService mineCreator, IMovementController movementController)
        {
            _mineCreatorService = mineCreator;
            _movementController = movementController;
        }

        /// <summary>
        /// Welcome Dialog and New Game Selector
        /// </summary>
        public void  Initialise()
        {

            Console.WriteLine("WELCOME TO MINESWEEPER");
            Console.WriteLine("NEW GAME? Y/N");

            string newGame = Console.ReadLine();

            if (newGame.Equals("Y") || newGame.Equals("y"))
            {
                DifficultySelector();

            }
            else
            {

            }
        }

        /// <summary>
        /// Allows the user to select difficulty before starting a new game
        /// </summary>
        public void DifficultySelector()
        {
            Console.WriteLine("SELECT DIFFICULTY: EASY | MEDIUM | HARD | IMPOSSIBLE");

            string difficultySelection = Console.ReadLine();

            var parsedDifficulty = GameDifficulty.TryParse(typeof(GameDifficulty), difficultySelection, true, out object difficulty);

            if (!parsedDifficulty)
            {
                Console.WriteLine("INPUT UNRECOGNISED, TRY AGAIN");
                DifficultySelector();
            }

            Console.WriteLine("GOODLUCK");
            Console.WriteLine("_______________________________________________");
            Console.WriteLine("                                               ");

            NewGame((GameDifficulty)difficulty);
        }

        /// <summary>
        /// Starts a new game using the provided difficulty level
        /// </summary>
        /// <param name="difficulty"></param>
        public void NewGame(GameDifficulty difficulty)
        {

            var board = new Board();
            var mines = _mineCreatorService.CreateMines(difficulty);
            int moveCount = 0;

            bool isSafe = true;
            KeyValuePair<string, int> playerLocation = new KeyValuePair<string, int>("A", 3);

            while (isSafe)
            {
                bool parsedMovement = false;
                MovementDirection movementDirection = MovementDirection.Up;

                while (!parsedMovement)
                {
                    Console.WriteLine("Select Direction: UP | DOWN | LEFT | RIGHT");

                    string move = Console.ReadLine();

                    parsedMovement = MovementDirection.TryParse(typeof(MovementDirection), move, true, out object movement);

                    movementDirection = (MovementDirection)movement;
                }

                playerLocation = _movementController.Move(movementDirection, playerLocation);

                Console.WriteLine("Moved to: " + playerLocation);
                moveCount++;

                foreach (Mine mine in mines)
                {
                    if (playerLocation.Equals(mine.Location)) isSafe = false;
                    break;
                }

                if(playerLocation.Key.Equals("H"))
                {
                    WinScenario(moveCount, playerLocation);
                }


            }

            GameOver();

        }

        /// <summary>
        /// Game over dialog generator
        /// </summary>
        public void GameOver()
        {
            Console.WriteLine("                                               ");
            Console.WriteLine("BANG! YOU LANDED ON A MINE! ");
            Console.WriteLine("BETTER LUCK NEXT TIME! ");
            Console.WriteLine("                                               ");
            Console.WriteLine("_______________________________________________");
            Console.WriteLine("                                               ");
            Console.WriteLine("PLAY AGAIN? Y/N ");
            DifficultySelector();
        }

        /// <summary>
        /// Win Scenario dialog generator, shows the number of moves taken and the final location on the board
        /// </summary>
        /// <param name="moves"></param>
        /// <param name="location"></param>
        public void WinScenario(int moves, KeyValuePair<string, int> location)
        {
            Console.WriteLine("                                               ");
            Console.WriteLine("WINNER! YOU MADE IT ACROSS! ");
            Console.WriteLine("SCORE: "+ moves + " MOVES");
            Console.WriteLine("FINAL LOCATION: " + location.ToString());
            Console.WriteLine("                                               ");
            Console.WriteLine("_______________________________________________");
            Console.WriteLine("                                               ");
            Console.WriteLine("PLAY AGAIN? Y/N ");
            DifficultySelector();
        }


    }
}

// - - - - - - - -
// - - - - - - - -
// - - - - - - - -
// - - - - - - - -
// - - - - - - - -
// - - - - - - - -
// - - - - - - - -
// - - - - - - - -


