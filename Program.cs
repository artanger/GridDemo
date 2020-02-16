using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GridDemo
{
    public class Program
    {
        static void Main(string[] args)
        {
            int cols = 3;
            int rows = 3;
            var grid = new int[cols, rows];

            //FillInGridCustom(cols, rows, grid);

            ShowDefaultGrid(cols, rows, grid);

            var selected = FillInGridCheckNeighbors(cols, rows, grid);

            var colNumber = selected[0];
            var rowNumber = selected[1];

            if (colNumber > -1 || rowNumber > -1) // check that we have entered values without error
            {
                CheckNeighbors(cols, rows, grid, colNumber, rowNumber);

                ShowGridNeighbors(cols, rows, grid);
            }
            
            Console.ReadLine();
        }

        private static void FillInGridCustom(int cols, int rows, int[,] grid)
        {
            int r, c;
            for (r = 0; r < cols; r++)
            {
                for (c = 0; c < rows; c++)
                {
                    Console.Write("row&column - {1},{0}:", r, c);
                    grid[r, c] = Convert.ToInt32(Console.ReadLine());
                }
            }

            Console.WriteLine();
            Console.WriteLine("GRID");

            for (r = 0; r < cols; r++)
            {
                Console.WriteLine();
                for (c = 0; c < rows; c++)
                    Console.Write("{0}\t", grid[r, c]);
            }
        }

        private static void ShowDefaultGrid(int cols, int rows, int[,] grid)
        {
            for (var i = 0; i < cols; i++)
            {
                for (var j = 0; j < rows; j++)
                {
                    grid[i, j] = 0;
                }
            }

            Console.WriteLine("=================");
            Console.WriteLine("--- Empty Grid ---");
            Console.WriteLine("=================");
            ShowGrid(cols, rows, grid);
            Console.WriteLine();
            Console.WriteLine("=================");
            Console.WriteLine();
        }

        private static int[] FillInGridCheckNeighbors(int cols, int rows, int[,] grid)
        {
            var result = new int[] {-1, -1};

            Console.Write("Enter the Column Number: ");

            if (!int.TryParse(Console.ReadLine(), out var columnNumber))
            {
                Console.Write("Entered Column Number value is different from number.");
                ShowExitMessage();
                return result;
            }

            if (columnNumber >= cols)
            {
                Console.Write("Entered Column Number value is greater then array's size.");
                ShowExitMessage();
                return result;
            }

            Console.Write("Enter the Row Number: ");

            if (!int.TryParse(Console.ReadLine(), out var rowNumber))
            {
                Console.Write("Entered Row Number value is different from number.");
                ShowExitMessage();
                return result;
            }

            if (rowNumber >= rows)
            {
                Console.Write("Entered Row Number value is greater then array's size.");
                ShowExitMessage();
                return result;
            }

            grid[columnNumber, rowNumber] = 1; // set selected

            result = new int[] { columnNumber, rowNumber };

            return result;
        }

        private static void ShowGrid(int cols, int rows, int[,] grid)
        {
            for (var c = 0; c < cols; c++)
            {
                Console.WriteLine();
                for (var r = 0; r < rows; r++)
                {
                    Console.Write("{0}\t", grid[r, c]);
                }
            }
        }

        private static void ShowGridNeighbors(int cols, int rows, int[,] grid)
        {
            Console.WriteLine("");
            Console.WriteLine("=================");
            Console.WriteLine("--- Grid with neighbors ---");
            Console.WriteLine("=================");
            ShowGrid(cols, rows, grid);
            Console.WriteLine();
            Console.WriteLine("=================");
            Console.WriteLine();
        }

        private static void CheckNeighbors(int cols, int rows, int[,] grid, int columnNumber, int rowNumber)
        {
            if (columnNumber == 0 && rowNumber == 0) // is first column and is first row
            {
                grid[columnNumber + 1, rowNumber] = 2;
                grid[columnNumber, rowNumber + 1] = 2;
                grid[columnNumber + 1, rowNumber + 1] = 2;
            }
            else if (columnNumber == cols - 1 && rowNumber == 0) // is last column and is first row
            {
                grid[columnNumber - 1, rowNumber] = 2;
                grid[columnNumber - 1, rowNumber + 1] = 2;
                grid[columnNumber, rowNumber + 1] = 2;
            }
            else if (rowNumber == 0) // is not last and is not first column and is first row
            {
                grid[columnNumber - 1, rowNumber] = 2;
                grid[columnNumber - 1, rowNumber + 1] = 2;
                grid[columnNumber, rowNumber + 1] = 2;
                grid[columnNumber + 1, rowNumber] = 2;
                grid[columnNumber + 1, rowNumber + 1] = 2;
            }
            else if (columnNumber == 0 && rowNumber == rows - 1) // is first column and is last row
            {
                grid[columnNumber, rowNumber - 1] = 2;
                grid[columnNumber + 1, rowNumber - 1] = 2;
                grid[columnNumber + 1, rowNumber] = 2;
            }

        }

        private static void ShowExitMessage()
        {
            Console.Write("Please, rerun the application entering correct value.");
        }
    }
}
