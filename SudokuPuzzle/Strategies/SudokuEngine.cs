using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SudokuPuzzle.Utils;

namespace SudokuPuzzle.Strategies
{
    class SudokuEngine
    {
        private readonly SudokuBoard _sudokuBoard;
        private readonly SudokuMapper _sudokuMapper;

        public SudokuEngine(SudokuBoard sudokuBoard, SudokuMapper sudokuMapper)
        {
            _sudokuBoard = sudokuBoard;
            _sudokuMapper = sudokuMapper;
        }

        public bool Solve(int[,] sudokuBoard)
        {
            List<SudokuStrategy> strategies = new List<SudokuStrategy>()
            {
                new MarkUpStrategy(_sudokuMapper),
                new NakedPairsStrategy(_sudokuMapper)
            };

            var currentState = _sudokuBoard.State(sudokuBoard);
            var nextState = _sudokuBoard.State(strategies.First().Solve(sudokuBoard));

            while(!_sudokuBoard.IsSolved(sudokuBoard) && currentState != nextState)
            {
                currentState = nextState;
                foreach(var strategy in strategies)
                {
                    nextState = _sudokuBoard.State(strategy.Solve(sudokuBoard));
                }
            }
            return _sudokuBoard.IsSolved(sudokuBoard);

        }
    }
}
