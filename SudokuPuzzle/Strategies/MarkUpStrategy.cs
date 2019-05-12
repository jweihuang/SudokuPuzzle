using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SudokuPuzzle.Utils;

namespace SudokuPuzzle.Strategies
{
    class MarkUpStrategy:SudokuStrategy
    {
        private readonly SudokuMapper _sudokuMapper;

        public MarkUpStrategy(SudokuMapper sudokuMapper)
        {
            _sudokuMapper = sudokuMapper;
        }

        public int[,] Solve(int[,] sudokuBoard)
        {
            for (int i = 0; i < sudokuBoard.GetLength(0); i++)
            {
                for (int j = 0; j < sudokuBoard.GetLength(1); j++)
                {
                    if(sudokuBoard[i,j]==0 || sudokuBoard[i, j].ToString().Length > 1)
                    {
                        var possibilityInRowAndColumn = GetPossibilityInRowAndColumn(sudokuBoard, i, j);
                        var possibilityInBlock = GetPossibilityInBlock(sudokuBoard, i, j);
                        sudokuBoard[i, j] = GetPossibilityIntersection(possibilityInRowAndColumn, possibilityInBlock);
                    }
                }
            }
            return sudokuBoard;
        }

        private int GetPossibilityInRowAndColumn(int[,] sudokuBoard, int rowIndex, int colIndex)
        {
            int[] possibilities = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            for (int i = 0; i < 9; i++)
            {
                if (IsValidSingle(sudokuBoard[i, colIndex])) possibilities[sudokuBoard[i, colIndex] - 1] = 0;
            }
            for (int j = 0; j < 9; j++)
            {
                if (IsValidSingle(sudokuBoard[rowIndex, j])) possibilities[sudokuBoard[rowIndex, j] - 1] = 0;
            }

            return Convert.ToInt32(String.Join(string.Empty, possibilities.Select(p => p).Where(p => p != 0)));
        }

        private int GetPossibilityInBlock(int[,] sudokuBoard, int rowIndex, int colIndex)
        {
            int[] possibilities = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var sudokuMap = _sudokuMapper.Find(rowIndex, colIndex);

            for (int i = sudokuMap.StartRow; i < sudokuMap.StartRow + 2; i++)
            {
                for (int j = sudokuMap.StartColumn; j < sudokuMap.StartColumn + 2; j++)
                {
                    if (IsValidSingle(sudokuBoard[i, j]))
                    {
                        possibilities[sudokuBoard[i, j] - 1] = 0;
                    }
                }
            }
            return Convert.ToInt32(String.Join(string.Empty, possibilities.Select(p => p).Where(p => p != 0)));

        }

        private bool IsValidSingle(int digitInCell)
        {
            return digitInCell != 0 && digitInCell.ToString().Length == 1;
        }

        private int GetPossibilityIntersection(int possibilityInRowAndColumn, int possibilityInBlock)
        {
            var arrayInRowAndColumn = possibilityInRowAndColumn.ToString().ToCharArray();
            var arrayInBlock = possibilityInBlock.ToString().ToCharArray();
            var possibilityIntersection = arrayInRowAndColumn.Intersect(arrayInBlock);
            return Convert.ToInt32(string.Join(string.Empty, possibilityIntersection));
        }

    }
}
