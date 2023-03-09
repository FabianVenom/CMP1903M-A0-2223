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
            InitializePack();
        }

        public void InitializePack()
        {
            cards = new Card[52];
            int index = 0;
            for (int suit = 1; suit <= 4; suit++)
            {
                for (int value = 1; value <= 13; value++)
                {
                    cards[index] = new Card(value, suit);
                    index++;
                }
            }
        }

        public static bool ShuffleCardPack(int typeOfShuffle)
        {
            switch (typeOfShuffle)
            {
                case 1:
                    ShuffleFisherYates();
                    return true;
                case 2:
                    ShuffleRiffle();
                    return true;
                default:
                    return false;
            }
        }

        private static void ShuffleFisherYates()
        {
            Random random = new Random();
            for (int i = cards.Length - 1; i > 0; i--)
            {
                int j = random.Next(i + 1);
                Card temp = cards[i];
                cards[i] = cards[j];
                cards[j] = temp;
            }
        }

        private static void ShuffleRiffle()
        {
            Random random = new Random();
            int halfLength = cards.Length / 2;
            Card[] leftHalf = new Card[halfLength];
            Card[] rightHalf = new Card[cards.Length - halfLength];

            Array.Copy(cards, 0, leftHalf, 0, halfLength);
            Array.Copy(cards, halfLength, rightHalf, 0, cards.Length - halfLength);

            int leftIndex = 0;
            int rightIndex = 0;

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

        public static Card Deal()
        {
            if (currentIndex >= 52)
            {
                throw new InvalidOperationException("The deck is empty");
            }

            Card card = cards[currentIndex];
            currentIndex++;
            return card;
        }

        private static int current = 0;

        public static List<Card> DealCard(int amount)
        {
            List<Card> dealtCards = new List<Card>();

            for (int i = 0; i < amount; i++)
            {
                if (currentIndex >= 52)
                {
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






