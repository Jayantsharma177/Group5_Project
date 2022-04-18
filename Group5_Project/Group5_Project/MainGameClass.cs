using System;
namespace Group5_Project
{
    public class MainGameClass
    {
        // constants for no of rows and columns
        const int TOTALROWS = 6, TOTALCOLS = 7;

        //declaring array for gridBox
        private char[,] gridBox;

        //Constants for blank,players
        const char BLANK = '#', SYMBOL_PLAYER1 = 'X', SYMBOL_PLAYER2 = 'O';

        //variable to count no of pieces dropped

        //variables for total pieces dropped
        int totalDroppedPieces;

        //declaring main class for the game
        public MainGameClass()
        {
            //allocate memory to the grid box
            gridBox = new char[TOTALROWS, TOTALCOLS];

            //set all grid columns to blank
            for (int y = 0; y < TOTALROWS; y++)
                for (int x = 0; x < TOTALCOLS; x++)
                    gridBox[y, x] = BLANK;
        }

        //method to show the grid on the screen
        public void ShowGrid()
        {
            Console.WriteLine("Connect 4 Game - Developed by :Jashanpreet Kaur Gill\n");
            Console.WriteLine("Connect 4 Game - Developed by :Jayant Sharma\n");
            Console.WriteLine("Connect 4 Game - Developed by :Gulya Hasanova\n");
            Console.WriteLine("-----------------------");
            for (int y = 0; y < TOTALROWS; y++)
            {
                Console.Write("|");
                for (int x = 0; x < TOTALCOLS; x++)
                {

                    Console.Write(" " + gridBox[y, x].ToString() + " ");

                }
                Console.Write("|");
                Console.Write('\n');
            }
            Console.WriteLine("-----------------------");
            for (int i = 1; i <= TOTALCOLS; i++) Console.Write("  " + i.ToString());
            Console.WriteLine("\n");
        }

        // method to display the player played colNo
        // the player symbol will be displayed in the selected colNo
        public bool DropDisc(char player, int colNo)
        {
            colNo--;
            //check if column is blank if not return back and display the message
            if (gridBox[0, colNo] != BLANK)
                return false;

            //display the symbol in topmost available column in the particular row
            for (int y = 0; y < TOTALROWS; y++)
            {
                if ((y == TOTALROWS - 1) || (gridBox[y + 1, colNo] != BLANK))
                {
                    gridBox[y, colNo] = player;
                    break;
                }
            }
            //increase the no of total dropped pieces
            totalDroppedPieces++;
            return true;
        }

        //method to check whether any player is winner
        // it will check rows wise, then column wise and then diagonal
        // if at any place 4 symbols are together it will declare the winner
        public bool CheckWin(char player)
        {
            //Check row wise
            try
            {
                for (int y = 0; y < TOTALROWS; y++)
                    for (int x = 0; x < 4; x++)
                        if (gridBox[y, x] == player && gridBox[y, x + 1] == player)
                            if (gridBox[y, x + 2] == player && gridBox[y, x + 3] == player)
                                return true;
            }
            catch (Exception e1)
            {
                Console.WriteLine("Error");
            }
            // Check Column Wise

            for (int y = 0; y < 3; y++)
                for (int x = 0; x < TOTALCOLS; x++)
                    if (gridBox[y, x] == player && gridBox[y + 1, x] == player)
                        if (gridBox[y + 2, x] == player && gridBox[y + 3, x] == player)
                            return true;

            // Check diagonals

            for (int y = 0; y < 3; y++)
            {
                for (int x = 0; x < TOTALCOLS; x++)
                {

                    if (gridBox[y, x] == player)
                    {

                        // check left diagonals:
                        try
                        {
                            if (gridBox[y + 1, x - 1] == player)
                            {
                                if (gridBox[y + 2, x - 2] == player)
                                    if (gridBox[y + 3, x - 3] == player)
                                        return true;
                            }
                        }
                        catch (IndexOutOfRangeException) { }

                        // check right side diagonals
                        try
                        {
                            if (gridBox[y + 1, x + 1] == player)
                            {
                                if (gridBox[y + 2, x + 2] == player)
                                    if (gridBox[y + 3, x + 3] == player)
                                        return true;
                            }
                        }
                        catch (IndexOutOfRangeException) { }
                    }
                }
            }

            return false;
        }

        public bool IsGridFull()
        {
            return totalDroppedPieces >= TOTALROWS * TOTALCOLS;
        }
    }
}
