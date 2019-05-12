using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuPuzzle.Strategies
{
    interface SudokuStrategy
    {
        int[,] Solve(int[,] sudokuBoard);
    }
}
