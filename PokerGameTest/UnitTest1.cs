using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PokerGameTest
{
    [TestClass]
    public class PokerGameTestClass
    {
        private const string PlayerOne = "Joey";
        private const string PlayerTwo = "Tom";

        private readonly TestHandKind _flushNormalHand
            = new TestHandKind("SA,S5,S3,S7,S9", "Flush");

        private readonly TestHandKind _flushStraightNormalHand
            = new TestHandKind("S2,S3,S4,S5,S6", "Flush Straight");

        private readonly TestHandKind _fourOfAKindNormalHand
            = new TestHandKind("S2,H2,D2,S2,SA", "Four of a Kind");

        private readonly TestHandKind _fullHouseNormalHand
            = new TestHandKind("C6,S6,H6,H4,S4", "Full House");

        private readonly TestHandKind _highCardNormalHand
            = new TestHandKind("SA,S5,S3,S7,H9", "High Card");

        private readonly TestHandKind _onePairNormalHand
            = new TestHandKind("C6,S6,S2,S4,S5", "One Pair");

        private readonly PokerGame _pokerGame = new PokerGame(PlayerOne, PlayerTwo);

        private readonly TestHandKind _straightNormalHand
            = new TestHandKind("S8,S9,HJ,S10,SQ", "Straight");

        private readonly TestHandKind _threeOfAKindNormalHand
            = new TestHandKind("S4,S4,S4,H5,S6", "Three of a Kind");

        private readonly TestHandKind _twoPairsNormalHand
            = new TestHandKind("S4,S4,S5,S5,D6", "Two Pairs");

        [TestMethod]
        public void Recognize_OnePair()
        {
            ResultShouldBePlayerOneWin(_onePairNormalHand, _highCardNormalHand);
        }

        [TestMethod]
        public void Recognize_FourOfAKind()
        {
            ResultShouldBePlayerOneWin(_fourOfAKindNormalHand, _highCardNormalHand);
        }

        [TestMethod]
        public void Recognize_FullHouse()
        {
            ResultShouldBePlayerOneWin(_fullHouseNormalHand, _highCardNormalHand);
        }

        [TestMethod]
        public void Recognize_ThreeOfAKind()
        {
            ResultShouldBePlayerOneWin(_threeOfAKindNormalHand, _highCardNormalHand);
        }

        [TestMethod]
        public void Recognize_TwoPairs()
        {
            ResultShouldBePlayerOneWin(_twoPairsNormalHand, _highCardNormalHand);
        }

        [TestMethod]
        public void Recognize_Flush()
        {
            ResultShouldBePlayerOneWin(_flushNormalHand, _highCardNormalHand);
        }

        [TestMethod]
        public void Recognize_Straight()
        {
            ResultShouldBePlayerOneWin(_straightNormalHand, _highCardNormalHand);
        }

        [TestMethod]
        public void Recognize_FlushStraight()
        {
            ResultShouldBePlayerOneWin(_flushStraightNormalHand, _highCardNormalHand);
        }

        [TestMethod]
        public void FlushStraight_BiggerThan_EveryOther()
        {
            DealPlayerTwoHand(_flushStraightNormalHand.CardsString);
            var testHands = new List<TestHandKind>
            {
                _fourOfAKindNormalHand,
                _fullHouseNormalHand,
                _flushNormalHand,
                _straightNormalHand,
                _threeOfAKindNormalHand,
                _twoPairsNormalHand,
                _onePairNormalHand
            };
            foreach (var t in testHands) ResultShouldBePlayerTwoWin(t, _flushStraightNormalHand);
        }

        [TestMethod]
        [Ignore]
        public void FourOfAKind_BiggerThan_Others()
        {
            var testHands = new List<TestHandKind>
            {
                _fullHouseNormalHand,
                _flushNormalHand,
                _straightNormalHand,
                _threeOfAKindNormalHand,
                _twoPairsNormalHand,
                _onePairNormalHand
            };
            foreach (var t in testHands) ResultShouldBePlayerTwoWin(t, _fourOfAKindNormalHand);
        }

        private void DealPlayerOneHand(string hand)
        {
            _pokerGame.DealPlayerOneHand(hand);
        }

        private void DealPlayerTwoHand(string hand)
        {
            _pokerGame.DealPlayerTwoHand(hand);
        }

        private void ResultShouldBePlayerOneWin(TestHandKind playerOneCards, TestHandKind playerTwoCards)
        {
            DealPlayerOneHand(playerOneCards.CardsString);
            DealPlayerTwoHand(playerTwoCards.CardsString);
            ResultShouldBe(playerOneCards.HandKindName, PlayerOne);
        }

        private void ResultShouldBePlayerTwoWin(TestHandKind playerOneCards, TestHandKind playerTwoCards)
        {
            DealPlayerOneHand(playerOneCards.CardsString);
            DealPlayerTwoHand(playerTwoCards.CardsString);
            ResultShouldBe(playerTwoCards.HandKindName, PlayerTwo);
        }

        private void ResultShouldBe(string handKind, string winner)
        {
            Assert.AreEqual($"{winner} Win, Because of {handKind}", _pokerGame.Result());
        }
    }
}