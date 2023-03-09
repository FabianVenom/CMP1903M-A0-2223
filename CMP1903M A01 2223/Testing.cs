using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_A01_2223
{
    class Testing
    {
        static void Test(string[] args)
        {
            Pack pack = new Pack();

            // Shuffle the cards using different methods
            Console.WriteLine("Shuffling cards using Fisher-Yates algorithm:");
            Pack.ShuffleCardPack(1);
            Console.WriteLine("Cards shuffled successfully!");

            Console.WriteLine("Shuffling cards using Riffle shuffle algorithm:");
            Pack.ShuffleCardPack(2);
            Console.WriteLine("Cards shuffled successfully!");

            // Deal some cards
            Console.WriteLine("Dealing a single card:");
            Card card = Pack.Deal();
            Console.WriteLine("Dealt card: " + card.ToString());

            Console.WriteLine("Dealing 5 cards:");
            var dealtCards = Pack.DealCard(5);
            Console.WriteLine("Dealt cards:");
            foreach (var dealtCard in dealtCards)
            {
                Console.WriteLine(dealtCard.ToString());
            }
        }
    }
}