using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuPuzzle.Utils
{
    class SudokuBoard
    {
        public void Show(int[,] board)
        {
            for (int i = 0; i< board.GetLength(0); i++)
            {
                Console.Write(" ");
                for (int j=0; j<board.GetLength(1); j++)
                {
                    Console.Write("{0}{1}", board[i, j], " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public string State(int[,] board)
        {
            StringBuilder key = new StringBuilder();
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    key.Append(board[i, j]);
                }
            }
            return key.ToString();
        }

        public bool IsSolved(int[,] board)
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if (board[i, j] == 0 || board[i, j].ToString().Length > 1)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
