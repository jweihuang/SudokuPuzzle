using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuPuzzle.Utils
{
    class SudokuReader
    {
        public int[,] ReadFile(string filename)
        {
            int[,] sudokuBoard = new int[9, 9];
            try
            {
                var rows = File.ReadAllLines(filename);
                int i = 0;
                foreach(var row in rows)
                {
                    string[] elements = row.Split(',').Take(9).ToArray();
                    int j = 0;
                    foreach(var element in elements)
                    {
                        sudokuBoard[i, j] = element.Equals(" ") ? 0 : Convert.ToInt16(element);
                        j++;
                    }
                    i++;
                }
            }
            catch(Exception e)
            {
                throw new Exception("Something went wrong while reading the file." + e.Message);
            }

            return sudokuBoard;

        }
    }
}
