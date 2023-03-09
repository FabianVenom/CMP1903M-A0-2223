using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_A01_2223
{
    class Card
    {
        //Base for the Card class.
        //Value: numbers 1 - 13
        //Suit: numbers 1 - 4
        //The 'set' methods for these properties could have some validation
        public int Value { get; set; }
        public int Suit { get; set; }

        public Card(int value, int suit)
        {
            if (value < 1 || value > 13)
            {
                throw new ArgumentException("Value must be between 1 and 13.");
            }

            if (suit < 1 || suit > 4)
            {
                throw new ArgumentException("Suit must be between 1 and 4.");
            }

            Value = value;
            Suit = suit;
            
            
        }
        
        public override string ToString()
        {
            return "Value: " + Value + " Suit: " + Suit;
        }

    }
}
