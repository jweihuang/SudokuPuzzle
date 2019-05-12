using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SudokuPuzzle.Utils;

namespace SudokuPuzzle.Strategies
{
    class NakedPairsStrategy:SudokuStrategy
    {
        private readonly SudokuMapper _sudokuMapper;

        public NakedPairsStrategy(SudokuMapper sudokuMapper)
        {
            _sudokuMapper = sudokuMapper;
        }

        public int[,] Solve(int[,] sudokuBoard)
        {
            for (int i = 0; i < sudokuBoard.GetLength(0); i++)
            {
                for (int j = 0; j < sudokuBoard.GetLength(1); j++)
                {
                    RemoveNakedPairFromRow(sudokuBoard, i, j);
                    RemoveNakedPairFromColumn(sudokuBoard, i, j);
                    RemoveNakedPairFromBlock(sudokuBoard, i, j);

                }
            }
            return sudokuBoard;
        }

        private void RemoveNakedPairFromRow(int[,] sudokuBoard, int rowIndex, int colIndex)
        {
            if(!HasNakedPairInRow(sudokuBoard, rowIndex, colIndex))
            {
                return;
            }

            for (int j = 0; j < sudokuBoard.GetLength(1); j++)
            {
                if (sudokuBoard[rowIndex, j] != sudokuBoard[rowIndex, colIndex] && sudokuBoard[rowIndex, j].ToString().Length > 1)
                {
                    RemoveNakedPair(sudokuBoard, sudokuBoard[rowIndex, colIndex], rowIndex, j);
                }
            }
        }

        private bool HasNakedPairInRow(int[,] sudokuBoard, int rowIndex, int colIndex)
        {
            for (int j = 0; j < sudokuBoard.GetLength(1); j++)
            {
                if (colIndex!= j && IsNakedPair(sudokuBoard[rowIndex, j], sudokuBoard[rowIndex, colIndex]))
                {
                    return true;
                }
            }
            return false;
        }

        private void RemoveNakedPairFromColumn(int[,] sudokuBoard, int rowIndex, int colIndex)
        {
            if (!HasNakedPairInColumn(sudokuBoard, rowIndex, colIndex)) {
                return;
            }

            for (int i = 0; i < sudokuBoard.GetLength(0); i++)
            {
                if (sudokuBoard[i, colIndex] != sudokuBoard[rowIndex, colIndex] && sudokuBoard[i, colIndex].ToString().Length > 1)
                {
                    RemoveNakedPair(sudokuBoard, sudokuBoard[rowIndex, colIndex], i, colIndex);
                }
            }

        }

        private bool HasNakedPairInColumn(int[,] sudokuBoard, int rowIndex, int colIndex)
        {
            for (int i = 0; i < sudokuBoard.GetLength(0); i++)
            {
                if (rowIndex != i && IsNakedPair(sudokuBoard[i, colIndex], sudokuBoard[rowIndex, colIndex]))
                {
                    return true;
                }
            }

            return false;
        }

        private void RemoveNakedPairFromBlock(int[,] sudokuBoard, int rowIndex, int colIndex)
        {
            if (!HasNakedPairInBlock(sudokuBoard, rowIndex, colIndex)) return;

            var sudokuMap = _sudokuMapper.Find(rowIndex, colIndex);

            for (int i = sudokuMap.StartRow; i <= sudokuMap.StartRow + 2; i++)
            {
                for (int j = sudokuMap.StartColumn; j <= sudokuMap.StartColumn + 2; j++)
                {
                    if (sudokuBoard[i, j].ToString().Length > 1 && sudokuBoard[i, j] != sudokuBoard[rowIndex, colIndex])
                    {
                        RemoveNakedPair(sudokuBoard, sudokuBoard[rowIndex, colIndex], i, j);
                    }
                }
            }

        }

        private bool HasNakedPairInBlock(int[,] sudokuBoard, int rowIndex, int colIndex)
        {
            for (int i = 0; i < sudokuBoard.GetLength(0); i++)
            {
                for (int j = 0; j < sudokuBoard.GetLength(1); j++)
                {
                    var isSameIndex = rowIndex == i && colIndex == j;
                    var isInSameBlock = (_sudokuMapper.Find(rowIndex, colIndex).StartRow == _sudokuMapper.Find(i, j).StartRow) &&
                        (_sudokuMapper.Find(rowIndex, colIndex).StartColumn == _sudokuMapper.Find(i, j).StartColumn);

                    if (!isSameIndex && isInSameBlock && IsNakedPair(sudokuBoard[rowIndex, colIndex], sudokuBoard[i, j]))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private void RemoveNakedPair(int[,] sudokuBoard, int removedValues, int removedRow, int removedCol)
        {
            var removedArray = removedValues.ToString().ToCharArray();
            foreach(var value in removedArray)
            {
                sudokuBoard[removedRow, removedCol] = Convert.ToInt32(sudokuBoard[removedRow, removedCol].ToString().Replace(value.ToString(), string.Empty));
            }
        }

        private bool IsNakedPair(int first, int second)
        {
            return first.ToString().Length == 2 && first == second;
        }
    }
}
