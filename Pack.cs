using System;
using System.Collections.Generic;

namespace CMP1903M_A01_2223
{
    class Pack
    {
        private List<Card> pack;

        public Pack()
        {
            pack = new List<Card>();
            // Initialise the card pack here
            for (int i = 1; i <= 13; i++)
            {
                for (int j = 1; j <= 4; j++)
                {
                    pack.Add(new Card(i, j));
                }
            }
        }

        public bool ShuffleCardPack(int typeOfShuffle)
        {
            // Shuffles the pack based on the type of shuffle
            switch (typeOfShuffle)
            {
                case 1: // Fisher-Yates Shuffle
                    for (int i = pack.Count - 1; i >= 1; i--)
                    {
                        int j = new Random().Next(i + 1);
                        Card temp = pack[j];
                        pack[j] = pack[i];
                        pack[i] = temp;
                    }
                    break;
                case 2: // Riffle Shuffle
                    int mid = pack.Count / 2;
                    List<Card> left = pack.GetRange(0, mid);
                    List<Card> right = pack.GetRange(mid, pack.Count - mid);
                    int leftIndex = 0;
                    int rightIndex = 0;
                    for (int i = 0; i < pack.Count; i++)
                    {
                        if (i % 2 == 0 && leftIndex < left.Count)
                        {
                            pack[i] = left[leftIndex];
                            leftIndex++;
                        }
                        else if (rightIndex < right.Count)
                        {
                            pack[i] = right[rightIndex];
                            rightIndex++;
                        }
                    }
                    break;
                case 3: // No Shuffle
                    // do nothing
                    break;
                default:
                    return false;
            }
            return true;
        }

        public Card Deal()
        {
            // Deals one card
            if (pack.Count == 0)
            {
                return null;
            }
            Card card = pack[pack.Count - 1];
            pack.RemoveAt(pack.Count - 1);
            return card;
        }

        public List<Card> DealCard(int amount)
        {
            // Deals the number of cards specified by 'amount'
            List<Card> cards = new List<Card>();
            for (int i = 0; i < amount; i++)
            {
                Card card = Deal();
                if (card != null)
                {
                    cards.Add(card);
                }
            }
            return cards;
        }
    }
}
