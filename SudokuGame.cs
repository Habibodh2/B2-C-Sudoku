using System;

namespace Sudoku
{
    public class SudokuGame
    {
        private SudokuGrid _grid;

        public SudokuGame()
        {
            _grid = new SudokuGrid();
        }

        public void StartGame(int removeCount)
        {
            _grid.GenerateSudoku();
            _grid.RemoveRandomValues(removeCount);

            Console.WriteLine("Sudoku créé. Voici votre puzzle :");
            _grid.DisplayGrid();
        }

        public void AddValue(int row, int col, int value)
{
    if (row < 0 || row >= 9 || col < 0 || col >= 9)
    {
        Console.WriteLine("Position invalide !");
        return;
    }

    if (_grid.Grid[row, col] != 0)
    {
        Console.WriteLine("Cette case est déjà remplie !");
        return;
    }

    if (!_grid.IsValidMove(row, col, value))
    {
        Console.WriteLine("Cette valeur ne peut pas être ajoutée ici.");
        return;
    }

    _grid.Grid[row, col] = value;
    Console.WriteLine("Valeur ajoutée avec succès !");
    Console.WriteLine("Voici la grille mise à jour :");
    DisplayGrid();
}


        public bool CheckWin()
        {
            return _grid.IsSolved();
        }

        public void DisplayGrid()
        {
            _grid.DisplayGrid();
        }
    }
}
