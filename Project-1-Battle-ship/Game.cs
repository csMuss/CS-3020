using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Project
{
    /// <summary>
    ///  Creates and displays a char-based 2D gameboard
    /// </summary>
    public class Game
    {

        public Game() { }

        Gamboard board = new Gamboard();
        Ship shiplogic = new Ship();    

        // Starts the game and keeps it in the game loop until ships alive is false
        public void Start()
        {
            board.FillBoard('~');
            board.placeShips();

            while (areShipsAlive() == true)
            {
                shiplogic.findShipCoords();
                getUserInput(); // display is called in this function
            }

            board.Display();
            board.displayEndGame();
        }
 
        /// <summary>
        /// Checks if ship are alive based on ship count vs hit count
        /// </summary>
        /// <returns> returns true or false based on if the game is over </returns>
        private bool areShipsAlive()
        {
            bool continueGame = true;
            // checks if the ship hit count is less than the ship count
            // continues the game if its true
            if (board.ShipHitCount < (board.ShipCount * 2))
            {
                continueGame = true;
            }
            else
            {
                continueGame = false;
            }

            return continueGame;
        }
        /// <summary>
        /// gets and parses the users input and determines if it is valid or not, will ask the user to re-enter the combination if its invalid
        /// </summary>
        private void getUserInput()
        {
            string userInput = "H";
            int[,] parsedCoords = new int[1, 1];
            bool validInput = false;

            Console.Clear();
            board.Display();

            while (validInput == false)
            {
                Console.Write("Input the coordinates in row then column order (ex: A5): ");
                userInput = Console.ReadLine();
                userInput = userInput.ToUpper();

                // validates the users input
                if (userInput != " " && userInput != null && userInput.Length == 2 && inputIsInRightOrder(userInput) && inputIsInBounds(userInput))
                {
                    validInput = true;
                }

                else if (userInput == "S") // checks to enable cheats
                {
                    toggleCheatMode(userInput);
                    Console.Clear();
                    board.Display();
                }
                // error message
                else
                {
                    Console.WriteLine($"Error {userInput} is not a valid input ");
                }
            }

            parseUserInput(userInput.ToUpper());
        }
        /// <summary>
        /// A dependancy for getUserInput checks if the input from the user is in the right order
        /// </summary>
        /// <param name="input"> string input from getUserInput </param>
        /// <returns> true or false based on order </returns>
        private bool inputIsInRightOrder(string input)
        {
            bool correctOrder = false;

            //checks if first is a char and then second is a number
            if (!Char.IsNumber(input[0]) && Char.IsNumber(input[1])) 
            {
                correctOrder = true;
            }
            else
            {
                correctOrder = false;
            }

            return correctOrder;
        }

        /// <summary>
        /// A dependancy for getUserInput checks if the alphabet chars are in bounds 
        /// </summary>
        /// <param name="input"> string input from getUserInput </param>
        /// <returns> true or false based on the alphabet used </returns>
        private bool inputIsInBounds(string input)
        {
            bool inBounds = false;
            // checks if the char is between a and j
            if ((input[0] - 65) >= 0 && (input[0] - 65) <= 9)
            {
                inBounds = true;
            }
            else
            {
                inBounds = false;
            }

            return inBounds;
        }

        /// <summary>
        /// parses the users input assings the input to 1 for the algorithm to know that a player placed that
        /// also sets boardchars and cheatchars to X or O depending on hit or miss method
        /// </summary>
        /// <param name="input"> input from getUserInput </param>
        private void parseUserInput(string input)
        {
            int[,] parse = new int[10, 10];

            parse[0, 0] = input[0] - 65; // char math to get the integer value
            parse[0, 1] = input[1] - 48; // char math to get the integer value from the int

            int row = parse[0, 0];
            int column = parse[0, 1];

            parse[row, column] = 1; // sets value of user choice to 1

            //Console.WriteLine("X: " + row + " Y: " + column); DEBUG

            board.BoardChars[row, column] = isHitOrMiss(parse, row, column); // sets the board chars to the X or O depending on hit or miss
            board.CheatChars[row, column] = isHitOrMiss(parse, row, column); // sets the cheat chars to the X or O depending on hit or miss
        }
        /// <summary>
        /// a dependancy for getUserInput toggles the cheat mode
        /// </summary>
        /// <param name="input"> string input from getUserInput </param>
        /// <returns> returns true if user inputs 's' </returns>
        private bool toggleCheatMode(string input)
        {

            if (input == "S") // toggles cheat mode with cheat chars
            {
                board.IsModeActive = !board.IsModeActive;
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Cheats " + board.IsModeActive);
                Console.ForegroundColor = ConsoleColor.Gray;
            }

            return board.IsModeActive;
        }
        /// <summary>
        /// Checks if the spot the player chooses is a hit or a miss
        /// </summary>
        /// <param name="coords"> a 2d array of coords checking for 1 if that is a player selected position </param>
        /// <param name="row"> gets the row co</param>
        /// <param name="column"></param>
        /// <returns></returns>
        private char isHitOrMiss(int[,] coords, int row, int column)
        {
            char hitOrMiss = 'X'; // miss
            // checks if the user coords is = 1 indicating the user picking this spot and that
            // the findship function is -1 indicating that there is a boat piece there
            if (coords[row, column] == 1 && shiplogic.findShipCoords()[row, column] == -1)
            {
                hitOrMiss = 'O';
                board.ShipHitCount++; // increments ship hits
            }
            else
            {
                hitOrMiss = 'X';
            }

            //shipHitCount = shipHitCount - 1;

            return hitOrMiss;
        }

    }

}
