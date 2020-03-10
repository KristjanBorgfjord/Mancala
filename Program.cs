using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {

        public const int CUPVALUE = 4;
        public const int TOTALSEEDS = CUPVALUE * 12;
        public static bool[,,,,,,,,,,,] dp = new bool[5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5]; // dynamic programming.


        static void Main(string[] args)
        {
            int[] board = new int[] { 0, CUPVALUE, CUPVALUE, CUPVALUE, CUPVALUE, CUPVALUE, CUPVALUE, CUPVALUE, CUPVALUE, CUPVALUE, CUPVALUE, CUPVALUE, CUPVALUE };

            Console.WriteLine("Mancala \"Solution Space\" calulator by Kristjan Borgfjord. \nEstimated runtime is around 30 mins on a decent coomputer.\nPress Enter to start.");
            Console.ReadLine(); 
            Console.WriteLine("Starting...");

            recurse(board, "");

            Console.WriteLine("Program Complete");
        }


        public static int recurse(int[] input, String s)
        {
            int[] currBoard = new int[13];

            input.CopyTo(currBoard, 0);
            int currPos = 0;
            int handful = 0;
            int startPos = 1;
            int ret = -1;


            while (startPos < 13 && currBoard[0] != TOTALSEEDS && ret != 0)
            {
                handful = currBoard[startPos];
                currBoard[startPos] = 0;
                currPos = startPos % 13;

                while (handful != 0)
                {
                    currPos = (currPos + 1) % 13;
                    currBoard[currPos]++;
                    handful--;

                    if (handful == 0 && currBoard[currPos] != 1 && currPos != 0)
                    {
                        handful = currBoard[currPos];
                        currBoard[currPos] = 0;
                    }

                }

                if (currPos == 0 && currBoard != null)
                {
                    if (currBoard[1] < 5 && currBoard[2] < 5 && currBoard[3] < 5 && currBoard[4] < 5
                            && currBoard[5] < 5 && currBoard[6] < 5 && currBoard[7] < 5 && currBoard[8] < 5
                            && currBoard[9] < 5 && currBoard[10] < 5 && currBoard[11] < 5 && currBoard[12] < 5)
                    {
                        if (dp[currBoard[1], currBoard[2], currBoard[3], currBoard[4], currBoard[5], currBoard[6], currBoard[7], currBoard[8], currBoard[9], currBoard[10], currBoard[11], currBoard[12]] == false)
                        {
                            dp[currBoard[1], currBoard[2], currBoard[3], currBoard[4], currBoard[5], currBoard[6], currBoard[7], currBoard[8], currBoard[9], currBoard[10], currBoard[11], currBoard[12]] = true;
                        }

                        ret = recurse(currBoard, s + startPos + ", ");
                    }
                    else
                    {
                        ret = recurse(currBoard, s + startPos + ", ");
                    }

                }


                startPos++;
                if (startPos < 13 && currBoard[0] != TOTALSEEDS && ret == -1)
                {
                    input.CopyTo(currBoard, 0);
                }
            }


            if (currBoard[0] == TOTALSEEDS)
            { 
                Console.WriteLine(s.Substring(0,s.Length-2));
                Console.WriteLine("-------------------------------------------------------------");

                return startPos; //stop

            }
            else
            { 
                //failed
                return -1;
            }


        }
    }
}
