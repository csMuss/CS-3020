
/*
Details:
To accomplish this feat, you will need to implement a few classes:
Gameboard.cs
Contains a 10 x 10 grid.
Use an ‘X’ character for a miss.
Use an ‘O’ character for a hit.
Display ‘S’ character on spots containing ships when hacks are activated.
Has a display method.
Ship.cs
Contains a length property (between 2 and 5).
Variables bowX and bowY contain the location of the bow of the ship.
Variables sternX and sternY contain the location of the stern of the ship.
Game.cs
Runs game logic.
Contain 6 ships
2 of 2 length (Destroyers)
2 of 3 length (Submarines)
1 of 4 length (Battleship)
1 of 5 length (Carrier)
Randomly places the ships around the game board.
No ship can hang off the edge of the board.
When player sinks a ship, display appropriate message.
When player sinks all ships, ask them if they want to play again.
Program.cs
Contains the main
Only 2 commands in the main (or less!)
This isn’t the entirety of the contents of the classes, but it should be a good point to get you started. 
Remember to do pre-production to make sure you don’t waste time without a plan.

A postmortem is also a part of the assignment

In the postmortem, tell me about the trials and tribulations involved in completing the assignment. 
If you can, include an estimate of the total time it took to complete as well as how much time you spent 
in pre-production vs. production. Be honest with yourself, a little self-reflection is a great way to help you be a better programmer!

Submission:
Your project should be called <uccsusername>Battleship. Turn in the entire project folder zipped into a file called <uccsUsername>A1.zip. 
The assignment is due before class. The project must be able to compile and run or it will be given a zero. Coding style will also be a 
portion of the grade, so remember to comment, use proper capitalization, good variable names, etc.
 
 */

using Project;

Game board = new Game();
board.Start();
