using System;
using System.Collections.Generic;
using System.Windows.Media;

namespace Kortspill
{
    public class Deck
    {
        private Card[] deckOfCards;
        private int currentCard;
        public const int 
            NUMBER_OF_CARDS = 52, 
            NUMBER_OF_CARDS_IN_SUIT = 13;

        /// <summary>
        /// Defining all the possible faces of the cards 
        /// in a string array, Ace through King.
        /// </summary>
        public string[] faces =
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
        public string[] suits = 
        {
            "Hearts",
            "Diamonds",
            "Spades",
            "Clubs"
        };


        private Uri[] imgPaths =
        {
            new Uri("Cards/ace_of_hearts.png", UriKind.Relative),
            new Uri("Cards/2_of_hearts.png", UriKind.Relative),
            new Uri("Cards/3_of_hearts.png", UriKind.Relative),
            new Uri("Cards/4_of_hearts.png", UriKind.Relative),
            new Uri("Cards/5_of_hearts.png", UriKind.Relative),
            new Uri("Cards/6_of_hearts.png", UriKind.Relative),
            new Uri("Cards/7_of_hearts.png", UriKind.Relative),
            new Uri("Cards/8_of_hearts.png", UriKind.Relative),
            new Uri("Cards/9_of_hearts.png", UriKind.Relative),
            new Uri("Cards/10_of_hearts.png", UriKind.Relative),
            new Uri("Cards/jack_of_hearts.png", UriKind.Relative),
            new Uri("Cards/queen_of_hearts.png", UriKind.Relative),
            new Uri("Cards/king_of_hearts.png", UriKind.Relative),
            new Uri("Cards/ace_of_diamonds.png", UriKind.Relative),
            new Uri("Cards/2_of_diamonds.png", UriKind.Relative),
            new Uri("Cards/3_of_diamonds.png", UriKind.Relative),
            new Uri("Cards/4_of_diamonds.png", UriKind.Relative),
            new Uri("Cards/5_of_diamonds.png", UriKind.Relative),
            new Uri("Cards/6_of_diamonds.png", UriKind.Relative),
            new Uri("Cards/7_of_diamonds.png", UriKind.Relative),
            new Uri("Cards/8_of_diamonds.png", UriKind.Relative),
            new Uri("Cards/9_of_diamonds.png", UriKind.Relative),
            new Uri("Cards/10_of_diamonds.png", UriKind.Relative),
            new Uri("Cards/jack_of_diamonds.png", UriKind.Relative),
            new Uri("Cards/queen_of_diamonds.png", UriKind.Relative),
            new Uri("Cards/king_of_diamonds.png", UriKind.Relative),
            new Uri("Cards/ace_of_spades.png", UriKind.Relative),
            new Uri("Cards/2_of_spades.png", UriKind.Relative),
            new Uri("Cards/3_of_spades.png", UriKind.Relative),
            new Uri("Cards/4_of_spades.png", UriKind.Relative),
            new Uri("Cards/5_of_spades.png", UriKind.Relative),
            new Uri("Cards/6_of_spades.png", UriKind.Relative),
            new Uri("Cards/7_of_spades.png", UriKind.Relative),
            new Uri("Cards/8_of_spades.png", UriKind.Relative),
            new Uri("Cards/9_of_spades.png", UriKind.Relative),
            new Uri("Cards/10_of_spades.png", UriKind.Relative),
            new Uri("Cards/jack_of_spades.png", UriKind.Relative),
            new Uri("Cards/queen_of_spades.png", UriKind.Relative),
            new Uri("Cards/king_of_spades.png", UriKind.Relative),
            new Uri("Cards/ace_of_clubs.png", UriKind.Relative),
            new Uri("Cards/2_of_clubs.png", UriKind.Relative),
            new Uri("Cards/3_of_clubs.png", UriKind.Relative),
            new Uri("Cards/4_of_clubs.png", UriKind.Relative),
            new Uri("Cards/5_of_clubs.png", UriKind.Relative),
            new Uri("Cards/6_of_clubs.png", UriKind.Relative),
            new Uri("Cards/7_of_clubs.png", UriKind.Relative),
            new Uri("Cards/8_of_clubs.png", UriKind.Relative),
            new Uri("Cards/9_of_clubs.png", UriKind.Relative),
            new Uri("Cards/10_of_clubs.png", UriKind.Relative),
            new Uri("Cards/jack_of_clubs.png", UriKind.Relative),
            new Uri("Cards/queen_of_clubs.png", UriKind.Relative),
            new Uri("Cards/king_of_clubs.png", UriKind.Relative)
        };

        /// <summary>
        /// A getter for the deckOfCards of the Deck.
        /// Returns the deckOfCards Card[] belonging
        /// to this Deck.
        /// </summary>
        public Card[] DeckOfCards
        {
            get
            {
                return deckOfCards;
            }
        }

        /// <summary>
        /// Constructor for Deck class. Creates a card array containing NUMBER_OF_CARDS cards.
        /// The for-statement places new Cards into the deckOfCards, using some simple logic
        /// to create every single card in the correct order (Ace through King, Hearts through Clubs)
        /// To change the order of the suits, simply alter the order of the suits in the suits string-array above.
        /// </summary>
        public Deck()
        {
            deckOfCards = new Card[NUMBER_OF_CARDS];
            currentCard = 0;
            for (int i = 0; i < NUMBER_OF_CARDS; i++)
                deckOfCards[i] = new Card(faces[i % NUMBER_OF_CARDS_IN_SUIT], suits[i / NUMBER_OF_CARDS_IN_SUIT], (i % NUMBER_OF_CARDS_IN_SUIT) + 1, imgPaths[i]);
        }

        /// <summary>
        /// This Sort function creates a temporary Card[], and stores the 
        /// cards from the original array into temp array one at a time.
        /// 
        /// We determine the storage location of the cards in the array
        /// from their suit and their value. We need to subtract 1
        /// from the equation since the values of the cards start at 1.
        /// 
        /// After moving over the 52 cards into their respective locations 
        /// in the temporary array, we overwrite the deckOfCards with our temp.
        /// 
        /// This code would not work if there were multiple Deck's of Cards.
        /// If multiple deck's were implemented, we could use the sort function 
        /// that is already for int arrays, and sort the Card[] based on the cards' value.
        /// 
        /// I do believe the following code is quicker than sorting by value.
        /// That is, however, not tested.
        /// </summary>
        public void Sort()
        {
            currentCard = 0;
            Card[] tempDeckOfCards = new Card[NUMBER_OF_CARDS];
            for (int i = 0; i<NUMBER_OF_CARDS; i++)
                tempDeckOfCards[((Array.IndexOf(suits, deckOfCards[i].suit) * NUMBER_OF_CARDS_IN_SUIT) + deckOfCards[i].value) - 1] = deckOfCards[i];
            deckOfCards = tempDeckOfCards;
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
            Random r = new Random();
            for (int current = 0; current < deckOfCards.Length; current++)
            {
                int next = r.Next(NUMBER_OF_CARDS);
                Card tempCard = deckOfCards[current];
                deckOfCards[current] = deckOfCards[next];
                deckOfCards[next] = tempCard;
                r = new Random();
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
