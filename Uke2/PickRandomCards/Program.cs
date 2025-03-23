using System;
using System.Collections.Generic;
using System.Text;

namespace PickRandomCards
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8; // Aktiver Unicode-støtte
            Console.WriteLine("Velkommen til PickRandomCards gamen!");
            Console.Write("Hvor mange kort vil du trekke? ");

            // Be brukeren om antall kort å trekke
            if (int.TryParse(Console.ReadLine(), out int numberOfCards))
            {
                try
                {
                    // Trekker de tilfeldige kortene
                    List<string> pickedCards = CardPicker.PickSomeCards(numberOfCards);

                    // Viser de trukkede kortene ved siden av hverandre
                    Console.WriteLine("De trukkede kortene er:");
                    DisplayCardsSideBySide(pickedCards);
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            else
            {
                Console.WriteLine("Ugyldig tall. Vennligst skriv et tall.");
            }
        }

        // Metode for å vise flere kort ved siden av hverandre
        static void DisplayCardsSideBySide(List<string> cards)
        {
            if (cards == null || cards.Count == 0)
            {
                Console.WriteLine("Ingen kort å vise.");
                return;
            }

            // Lagre hver linje for alle kortene
            List<string>[] cardLines = new List<string>[cards.Count];

            // Generer linjene for hvert kort
            for (int i = 0; i < cards.Count; i++)
            {
                cardLines[i] = GetCardAsLines(cards[i]);
            }

            // Skriv ut kortene linje for linje
            for (int line = 0; line < 13; line++) // Hvert kort har 7 linjer
            {
                foreach (var card in cardLines)
                {
                    if (card != null && line < card.Count)
                    {
                        Console.Write(card[line] + "  "); // Legg til mellomrom mellom kortene
                    }
                }
                Console.WriteLine(); // Ny linje for neste rad av kort
            }
        }

        // Metode for å konvertere et kort til en liste med linjer
        static List<string> GetCardAsLines(string card)
        {
            if (string.IsNullOrEmpty(card) || card.Length < 2)
            {
                return new List<string> { "┌─────────┐", "│ Ukjent │", "└─────────┘" };
            }

            string rank = card.Substring(0, card.Length - 1); // Rank (f.eks. "A", "10", "K")
            string suit = card.Substring(card.Length - 1);    // Suit (f.eks. "♥", "♦", "♣", "♠")

            // Sett farge basert på suit
            if (suit == "♥" || suit == "♦")
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Black;
            }

            // Bygg opp kortet som en liste med linjer
            List<string> lines = new List<string>
            {
                "┌─────────┐",
            $"│{rank.PadRight(2)}      │",
                "│         │",
                $"│    {suit}    │",
                "│         │",
                $"│    {rank.PadLeft(2)}│",
                "└─────────┘"
            };

            Console.ResetColor(); // Tilbakestill fargen til standard
            return lines;
        }
    }

    class CardPicker
    {
        static Random random = new Random();

        // Metode for å trekke et angitt antall kort
        public static List<string> PickSomeCards(int numberOfCards)
        {
            if (numberOfCards < 1 || numberOfCards > 52)
            {
                throw new ArgumentException("Antall kort må være mellom 1 og 52.");
            }

            List<string> deck = GenerateDeck();
            List<string> pickedCards = new List<string>();

            for (int i = 0; i < numberOfCards; i++)
            {
                int index = random.Next(deck.Count);
                pickedCards.Add(deck[index]);
                deck.RemoveAt(index); // Fjern kortet fra kortstokken
            }

            return pickedCards;
        }

        // Metode for å generere en standard kortstokk med Unicode-tegn
        private static List<string> GenerateDeck()
        {
            List<string> deck = new List<string>();
            string[] suits = { "♥", "♦", "♣", "♠" }; // Unicode-tegn for hjerter, ruter, kløver, spar
            string[] ranks = { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };

            foreach (string suit in suits)
            {
                foreach (string rank in ranks)
                {
                    deck.Add($"{rank}{suit}");
                }
            }

            return deck;
        }
    }
}