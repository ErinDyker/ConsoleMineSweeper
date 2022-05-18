using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ConsoleMineSweeper.Core.Enum;
using ConsoleMineSweeper.Core.Interfaces;
using ConsoleMineSweeper.Core.Models;

namespace ConsoleMineSweeper.Core
{
    public class BaseGame
    {
        IMineCreatorService _mineCreatorService;
        IMovementController _movementController;
        IStringInputService _stringInput;

        public BaseGame(IMineCreatorService mineCreator, IMovementController movementController, IStringInputService stringInput)
        {
            _mineCreatorService = mineCreator;
            _movementController = movementController;
            _stringInput = stringInput;
        }

        public Player Player { get; set; }


        /// <summary>
        /// Welcome Dialog and New Game Selector
        /// </summary>
        public void  Initialise()
        {

            _stringInput.WriteString("WELCOME TO MINESWEEPER");
            _stringInput.WriteString("NEW GAME? Y/N");

            string newGame = _stringInput.GetStringInput();

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
            bool parsedDifficulty = false;
            object difficulty = GameDifficulty.Easy;

            while (!parsedDifficulty)
            {
                _stringInput.WriteString("SELECT DIFFICULTY: EASY | MEDIUM | HARD | IMPOSSIBLE");

                string difficultySelection = _stringInput.GetStringInput();

                 parsedDifficulty = GameDifficulty.TryParse(typeof(GameDifficulty), difficultySelection, true, out difficulty);

                if (difficulty == null) _stringInput.WriteString("INPUT UNRECOGNISED, TRY AGAIN");
               
            }

            _stringInput.WriteString("GOODLUCK");
            _stringInput.WriteString("_______________________________________________");
            _stringInput.WriteString("                                               ");

            NewGame((GameDifficulty)difficulty);
        }

        /// <summary>
        /// Starts a new game using the provided difficulty level
        /// </summary>
        /// <param name="difficulty"></param>
        public void NewGame(GameDifficulty difficulty)
        {
            Player = new Player();
            //Player starts mid left
            Player.CurrentPosition = new Coordinate() { XPosition = "A", YPosition = 3 };

            //reset game settings
            var mines = _mineCreatorService.CreateMines(difficulty);
            int moveCount = 0;
            
            var lives = Player.Lives = 5;

            while (lives > 0)
            {
                bool parsedMovement = false;
                object movement = null;

                while (movement == null)
                {
                    _stringInput.WriteString("Select Direction: UP | DOWN | LEFT | RIGHT");

                    string move = _stringInput.GetStringInput();

                    movement = _movementController.ParseDirection(move);

                    if (movement == null) _stringInput.WriteString("INPUT UNRECOGNISED, TRY AGAIN");
                  
                    
                }

                Player.CurrentPosition = _movementController.Move((MovementDirection)movement, Player.CurrentPosition);

                _stringInput.WriteString("Moved to: " + Player.CurrentPosition.LocationString);
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


        /// <summary>
        /// Resets the player's position to the starting point after losing a life
        /// </summary>
        /// <param name="lives"></param>
        public void ResetPosition(int lives)
        {
            _stringInput.WriteString("                                               ");
            _stringInput.WriteString("BANG! YOU LANDED ON A MINE! ");
            _stringInput.WriteString("YOU LOST A LIFE, RETURNING TO THE START ");
            _stringInput.WriteString("LIVES LEFT: " + lives.ToString());
            _stringInput.WriteString("                                               ");

            Player.CurrentPosition = new Coordinate() { XPosition = "A", YPosition = 3 };
        }

        /// <summary>
        /// Game over dialog generator
        /// </summary>
        public void GameOver()
        {
            _stringInput.WriteString("                                               ");
            _stringInput.WriteString("BANG! YOU LANDED ON A MINE! ");
            _stringInput.WriteString("BETTER LUCK NEXT TIME! ");
            _stringInput.WriteString("                                               ");
            _stringInput.WriteString("_______________________________________________");
            _stringInput.WriteString("                                               ");
            _stringInput.WriteString("PLAY AGAIN? Y/N ");

            string newGame = _stringInput.GetStringInput();

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
            _stringInput.WriteString("                                               ");
            _stringInput.WriteString("WINNER! YOU MADE IT ACROSS! ");
            _stringInput.WriteString("SCORE: "+ moves + " MOVES");
            _stringInput.WriteString("REMAINING LIVES: " + Player.Lives);
            _stringInput.WriteString("FINAL LOCATION: " + location.LocationString);
            _stringInput.WriteString("                                               ");
            _stringInput.WriteString("_______________________________________________");
            _stringInput.WriteString("                                               ");
            _stringInput.WriteString("PLAY AGAIN? Y/N ");

            string newGame = _stringInput.GetStringInput();

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



