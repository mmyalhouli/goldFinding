using System;

namespace GoldFinding
{
    class GoldFinding
    {
        public string[,] settingGoldandBomb(string [,] gAndb)
        {
            int row, colum , row1, colum1;
            Random gold = new Random(); // generating Random index for gold
            Random bomb = new Random(); // generating index for bomb placement
            String[,] goldandBomb = new string[8, 8];
            for (int x = 0; x <= 7; x++)
            {
                for (int y = 0; y <= 7; y++)
                {
                    goldandBomb[x, y] = " "; // initializing with blanck spaces
                }
            }

            for (int z = 0; z < 5; z++)
            {
                 row = gold.Next(0, 7); //for x-coordinate
                 colum = gold.Next(0, 7); //for y-coordinate
                 goldandBomb[row, colum] = "G"; // placing gold on random locations
               //  Console.WriteLine( row + " " + colum);
                
           }

            row1 =bomb.Next(0, 7); //for x-coordinate
            colum1 = bomb.Next(0, 7); //for y-coordinate
            goldandBomb[row1,colum1] = "B";

            return goldandBomb;
       }
        /*  <----------------END of the function HERE-------------------------------> */
        public int goldCheck(string [,] gAndb2)
        {
            string val;
            int score = 0;
            int guess = 5;

            do
            {
                guess--;
                Console.Write(" Enter x coordinate : ");
                int xCo = int.Parse(Console.ReadLine());
               // taking input from user for x-coordinate.
                if (xCo == 0)               // Handling array index which start from 0, 
                   xCo = xCo - 0;           // starting index is 0 , so do nothing
                else                        // but if
                    xCo = xCo - 1;          // index is other than 0 , thn less 1 from it.
                Console.WriteLine();
                Console.Write(" Enter y coordinate : ");
                int yCo = int.Parse(Console.ReadLine());
                // taking input from user for y-coordinate
                if (yCo == 0)                // Handling array index which start from 0, 
                    yCo = yCo - 0;
                else
                    yCo = yCo - 1;
                Console.WriteLine();
               
                val = gAndb2[xCo, yCo];
                if (string.Compare(val,"G") == 0) {
                    score++;
                    Console.WriteLine("You Found Gold !! , you got and extra move ");
                    guess = guess + 1;// extra move , additional task
                    Console.WriteLine();
                    gAndb2[xCo, yCo] = "F";
                }
                if (string.Compare(val, "B") == 0) {
                    Console.WriteLine(" Game OVER  , bomb is here ");
                    Console.WriteLine();
                    break;
                }
                if (string.Compare(val, " ") == 0) {
                    Console.WriteLine("Too Bad !! you have " + guess + " more to go ");
                    Console.WriteLine();
                }
              
            } while (guess > 0);

          
          
            return score;
        
        }

        /*  <----------------END of the function HERE-------------------------------> */
        public void disply(string [,] loadedArray )
        {
            Console.WriteLine();
            Console.WriteLine("     1  2  3  4  5  6  7  8");
            Console.WriteLine("-----------------------------------");
            for (int y = 0; y <= 7; y++)
            {
                Console.Write(" ");
                Console.Write(y+1  + " | ");
                for (int z = 0; z <= 7; z++)
                {
                    Console.Write(loadedArray[y, z] + "  ");

                }
                Console.WriteLine();
            }
        }
     /*  <----------------END of the function HERE-------------------------------> */

        static void Main()
        {
            string input, opt = "y";
            const int rowSize = 8, colSize = 8;// constant integar declare
            // initializing the array with '?' (hidden board)
            String[,] hiddenBoard = new string[rowSize, colSize];
            Console.WriteLine();
            Console.WriteLine("     1  2  3  4  5  6  7  8");
            Console.WriteLine("-----------------------------------");
            for (int x = 0; x < colSize; x++)
            {
                Console.Write(" ");
                Console.Write(  x+1 +" | ");
                for (int y = 0; y < rowSize; y++)
                {
                    hiddenBoard[x, y] = "?"; // Assigning Values to the hiddenBoard
                    Console.Write(hiddenBoard[x,y] + "  " ); // Displaying the hidden board
                }
                    Console.WriteLine();
            }
             Console.WriteLine("  ----------------------------------- ");
             Console.WriteLine(" * *  ***************************  * *");
             Console.WriteLine(" * *          Find GOLD            * *");
             Console.WriteLine(" * *     You have 5 guesses,       * *");
             Console.WriteLine(" * *      5 pieces of Gold         * *");
             Console.WriteLine(" * *        And 1 Bomb             * *");
             Console.WriteLine(" * *        GOOD LUCK!             * *");
             Console.WriteLine(" * *  ***************************  * *");
  
        do
            {
              GoldFinding obj = new GoldFinding();// creatin object for function call
              String[,] GandB = obj.settingGoldandBomb(hiddenBoard);// Function Call
              int score= obj.goldCheck(GandB);       //Function Call
              Console.WriteLine(" You Earn " + score + " points");
              Console.WriteLine(" Better Luck Next Time !! ");
              Console.WriteLine(" Here is your board ");

              obj.disply(GandB);  // parsing Array to the function

              Console.WriteLine("  Enter y to play again ");
              input= Console.ReadLine();
           } while (string.Compare(opt,input)==0);


            Console.ReadKey();
        }     // End Main( )
    }         // End class
}            // End namespace
