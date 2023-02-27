using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class Ship
    {
        public Ship() { }

        /// <summary>
        /// Finds the ship coordinates and assigns that spot -1 for the algorithm to know there is a boat there
        /// </summary>
        /// <returns> returns the locations of the ships </returns>
        public int[,] findShipCoords()
        {

            int[,] pos = new int[10, 10];
            int[] shipSizes = { 5, 4, 3, 3, 2, 2 };

            int numberOfShips = 6;
            int row = 0; // random row
            int col = 0; // random column

            Random rand = new Random();

            int orientation; // verticle or horazontal

            for (int top  = 0; top < numberOfShips; top++)
            {
                orientation = rand.Next(0,3);

                row = rand.Next(0, 10);
                col = rand.Next(0, 10);

                // if its even then the algorithm will pick a row to place it in 
                // all "ship positions" are set to -1 so the other computers know that in that spot there is a ship
                if (orientation % 2 != 0) 
                {
                    if (row - shipSizes[top] > 0) // if row - shipsize  is greater than 0 than it can place 
                    {
                        for (int i = 0; i < shipSizes[top]; i++)
                        {
                            pos[top,i] = -1;
                        }
                    }
                    else
                    {
                        for (int i = 0; i < shipSizes[top]; i++)
                        {
                            pos[top, i] = -1;
                        }
                    }
                }
                // orientation is odd so it will pick a column 
                else
                {
                    if (col - shipSizes[top] > 0) // if col - shipsize  is greater than 0 than it can place 
                    {
                        for (int i = 0; i < shipSizes[top]; i++)
                        {
                            pos[top, i] = -1;
                        }
                    }
                    else
                    {
                        for (int i = 0; i < shipSizes[top]; i++)
                        {
                            pos[top, i] = -1;
                        }
                    }
                }
            }

            // test array DEBUG

          /*pos[0, 6] = -1;
            pos[1, 6] = -1;
            pos[2, 6] = -1;
            pos[3, 6] = -1;
            pos[4, 6] = -1;

            pos[5, 0] = -1;
            pos[5, 1] = -1;
            pos[5, 2] = -1;
            pos[5, 3] = -1;

            pos[5, 9] = -1;
            pos[6, 9] = -1;
            pos[7, 9] = -1;

            pos[4, 0] = -1;
            pos[4, 1] = -1;
            pos[4, 2] = -1;

            pos[8, 2] = -1;
            pos[8, 3] = -1;

            pos[0, 0] = -1;
            pos[0, 1] = -1;*/

            return pos;
        }
    }
}
