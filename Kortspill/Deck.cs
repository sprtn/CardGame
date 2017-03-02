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
            /// Defining all the possible faces of the cards 
            /// in a string array, Ace through King.
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
            /// Defining all suits in a deck of cards.
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
            for (int i = 0; i < NUMBER_OF_CARDS; i++)
                deckOfCards[i] = new Card(faces[i % NUMBER_OF_CARDS_IN_SUIT], suits[i / NUMBER_OF_CARDS_IN_SUIT], (i % NUMBER_OF_CARDS_IN_SUIT) + 1);
        }

        /// <summary>
        /// This Shuffle command goes through every Card in the deck
        /// and switches it with a random card, making sure every
        /// single card in the stack is moved at least once.
        /// 
        /// This ensures that the deck is sufficiently shuffled.
        /// </summary>
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

        /// <summary>
        /// This method cycles through the stack of cards from
        /// from position 0 in the array and all the way through.
        /// </summary>
        /// <returns> Returns next Card in the array or null </returns>
        public Card DealCard()
        {
            if (currentCard < deckOfCards.Length)
                return deckOfCards[currentCard++];
            else
                return null;
        }
    }
}
