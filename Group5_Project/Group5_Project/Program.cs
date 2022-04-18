using System;

namespace Group5_Project
{
    class Program
    {
        static void Main(string[] args)
        {
            //Welcome Message
            Console.WriteLine("Welcome to Connect 4 Game");
            Console.WriteLine("-------------------------");
            Console.WriteLine("Developed by : Jashanpreet Kaur Gill\n");
            Console.WriteLine("Developed by : Jayant Sharma\n");
            Console.WriteLine("Developed by : Gulya Hasanova\n");

            //asking for mode of game
            int mode = 1;
            int count = 0;
            Console.WriteLine("Select the Game Mode\n");
            do
            {

                Console.Write("1 for Two Player Mode\n0 for Single Player Mode\n\nEnter your Choice:");
                mode = Convert.ToInt32(Console.ReadLine());

                if (!(mode == 0 || mode == 1)) Console.Write("Not a Valid Value, Try Again....\n");

            } while (!(mode == 0 || mode == 1));
            //variable to repeat the loop
            bool state = true;

            //creating object from Main Game class
            MainGameClass game = new MainGameClass();

            //setting the first player to play
            char playerNo = 'X';

            //variable to accept the column number
            int selectColByPlayer;


            bool userInputState;

            //loop till the time there is win or tie
            while (state)
            {
                //clear the console and show grid again
                System.Console.Clear();
                game.ShowGrid();

                //loop to accept a number within limit otherwise loop is repeated
                do
                {
                    userInputState = true;

                    //prompting the user to enter value
                    Console.Write("\nPlayer " + playerNo + " Enter your Column Number:");

                    if (Int32.TryParse(Console.ReadLine(), out selectColByPlayer))
                    {
                        if (1 <= selectColByPlayer && selectColByPlayer <= 7)
                        {
                            if (game.DropDisc(playerNo, selectColByPlayer))
                            {
                                userInputState = false;
                            }
                            else
                            {
                                System.Console.Clear();
                                game.ShowGrid();
                                Console.WriteLine("\nSorry, You cannot player in the Column because it is already full.");
                            }
                        }
                        else
                        {
                            System.Console.Clear();
                            game.ShowGrid();
                            Console.WriteLine("\nSorry, Allowed is within 1 to 7 values only");
                        }
                    }
                    else
                    {
                        System.Console.Clear();
                        game.ShowGrid();
                        Console.WriteLine("\nSorry, Enter only numeric value.");
                    }
                } while (userInputState);

                //calling the check winner function
                if (game.CheckWin(playerNo))
                {
                    System.Console.Clear();
                    game.ShowGrid();
                    Console.Write("\nCongratulations!!!, Player " + playerNo + " is Winner");
                    Console.WriteLine("\nPress Any Key to Continue....");
                    state = false;
                }
                //checking if the grid if full and no player is winner
                else if (game.IsGridFull())
                {
                    System.Console.Clear();
                    game.ShowGrid();
                    Console.WriteLine("\nThere is Tie, No Player wins.");
                    Console.WriteLine("\nPress Any Key to Continue....");
                    state = false;
                }
                else
                {
                    if (mode == 1)
                    {
                        playerNo = playerNo == 'X' ? 'O' : 'X';
                    }
                    else
                    {
                        if (playerNo == 'X')
                        {
                            playerNo = 'O';
                            //calling the check winner function

                            Random random = new Random();
                            count++;
                            if (count % 2 == 0 || count % 5 == 0)
                                selectColByPlayer = random.Next(1, 7);

                            game.DropDisc(playerNo, selectColByPlayer);

                            game.ShowGrid();

                            playerNo = 'X';
                        }
                    }
                }
            }

            Console.ReadKey();
        }
    }
}
