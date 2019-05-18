# Sudoku Puzzle

Sudoku is a combinatorial puzzle. The objective is to fill a 9×9 grid with digits so that each column, each row, and each of the 3×3 subgrids contain all of the digits from 1 to 9. The following is the strategy used to solve the puzzle.

First, marking numbers as a way of keeping track of the remaining possibilities for all the cells that are unsolved. That is, find an empty cell, mark all the numbers 1 through 9 except those that already appear in that same row, column, and block. Then remove those marks by:

- Long Singles

    When a cell has only one mark, thus, this is it. 

- Hidden Singles
    
    When a mark is the only one of its kind in an entire row, column, or block.

- Naked Pairs

    When two cells in the same house have the exact same two marks. Where a house refers to a row, column, or block. Thus, a Sudoku puzzle has 9x3 = 27 houses.


Reference
https://www.learn-sudoku.com/basic-techniques.html
