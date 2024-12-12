using System;

namespace Sudoku {

    class Program {
        
        static void Main(string[] args) {

            SudokuGame game = new SudokuGame();
            bool gameRunning = true;

            game.StartGame(30);

            while (gameRunning) {
                Console.WriteLine("Options:");
                Console.WriteLine("1. Afficher la grille");
                Console.WriteLine("2. Ajouter un chiffre");
                Console.WriteLine("3. Vérifier si gagné");
                Console.WriteLine("4. Quitter");
                var option = Console.ReadLine();

                switch (option) {
                    case "1":
                        game.DisplayGrid();
                        break;

                    case "2":
                        Console.Write("Entrez la ligne : ");
                        int row = int.Parse(Console.ReadLine()) + 1;
                        Console.Write("Entrez la colonne : ");
                        int col = int.Parse(Console.ReadLine()) + 1;
                        Console.Write("Entrez la valeur : ");
                        int value = int.Parse(Console.ReadLine());
                        game.AddValue(row, col, value);
                        break;

                    case "3":
                        if (game.CheckWin()) {
                            Console.WriteLine("Félicitations ! Vous avez gagné !");
                            gameRunning = false;
                        }
                        else {
                            Console.WriteLine("Le jeu n'est pas encore gagné.");
                        }
                        break;

                    case "4":
                        gameRunning = false;
                        break;

                    default:
                        Console.WriteLine("Option invalide.");
                        break;
                }
            }
        }
    }

}