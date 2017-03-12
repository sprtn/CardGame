using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KORT = Kortspill;

namespace TestingLib
{
    class TestTheCards
    {

        public UnitTestInfo DeckContains52Cards()
        {
            var TestInfo = new UnitTestInfo();
            var d = new KORT.Deck();
            int numCardsInDeck = d.DeckOfCards.Length;

            if (numCardsInDeck % 52 == 0)
            {
                TestInfo.DidTestPass = true;
            }
            else
            {
                TestInfo.DidTestPass = false;
                TestInfo.TestFailureMessage = "Deck contains " + numCardsInDeck + " cards, while it should be dividable by 52.";
            }
            return TestInfo;
        }

        public struct UnitTestInfo
        {
            public bool DidTestPass { get; set; }
            public string TestFailureMessage { get; set; }
        }
    }
}
