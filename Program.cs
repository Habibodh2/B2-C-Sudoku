using System;

namespace Sudoku
{
    class Program
    {
        static void Main(string[] args)
        {
            bool gameRunning = true;

            while (gameRunning)
            {
                SudokuGame game = new SudokuGame();
                game.StartGame(30); 
                bool playing = true;

                while (playing)
                {
                    Console.WriteLine("\nOptions :");
                    Console.WriteLine("1. Afficher la grille");
                    Console.WriteLine("2. Ajouter un chiffre");
                    Console.WriteLine("3. Vérifier si gagné");
                    Console.WriteLine("4. Quitter");
                    Console.Write("Choisissez une option : ");
                    var option = Console.ReadLine();

                    switch (option)
                    {
                        case "1":
                            game.DisplayGrid();
                            break;

                        case "2":
                            Console.Write("Entrez la ligne (1-9) : ");
                            if (!int.TryParse(Console.ReadLine(), out int row) || row < 1 || row > 9)
                            {
                                Console.WriteLine("Entrée invalide. Entrez un chiffre entre 1 et 9.");
                                continue;
                            }

                            Console.Write("Entrez la colonne (1-9) : ");
                            if (!int.TryParse(Console.ReadLine(), out int col) || col < 1 || col > 9)
                            {
                                Console.WriteLine("Entrée invalide. Entrez un chiffre entre 1 et 9.");
                                continue;
                            }

                            Console.Write("Entrez la valeur (1-9) : ");
                            if (!int.TryParse(Console.ReadLine(), out int value) || value < 1 || value > 9)
                            {
                                Console.WriteLine("Entrée invalide. Entrez un chiffre entre 1 et 9.");
                                continue;
                            }

                            game.AddValue(row - 1, col - 1, value); 
                            break;

                        case "3":
                            if (game.CheckWin())
                            {
                                Console.WriteLine("Félicitations ! Vous avez gagné !");
                                playing = false;
                            }
                            else
                            {
                                Console.WriteLine("Le jeu n'est pas encore gagné. Continuez !");
                            }
                            break;

                        case "4":
                            Console.WriteLine("Merci d'avoir joué !");
                            playing = false;
                            break;

                        default:
                            Console.WriteLine("Option invalide. Réessayez.");
                            break;
                    }
                }

                
                Console.WriteLine("Voulez-vous recommencer une nouvelle partie ? (1: Oui, 2: Non)");
                var restartOption = Console.ReadLine();
                if (restartOption != "1")
                {
                    gameRunning = false;
                    Console.WriteLine("À bientôt !");
                }
            }

            
        }
    }
}
