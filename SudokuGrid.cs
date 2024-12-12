using System;

namespace Sudoku {

    public class SudokuGrid {

        public int[,] Grid { get; private set; } = new int[9, 9];

        public bool GenerateSudoku() {
            return FillGrid();
        }


        private bool FillGrid() {

            for (int row = 0; row < 9; row++) {
                for (int col = 0; col < 9; col++) {
                    if (Grid[row, col] == 0) {

                        for (int num = 1; num <= 9; num++) {
                            if (IsValidMove(row, col, num)) {
                                Grid[row, col] = num;
                                if (FillGrid()) {
                                    return true;
                                }
                                Grid[row, col] = 0;
                            }
                        }
                        return false;
                    }
                }
            }
            SwapRandomRows();
            return true;
        }

        public bool IsValidMove(int row, int col, int num) {

            for (int i = 0; i < 9; i++) {
                if (Grid[row, i] == num) return false;
            }

            for (int i = 0; i < 9; i++) {
                if (Grid[i, col] == num) return false;
            }

            int startRow = row - row % 3;
            int startCol = col - col % 3;

            for (int i = 0; i < 3; i++) {
                for (int j = 0; j < 3; j++) {
                    if (Grid[i + startRow, j + startCol] == num) return false;
                }
            }

            return true;
        }

        public void SwapRandomRows() {

            Random rand = new Random();
            int row1 = rand.Next(0, 9);
            int row2;
            int i = 0;//
            do {
                row2 = rand.Next(0, 9);
                i++;//
            } while (i < 9);

            for (int col = 0; col < 9; col++) {
                int temp = Grid[row1, col];
                Grid[row1, col] = Grid[row2, col];
                Grid[row2, col] = temp;
            }
        }

        public void SwapRandomColumns() {
            Random rand = new Random();
            int col1 = rand.Next(0, 9);
            int col2;
            int i = 0;
            do {
                col2 = rand.Next(0, 9);
                i++;
            } while (i < 9);

            for (int row = 0; row < 9; row++) {
                int temp = Grid[row, col1];
                Grid[row, col1] = Grid[row, col2];
                Grid[row, col2] = temp;
            }
        }

        public void RemoveRandomValues(int count) {
            Random rand = new Random();
            int removed = 0;

            while (removed < count) {
                int row = rand.Next(9);
                int col = rand.Next(9);

                if (Grid[row, col] != 0) {
                    Grid[row, col] = 0;
                    removed++;
                }
            }
        }

        public bool IsValid() {
            for (int row = 0; row < 9; row++) {
                for (int col = 0; col < 9; col++) {
                    if (Grid[row, col] != 0 && !IsValidMove(row, col, Grid[row, col])) {
                        return false;
                    }
                }
            }
            return true;
        }

        public bool IsSolved() {
            for (int row = 0; row < 9; row++) {
                for (int col = 0; col < 9; col++) {
                    if (Grid[row, col] == 0) {
                        return false;
                    }
                }
            }
            return IsValid();
        }

        public void DisplayGrid() {

            for (int row = 0; row < 9; row++) {
                for (int col = 0; col < 9; col++) {
                    Console.Write(Grid[row, col] == 0 ? ". " : Grid[row, col] + " ");
                }
                Console.WriteLine();
            }
        }
    }

}