namespace Kortspill
{
    public class Card
    {
        private string faces;
        private string suits;

        public Card (string cardFace, string cardSuit)
        {
            faces = cardFace;
            suits = cardSuit;
        }

        public override string ToString()
        {
            return faces + " of " + suits;
        }
    }
}