using Kortspill;
using System;

namespace TestingLib
{
    public class TestTheCards
    {

        public UnitTestInfo DeckContains52Cards()
        {
            var TestInfo = new UnitTestInfo();
            var d = new Deck();
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
            TestInfo.MethodName = "DeckContains52Cards()";
            return TestInfo;
        }

        public UnitTestInfo PullAllCards()
        {
            var TestInfo = new UnitTestInfo();
            var d = new Deck();
            Card curCard = new Card();

            for (int i = 0; i < d.DeckOfCards.Length; i++)
            {
                curCard = d.DealCard();
                if (curCard.ToString() != "")
                {
                    TestInfo.DidTestPass = true;
                }
                else
                {
                    TestInfo.DidTestPass = false;
                    TestInfo.TestFailureMessage = $"Card number {i} in the Deck did not pass validation. This card was {curCard.face} of {curCard.suit}";
                    return TestInfo;
                }
            }
            TestInfo.MethodName = "PullAllCards()";
            return TestInfo;
        }

        public UnitTestInfo DoesDeckShuffle()
        {
            int testsToBeRan = 100;
            var TestInfo = new UnitTestInfo();
            Deck testDeck = new Deck();

            string[] oldDeck = new string[testDeck.DeckOfCards.Length];
            int similarities = 0;

            for (int i = 0; i < testsToBeRan; i++)
            {
                for (int y = 0; y < testDeck.DeckOfCards.Length; y++)
                    oldDeck[y] = testDeck.DeckOfCards[y].ToString();
                testDeck.Shuffle();
                for (int y = 0; y < testDeck.DeckOfCards.Length; y++)
                    if (testDeck.DeckOfCards[y].ToString() == oldDeck[y])
                        similarities++;
            }
            if (similarities < 10)
                TestInfo.DidTestPass = true;
            else
            {
                TestInfo.DidTestPass = false;
                TestInfo.TestFailureMessage = $"After running through {testsToBeRan} tests, we found {similarities} of the same cards in the same locations after shuffling.";
            }
            TestInfo.MethodName = "DoesDeckShuffle()";
            return TestInfo;
        }

        public struct UnitTestInfo
        {
            public bool DidTestPass { get; set; }
            public string TestFailureMessage { get; set; }
            public string MethodName { get; set; }
        }
    }
}
