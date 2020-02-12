using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] grid = new int[3, 3];
            grid[0, 0] = 1;
            grid[0, 1] = 2;
            grid[0, 2] = 3;
            grid[1, 0] = 4;
            grid[1, 1] = 5;
            grid[1, 2] = 6;
            grid[2, 0] = 7;
            grid[2, 1] = 8;
            grid[2, 2] = 9;
     
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(grid[i, j]);
                }
                Console.WriteLine();
               
            }
            Console.ReadLine();
        }
    }
}
