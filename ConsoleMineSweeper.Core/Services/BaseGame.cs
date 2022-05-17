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

        public Player Player { get; set; }


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
                //Close the game
               Environment.Exit(0);
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

           
            var mines = _mineCreatorService.CreateMines(difficulty);
            int moveCount = 0;
            Player = new Player();
            Player.CurrentPosition = new Coordinate() { XPosition = "A", YPosition = 3 };
            var lives = Player.Lives = 5;

            while (lives > 0)
            {
                bool parsedMovement = false;
                MovementDirection movementDirection = MovementDirection.Up;

                while (!parsedMovement)
                {
                    Console.WriteLine("Select Direction: UP | DOWN | LEFT | RIGHT");

                    string move = Console.ReadLine();

                    parsedMovement = MovementDirection.TryParse(typeof(MovementDirection), move, true, out object movement);

                    if(movement !=null) movementDirection = (MovementDirection)movement;
                }

                Player.CurrentPosition = _movementController.Move(movementDirection, Player.CurrentPosition);

                Console.WriteLine("Moved to: " + Player.CurrentPosition.LocationString);
                moveCount++;

                foreach (Mine mine in mines)
                {
                    if (Player.CurrentPosition.LocationString == mine.Location.LocationString)
                    {
                        lives--;
                        ResetPosition(lives);
                         break;
                    }
                   
                }

                if(Player.CurrentPosition.XPosition.Equals("H"))
                {
                    WinScenario(moveCount, Player.CurrentPosition);
                }
            }

            GameOver();

        }

        public void ResetPosition(int lives)
        {
            Console.WriteLine("                                               ");
            Console.WriteLine("BANG! YOU LANDED ON A MINE! ");
            Console.WriteLine("YOU LOST A LIFE, RETURNING TO THE START ");
            Console.WriteLine("LIVES LEFT: " + lives.ToString());
            Console.WriteLine("                                               ");

            Player.CurrentPosition = new Coordinate() { XPosition = "A", YPosition = 3 };
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

            string newGame = Console.ReadLine();

            if (newGame.Equals("Y") || newGame.Equals("y"))
            {
                DifficultySelector();
            }
            else
            {
                //Close the game
                Environment.Exit(0);
            }
        }

        /// <summary>
        /// Win Scenario dialog generator, shows the number of moves taken and the final location on the board
        /// </summary>
        /// <param name="moves"></param>
        /// <param name="location"></param>
        public void WinScenario(int moves, Coordinate location)
        {
            Console.WriteLine("                                               ");
            Console.WriteLine("WINNER! YOU MADE IT ACROSS! ");
            Console.WriteLine("SCORE: "+ moves + " MOVES");
            Console.WriteLine("REMAINING LIVES: " + Player.Lives);
            Console.WriteLine("FINAL LOCATION: " + location.LocationString);
            Console.WriteLine("                                               ");
            Console.WriteLine("_______________________________________________");
            Console.WriteLine("                                               ");
            Console.WriteLine("PLAY AGAIN? Y/N ");

            string newGame = Console.ReadLine();

            if (newGame.Equals("Y") || newGame.Equals("y"))
            {
                DifficultySelector();

            }
            else
            {
                //Close the game
                Environment.Exit(0);
            }
        }
    }
}



