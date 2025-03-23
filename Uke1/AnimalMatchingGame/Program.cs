using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace AnimalMatchingGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Velkommen til Animal Matching Game!");
            Console.WriteLine("Prøv å matche parene av dyr!");

            bool playAgain = true;
            while (playAgain)
            {
                PlayGame();
                Console.Write("Vil du spille igjen? (ja/nei): ");
                string response = Console.ReadLine().ToLower();
                playAgain = response == "ja";
            }

            Console.WriteLine("Takk for at du spilte!");
        }

        static void PlayGame()
        {
            // Initialiser spillbrettet
            List<string> animals = new List<string> { "🐱", "🐶", "🐦", "🐠", "🐰", "🐼", "🐘", "🦁" };
            List<string> board = new List<string>();
            List<bool> revealed = new List<bool>();
            int pairsFound = 0;

            // Lag en liste med dyr (hvert dyr to ganger)
            foreach (var animal in animals)
            {
                board.Add(animal);
                board.Add(animal);
            }

            // Bland dyrene
            Random rnd = new Random();
            board = board.OrderBy(x => rnd.Next()).ToList();

            // Initialiser "revealed"-listen
            for (int i = 0; i < board.Count; i++)
            {
                revealed.Add(false);
            }

            // Start stoppeklokka
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            // Spill-løkke
            while (pairsFound < animals.Count)
            {
                DisplayBoard(board, revealed);

                Console.Write("Velg første rute (0-15): ");
                int firstIndex = GetValidInput(revealed);

                Console.Write("Velg andre rute (0-15): ");
                int secondIndex = GetValidInput(revealed);

                if (firstIndex == secondIndex)
                {
                    Console.WriteLine("Du kan ikke velge samme rute to ganger. Prøv igjen.");
                    continue;
                }

                // Avslør de valgte rutene
                revealed[firstIndex] = true;
                revealed[secondIndex] = true;
                DisplayBoard(board, revealed);

                // Sjekk om de to rutene matcher
                if (board[firstIndex] == board[secondIndex])
                {
                    Console.WriteLine("Bra jobbet! Du fant et par!");
                    pairsFound++;
                }
                else
                {
                    Console.WriteLine("Ingen match, prøv igjen.");
                    System.Threading.Thread.Sleep(1000); // Pause for å la spilleren se brettet
                    revealed[firstIndex] = false;
                    revealed[secondIndex] = false;
                }
            }

            // Spillet er over
            stopwatch.Stop();
            Console.WriteLine($"Gratulerer! Du brukte {stopwatch.Elapsed.TotalSeconds:F2} sekunder på å finne alle parene.");
        }

        static void DisplayBoard(List<string> board, List<bool> revealed)
        {
            Console.Clear();
            for (int i = 0; i < board.Count; i++)
            {
                if (revealed[i])
                {
                    Console.Write(board[i] + "\t");
                }
                else
                {
                    Console.Write(i + "\t");
                }

                if ((i + 1) % 4 == 0)
                {
                    Console.WriteLine();
                }
            }
        }

        static int GetValidInput(List<bool> revealed)
        {
            int input;
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out input) && input >= 0 && input < 16 && !revealed[input])
                {
                    return input;
                }
                Console.WriteLine("Ugyldig valg. Prøv igjen.");
            }
    
        }
    }
}