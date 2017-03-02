namespace Kortspill
{
    public class Card
    {
        public string face;
        public string suit;
        public int value;

        public Card (string cardFace, string cardSuit, int cardValue)
        {
            face = cardFace;
            suit = cardSuit;
            value = cardValue;
        }

        public override string ToString()
        {
            return face + " of " + suit + " with a value of " + value;
        }
    }
}