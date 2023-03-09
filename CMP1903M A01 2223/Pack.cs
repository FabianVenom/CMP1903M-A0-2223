using System;
using System.Collections.Generic;
using System.Linq;

namespace CMP1903M_A01_2223
{
    class Pack
    {
        private static Card[] cards;

        public Pack()
        {
            // Calls the method that initializes the pack of cards
            InitializePack();
        }

        // Method to initialize the pack of cards
        public void InitializePack()
        {
            // Creates an empty array that will hold 52 cards
            cards = new Card[52];
            // Using an index indicator, uses two for loops to create all possible card combination
            int index = 0;
            for (int suit = 1; suit <= 4; suit++)
            {
                for (int value = 1; value <= 13; value++)
                {
                    // Store the result card into the array with their value and suit
                    cards[index] = new Card(value, suit);
                    index++;
                }
            }
        }

        // Method that calls the shuffling methods
        public static bool ShuffleCardPack(int typeOfShuffle)
        {
            switch (typeOfShuffle)
            {
                // If typeOfShuffle is '1' then it will call the Fisher Yates shuffle method
                case 1:
                    ShuffleFisherYates();
                    return true;
                
                // If typeOfShuffle is '2' then it will call the Riffle shuffle method
                case 2:
                    ShuffleRiffle();
                    return true;
                
                // If it is anything else, it does not shuffle
                default:
                    return false;
            }
        }

        // Shuffles the card pack using the Fisher-Yates algorithm
        private static void ShuffleFisherYates()
        {
            Random random = new Random();
            // Starting from the end of the pack, shuffle each card with a random card before it
            for (int i = cards.Length - 1; i > 0; i--)
            {
                // Choose a random card from the pack before the current card
                int j = random.Next(i + 1);
                // Swap the current card with the randomly chosen card
                Card temp = cards[i];
                cards[i] = cards[j];
                cards[j] = temp;
            }
        }

        // Shuffles the card pack using the Riffle algorithm
        private static void ShuffleRiffle()
        {
            Random random = new Random();
            int halfLength = cards.Length / 2;
            // Divide the pack into two halves
            Card[] leftHalf = new Card[halfLength];
            Card[] rightHalf = new Card[cards.Length - halfLength];

            Array.Copy(cards, 0, leftHalf, 0, halfLength);
            Array.Copy(cards, halfLength, rightHalf, 0, cards.Length - halfLength);

            int leftIndex = 0;
            int rightIndex = 0;

            // Merge the two halves by randomly selecting a card from either half
            for (int i = 0; i < cards.Length; i++)
            {
                if (leftIndex < leftHalf.Length && (random.Next(2) == 0 || rightIndex >= rightHalf.Length))
                {
                    cards[i] = leftHalf[leftIndex];
                    leftIndex++;
                }
                else if (rightIndex < rightHalf.Length)
                {
                    cards[i] = rightHalf[rightIndex];
                    rightIndex++;
                }
            }
        }

        private static int currentIndex = 0;

        // Deals a single card from the pack and increments the current index.
        // If all cards have been dealt, an exception could be thrown or null could be returned.
        public static Card Deal()
        {
            if (currentIndex >= 52)
            {
                // Throw an exception or return null
                throw new InvalidOperationException("The deck is empty");
            }

            Card card = cards[currentIndex];
            currentIndex++;
            return card;
        }

        private static int current = 0;

        // Deals a specified number of cards from the pack and returns them in a list.
        // If there are not enough cards in the pack to fulfill the request, an exception could be thrown
        // or a shorter list could be returned.
        public static List<Card> DealCard(int amount)
        {
            List<Card> dealtCards = new List<Card>();

            for (int i = 0; i < amount; i++)
            {
                if (currentIndex >= 52)
                {
                    // Throw an exception or return fewer cards
                    throw new InvalidOperationException("The deck is empty");
                }

                Card card = cards[currentIndex];
                dealtCards.Add(card);
                currentIndex++;
            }

            return dealtCards;
        }
    }
}






