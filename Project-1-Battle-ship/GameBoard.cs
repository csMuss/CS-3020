using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class Gamboard
    {

        public Gamboard() { }

        Ship shipAsset = new Ship();

        char[,] boardChars = new char[10, 10];
        char[,] cheatChars = new char[10, 10];

        private bool isModeActive = false; 

        private int shipHitCount = 0;
        private int shipCount = 0;
        public char[,] BoardChars
        {
            get { return boardChars; }
            set { boardChars = value; }
        }

        public char[,] CheatChars
        {
            get { return cheatChars; }
            set { cheatChars = value; }
        }

        public int ShipCount
        {
            get { return shipCount; }
            set { shipCount = value; }
        }

        public int ShipHitCount
        {
            get { return shipHitCount; }
            set { shipHitCount = value; }
        }
        public bool IsModeActive { get => isModeActive; set => isModeActive = value; }

        /// <summary>
        /// Fills the gameboard
        /// </summary>
        /// <param name="aChar">The character used to display</param>
        public void FillBoard(char aChar)
        {
            for (int row = 0; row < BoardChars.GetLength(0); row++)
            {
                for (int column = 0; column < BoardChars.GetLength(1); column++)
                {
                    BoardChars[row, column] = aChar;
                }
            }
        }
        /// <summary>
        /// Displays the end game screen
        /// </summary>
        public void displayEndGame()
        {
            Console.WriteLine("You won");
        }

        /// <summary>
        /// Displays the game board
        /// </summary>
        public void Display()
        {
            drawColumnIndicator(); // our column indicator

            for (int row = 0; row < BoardChars.GetLength(0); row++)
            {
                DrawLine();
                drawRowIndicator(row); // row indicator with increment for alphabet
                Console.Write("|");

                for (int column = 0; column < BoardChars.GetLength(1); column++)
                {
                    if (IsModeActive == true) // checks if it needs to show cheat board or game board
                    {
                        Console.Write($" {CheatChars[row, column]} |");

                    }
                    else
                    {
                        Console.Write($" {BoardChars[row, column]} |");
                    }

                }

                Console.WriteLine();

            }
            DrawLine();

            //Console.WriteLine("Ships hit: " + ShipHitCount);  DEBUG
            //Console.WriteLine("Ship count: " + ShipCount);

        }

        /// <summary>
        /// Draws a horazontal line
        /// </summary>
        private void DrawLine()
        {
            Console.Write("-");

            for (int dash = 0; dash < BoardChars.GetLength(1) * 4 + 3; dash++)
            {
                Console.Write("-");
            }

            Console.WriteLine();

        }
        /// <summary>
        /// draws the row indicator
        /// </summary>
        /// <param name="increment"> int for incrementing the chars based on UTP-16 </param>
        private void drawRowIndicator(int increment)
        {
            for (int rows = 0; rows < 1; rows++)
            {
                Console.Write($" {(char)(65 + increment)} ");
            }
        }
        /// <summary>
        /// Draws the column indicator
        /// </summary>
        private void drawColumnIndicator()
        {
            Console.Write("   "); // this is three whitespace chars
            Console.Write("|");
            for (int columns = 0; columns < BoardChars.GetLength(1); columns++)
            {
                Console.Write($" {columns} |");
            }

            Console.WriteLine();
        }

        /// <summary>
        /// places the ships randomly
        /// </summary>
        public void placeShips()
        {
            for (int row = 0; row < BoardChars.GetLength(0); row++)
            {
                for (int column = 0; column < BoardChars.GetLength(1); column++)
                {
                    // checks if spot is a ship and sets the cheat char to &
                    if (shipAsset.findShipCoords()[row, column] == -1)
                    {
                        CheatChars[row, column] = '&';
                        ShipCount++; // adds to the total ships
                    }
                    // else it sets cheat char to what boardchar has X, O or ~
                    else
                    {
                        CheatChars[row, column] = BoardChars[row, column];
                    }
                }
            }
        }

    }
}
