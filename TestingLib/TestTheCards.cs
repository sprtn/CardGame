using Kortspill;

namespace TestingLib
{
    /// <summary>
    /// Our test-method library
    /// </summary>
    public class TestTheCards
    {
        /// <summary>
        /// Checks that the amount of cards in the deck is correct.
        /// </summary>
        /// <returns></returns>
        public UnitTestInfo DeckContains52Cards()
        {
            var TestInfo = new UnitTestInfo();
            var d = new Deck();
            int numCardsInDeck = d.DeckOfCards.Length;

            if (numCardsInDeck % 52 == 0)
                TestInfo.DidTestPass = true;
            else
            {
                TestInfo.DidTestPass = false;
                TestInfo.TestFailureMessage = "Deck contains " + numCardsInDeck + " cards, while it should be dividable by 52.";
            }
            TestInfo.MethodName = "DeckContains52Cards()";
            return TestInfo;
        }

        /// <summary>
        /// Checks that all cards can be pulled from the stack
        /// and that they are assigned properties.
        /// </summary>
        /// <returns></returns>
        public UnitTestInfo PullAllCards()
        {
            var TestInfo = new UnitTestInfo();
            var d = new Deck();

            for (int i = 0; i < d.DeckOfCards.Length; i++)
            {
                Card curCard = d.DealCard();
                if (curCard.ToString() != "" && curCard != null)
                    TestInfo.DidTestPass = true;
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

        /// <summary>
        /// Checks that the deck shuffles.
        /// </summary>
        /// <returns></returns>
        public UnitTestInfo DoesDeckShuffle()
        {
            int testsToBeRan = 1000;
            var TestInfo = new UnitTestInfo();
            Deck testDeck = new Deck();

            string[] oldDeck = new string[testDeck.DeckOfCards.Length];
            int similarities = 0;
            int closeOnes = 0;

            for (int i = 0; i < testsToBeRan; i++)
            {
                for (int y = 0; y < testDeck.DeckOfCards.Length; y++)
                    oldDeck[y] = testDeck.DeckOfCards[y].ToString();
                testDeck.Shuffle();
                for (int y = 0; y < testDeck.DeckOfCards.Length; y++)
                {
                    if (testDeck.DeckOfCards[y].ToString() == oldDeck[y])
                        similarities++;
                    if (y > 0)
                        if (testDeck.DeckOfCards[y].ToString() == oldDeck[y - 1])
                            closeOnes++;
                    if (y < testDeck.DeckOfCards.Length - 1)
                        if (testDeck.DeckOfCards[y].ToString() == oldDeck[y + 1])
                            closeOnes++;
                }
                    

            }
            if (similarities < ((testsToBeRan * 52) / 13) && closeOnes < (testsToBeRan * 5))
                TestInfo.DidTestPass = true;
            else
                TestInfo.DidTestPass = false;
            TestInfo.TestFailureMessage = $"{testsToBeRan * 52} cards tested, {similarities} similarities, {closeOnes} close cards.";
            TestInfo.MethodName = "DoesDeckShuffle()";
            return TestInfo;
        }

        /// <summary>
        /// Checks that the deck sorts properly 
        /// after being shuffled
        /// </summary>
        /// <returns></returns>
        public UnitTestInfo DoesDeckSort()
        {
            int testsToBeRan = 10;
            var testInfo = new UnitTestInfo();
            Deck testDeck = new Deck();
            string[] controlArray = new string[testDeck.DeckOfCards.Length];
            testInfo.DidTestPass = true;

            for (int i = 0; i < testDeck.DeckOfCards.Length; i++)
                controlArray[i] = testDeck.DeckOfCards[i].ToString();

            for (int i = 0; i < testsToBeRan; i++)
            {
                testDeck.Shuffle();
                testDeck.Sort();
                for (int x = 0; x < testDeck.DeckOfCards.Length; x++)
                {
                    if (testDeck.DeckOfCards[x].ToString() != controlArray[x])
                    {
                        testInfo.DidTestPass = false;
                        testInfo.TestFailureMessage = "If test 3 worked as it should, deck does not sort properly after shuffling.";
                    }
                }
            }
            testInfo.MethodName = "DoesDeckSort()";
            return testInfo;
        }

        /// <summary>
        /// Checks that all the cards are in their
        /// intended position in the stack, first
        /// for a new deck and then for a sorted stack.
        /// </summary>
        /// <returns></returns>
        public UnitTestInfo CorrectOrder()
        {
            Deck testDeck = new Deck();
            var testInfo = new UnitTestInfo();
            testInfo.DidTestPass = true;
            string error1 = "The cards are not in the correct order when the deck is formed.", 
                error2 = "The cards are not in the correct order after shuffle and sort.";
            testInfo = CheckOrderOfCards(testDeck, testInfo, error1);
            testDeck.Shuffle();
            testDeck.Sort();
            if (testInfo.TestFailureMessage != error1)
                testInfo = CheckOrderOfCards(testDeck, testInfo, error2);
            testInfo.MethodName = "CorrectOrder()";
            return testInfo;
        }

        /// <summary>
        /// Method used in CorrectOrder.
        /// Checks that the input deck is sorted
        /// in the correct order.
        /// </summary>
        /// <param name="testDeck"> This is the deck to be checked </param>
        /// <param name="testInfo"> This is being updated if the test fails </param>
        /// <param name="errorMessage"> The error message to be input into testInfo </param>
        /// <returns></returns>
        private static UnitTestInfo CheckOrderOfCards(Deck testDeck, UnitTestInfo testInfo, string errorMessage)
        {
            for (int i = 0; i < testDeck.DeckOfCards.Length; i++)
            {
                Card curCard = testDeck.DeckOfCards[i];
                if (curCard.face != testDeck.faces[i % 13] && curCard.suit != testDeck.suits[i % 13] && curCard.value != (i % 13) + 1)
                {
                    testInfo.TestFailureMessage = errorMessage;
                    testInfo.DidTestPass = false;
                }
            }
            return testInfo;
        }

        /// <summary>
        /// A struct for inputting values into. This is
        /// used to show the results from the tests.
        /// </summary>
        public struct UnitTestInfo
        {
            public bool DidTestPass { get; set; }
            public string TestFailureMessage { get; set; }
            public string MethodName { get; set; }
        }
    }
}
