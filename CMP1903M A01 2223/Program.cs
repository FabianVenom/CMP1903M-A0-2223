using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CMP1903M_A01_2223
{
    class Program
    {
        static void Main(string[] args)
        {
            Pack pack = new Pack();
            
            Console.WriteLine("Shuffling cards using Fisher-Yates algorithm:");
            Pack.ShuffleCardPack(1);
            Console.WriteLine("Dealing a single card:");
            
            Card card = Pack.Deal();
            Console.WriteLine("Dealt card: " + card.ToString());
            
            card = Pack.Deal();
            Console.WriteLine("Dealt card: " + card.ToString());
            
            Console.WriteLine("Shuffling cards using Riffle shuffle algorithm:");
            Pack.ShuffleCardPack(2);
            card = Pack.Deal();
            Console.WriteLine("Dealt card: " + card.ToString());
            
            card = Pack.Deal();
            Console.WriteLine("Dealt card: " + card.ToString());

            Console.WriteLine(" ");
            
            Console.WriteLine("Dealing 5 cards:");
            var dealtCards = Pack.DealCard(5);
            Console.WriteLine("Dealt cards:");
            foreach (var dealtCard in dealtCards)
            {
                Console.WriteLine(dealtCard.ToString());
            }
            
            Console.WriteLine(" ");
            
            dealtCards = Pack.DealCard(5);
            Console.WriteLine("Dealt cards:");
            foreach (var dealtCard in dealtCards)
            {
                Console.WriteLine(dealtCard.ToString());
            }
        }
    }
}
