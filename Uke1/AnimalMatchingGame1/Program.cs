using System;
using System.Collections.Generic;
using System.Linq;

namespace AnimalMatchingGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Velkommen til Animal Matching Game!");
            Console.WriteLine("Match parene for å vinne spillet!");

            // Liste med dyr (hvert dyr vises to ganger)
            List<string> animals = new List<string> { "Katt", "Hund", "Fugl", "Fisk", "Katt", "Hund", "Fugl", "Fisk" };

            // Bland dyrene for å gjøre spillet utfordrende
            Random random = new Random();
            animals = animals.OrderBy(a => random.Next()).ToList();

            // Lager et brett for å vise dyrene
            string[] board = new string[animals.Count];
            bool[] matched = new bool[animals.Count];

            // Initialiser brettet med skjulte dyrene
            for (int i = 0; i < board.Length; i++)
            {
                board[i] = "Skjult";
            }

            int attempts = 0;
            while (true)
            {
                // Vis brettet
                Console.WriteLine("\nBrettet:");
                for (int i = 0; i < board.Length; i++)
                {
                    if (matched[i])
                    {
                        Console.Write($"[{animals[i]}] ");
                    }
                    else
                    {
                        Console.Write($"[{board[i]}] ");
                    }
                }
                Console.WriteLine();

                // Sjekk om alle parene er matchet
                if (matched.All(m => m))
                {
                    Console.WriteLine($"Gratulerer! Du har matchet alle parene på {attempts} forsøk.");
                    break;
                }

                // Be spilleren om å velge to posisjoner
                Console.Write("Velg første posisjon (0-7): ");
                int firstPosition = int.Parse(Console.ReadLine());

                Console.Write("Velg andre posisjon (0-7): ");
                int secondPosition = int.Parse(Console.ReadLine());

                // Sjekk om posisjonene er gyldige
                if (firstPosition < 0 || firstPosition >= animals.Count ||
                    secondPosition < 0 || secondPosition >= animals.Count ||
                    firstPosition == secondPosition || matched[firstPosition] || matched[secondPosition])
                {
                    Console.WriteLine("Ugyldig valg. Prøv igjen.");
                    continue;
                }

                // Vis de valgte dyrene
                Console.WriteLine($"Du valgte: {animals[firstPosition]} og {animals[secondPosition]}");

                // Sjekk om dyrene matcher
                if (animals[firstPosition] == animals[secondPosition])
                {
                    Console.WriteLine("Match! Bra jobbet!");
                    matched[firstPosition] = true;
                    matched[secondPosition] = true;
                }
                else
                {
                    Console.WriteLine("Ingen match. Prøv igjen!");
                }

                attempts++;
            }
        }
    }
}
