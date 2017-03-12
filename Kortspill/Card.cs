namespace Kortspill
{

    public class Card
    {
        /// <summary>
        /// The face of the card, i.e. Ace to Kig.
        /// </summary>
        public string face;

        /// <summary>
        /// The Suit of the card, i.e. Heart, Diamond, Spades and Clubs.
        /// </summary>
        public string suit;

        /// <summary>
        /// The value of the card, ranging from 1 to 13.
        /// </summary>
        public int value;

        /// <summary>
        /// The filepath to the card's image
        /// </summary>
        public string imgPath;

        /// <summary>
        /// The Constructor function of the Card class. 
        /// Sets the card's variables to the input values.
        /// 
        /// Also wanted to add a string value where the 
        /// filepath for the image of the Card was input into
        /// the constructor.
        /// </summary>
        /// <param name="cardFace"></param>
        /// <param name="cardSuit"></param>
        /// <param name="cardValue"></param>
        public Card (string cardFace, string cardSuit, int cardValue)
        {
            face = cardFace;
            suit = cardSuit;
            value = cardValue;
        }

        public Card ()
        {
            face = null;
            suit = null;
            value = 0;
        }

        /// <summary>
        /// Overrides the ToString method to something useable for
        /// us, when checking which card we are pulling out of the deck..
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            if (face != null && suit != null && value != 0)
                return face + " of " + suit + " with a value of " + value;
            else
                return "Not a valid card.";
        }
    }
}