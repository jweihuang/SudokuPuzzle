using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuPuzzle.Utils
{
    class SudokuMapper
    {
        public SudokuMap Find(int rowIndex, int colIndex)
        {
            SudokuMap sudokuMap = new SudokuMap();

            if ((rowIndex >= 0 && rowIndex <= 2) && (colIndex >= 0 && colIndex <= 2)) 
            {
                sudokuMap.StartRow = 0;
                sudokuMap.StartColumn = 0;
            }
            else if ((rowIndex >= 0 && rowIndex <= 2) && (colIndex >= 3 && colIndex <= 5))
            {
                sudokuMap.StartRow = 0;
                sudokuMap.StartColumn = 3;
            }
            else if ((rowIndex >= 0 && rowIndex <= 2) && (colIndex >= 6 && colIndex <= 8))
            {
                sudokuMap.StartRow = 0;
                sudokuMap.StartColumn = 6;
            }
            else if ((rowIndex >= 3 && rowIndex <= 5) && (colIndex >= 0 && colIndex <= 2))
            {
                sudokuMap.StartRow = 3;
                sudokuMap.StartColumn = 0;
            }
            else if ((rowIndex >= 3 && rowIndex <= 5) && (colIndex >= 3 && colIndex <= 5))
            {
                sudokuMap.StartRow = 3;
                sudokuMap.StartColumn = 3;
            }
            else if ((rowIndex >= 3 && rowIndex <= 5) && (colIndex >= 6 && colIndex <= 8))
            {
                sudokuMap.StartRow = 3;
                sudokuMap.StartColumn = 6;
            }
            else if ((rowIndex >= 6 && rowIndex <= 8) && (colIndex >= 0 && colIndex <= 2))
            {
                sudokuMap.StartRow = 6;
                sudokuMap.StartColumn = 0;
            }
            else if ((rowIndex >= 6 && rowIndex <= 8) && (colIndex >= 3 && colIndex <= 5))
            {
                sudokuMap.StartRow = 6;
                sudokuMap.StartColumn = 3;
            }
            else if ((rowIndex >= 6 && rowIndex <= 8) && (colIndex >= 6 && colIndex <= 8))
            {
                sudokuMap.StartRow = 6;
                sudokuMap.StartColumn = 6;
            }

            return sudokuMap;
        }

    }
}