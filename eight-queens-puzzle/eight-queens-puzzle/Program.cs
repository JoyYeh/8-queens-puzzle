using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eight_queens_puzzle
{
    public class Program
    {
        const int QSize = 8; //Queen Count

        public static void Main(string[] args)
        {
            Console.WriteLine("Print Eight-Queens-Puzzle：");

            //Queen's position in each row
            int[] Queen = new int[QSize];
            int p, x, i, j, d = 0;
            int res = 1;
            p = 0;
            Queen[0] = -1;

            while (true)
            {
                for (x = Queen[p] + 1; x < QSize; x++)
                {
                    for (i = 0; i < p; i++)
                    {
                        j = Queen[i];
                        d = p - i;
                        //Check if the new queen will attack each other with the previous queen
                        if ((j == x) || (j == x - d) || (j == x + d))
                            break;
                    }
                    if (i >= p)
                    {
                        //No attack
                        break;
                    }
                }

                //No suitable position
                if (x == QSize) 
                {
                    if (0 == p)
                    {
                        //Backtrack to the first row，break to finish
                        Console.WriteLine("\n==== Done ====");
                        break; 
                    }
                    //Backtrack
                    Queen[p] = -1;
                    p--;
                }
                else
                {
                    //Check Queen's position
                    Queen[p] = x;
                    //Next Queen
                    p++;
                    if (p < QSize)
                    {
                        Queen[p] = -1;
                    }
                    else
                    {
                        //Print all result
                        Console.WriteLine("\n" + $"==== Result {res++} ====");
                        for (i = 0; i < QSize; i++)
                        {
                            for (j = 0; j < QSize; j++)
                            {
                                if (Queen[i] == j)
                                {
                                    Console.Write('Q');
                                }
                                else
                                {
                                    Console.Write('.');
                                }
                            }
                            Console.WriteLine();
                        }
                        //Backtrack
                        p = QSize - 1;
                    }
                }
            }
        }
    }
}
