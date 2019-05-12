using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SudokuPuzzle.Utils;
using SudokuPuzzle.Strategies;

namespace SudokuPuzzle
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                SudokuMapper sudokuMapper = new SudokuMapper();
                SudokuBoard sudokuBoard = new SudokuBoard();
                SudokuEngine sudokuEngine = new SudokuEngine(sudokuBoard, sudokuMapper);
                SudokuReader sudokuReader = new SudokuReader();
                
                Console.WriteLine("Please enter the Sudoku file name:");
                var filename = Console.ReadLine();

                var sudoku = sudokuReader.ReadFile(filename);
                sudokuBoard.Show(sudoku);

                bool isSudoKuSolved = sudokuEngine.Solve(sudoku);
                sudokuBoard.Show(sudoku);

                Console.WriteLine(isSudoKuSolved
                    ? "Sudoku is solved."
                    : "Unfortunately, current algorithm(s) were not enough to solve the Sudoku.");

            }
            catch(Exception e)
            {
                Console.WriteLine("{0}:{1}", "Something go wrong! ", e.Message);
            }
        }
    }
}
