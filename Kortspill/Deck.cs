using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kortspill
{
    class Deck
    {
        private Card[] deckOfCards;
        private int currentCard;
        private const int 
            NUMBER_OF_CARDS = 52, 
            NUMBER_OF_CARDS_IN_SUIT = 13;
        private Random r;

        public Deck()
        {
            /// <summary>
            /// Defining all the possible faces of the cards in a string array.
            /// </summary>
            string[] faces =
            {
                "Ace",
                "Two",
                "Three",
                "Four",
                "Five",
                "Six",
                "Seven",
                "Eight",
                "Nine",
                "Ten",
                "Jack",
                "Queen",
                "King"
            };

            /// <summary>
            /// Defining all the possible suits.
            /// </summary>
            string[] suits = {
                "Hearts",
                "Diamonds",
                "Spades",
                "Clubs"
            };

            deckOfCards = new Card[NUMBER_OF_CARDS];
            currentCard = 0;
            r = new Random();
            for (int num = 0; num < NUMBER_OF_CARDS; num++)
            {
                int face = num % NUMBER_OF_CARDS_IN_SUIT;
                int suit = num / NUMBER_OF_CARDS_IN_SUIT;
                Console.WriteLine("{0} of {1}", faces[face], suits[suit]);

                deckOfCards[num] = new Card(faces[face], suits[suit]);
                deckOfCards[num].ToString();
            }
                
        }

        public void Shuffle()
        {
            currentCard = 0;
            for (int first = 0; first < deckOfCards.Length; first++)
            {
                int second = r.Next(NUMBER_OF_CARDS);
                Card temp = deckOfCards[first];
                deckOfCards[first] = deckOfCards[second];
                deckOfCards[second] = temp;
            }
        }

        public Card DealCard()
        {
            if (currentCard < deckOfCards.Length)
                return deckOfCards[currentCard++];
            else
                return null;
        }
    }
}
