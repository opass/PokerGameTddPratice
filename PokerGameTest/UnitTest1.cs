using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PokerGameTest
{
    [TestClass]
    public class PokerGameTestClass
    {
        private const string PlayerOne = "Joey";
        private const string PlayerTwo = "Tom";

        private readonly TestHandKind _flushA3579Hand
            = new TestHandKind("SA,S5,S3,S7,S9", TestHandKind.Flush);

        private readonly TestHandKind _flushA4579Hand = new TestHandKind("SA,S5,S4,S7,S9", TestHandKind.Flush);

        private readonly TestHandKind _flushStraight23456Hand
            = new TestHandKind("S2,S3,S4,S5,S6", TestHandKind.FlushStraight);

        private readonly TestHandKind _flushStraight34567Hand =
            new TestHandKind("S3,S4,S5,S6,S7", TestHandKind.FlushStraight);

        private readonly TestHandKind _fourOfAKindS2_H2_D2_S2_SAHand
            = new TestHandKind("S2,H2,D2,S2,SA", TestHandKind.FourOfAKind);

        private readonly TestHandKind _fourOfAKindS2_H2_D2_S2_SkHand =
            new TestHandKind("S2,H2,D2,S2,SK", TestHandKind.FourOfAKind);

        private readonly TestHandKind _fullHouseC6_S6_H6_H3_S3Hand =
            new TestHandKind("C6,S6,H6,H3,S3", TestHandKind.FullHouse);

        private readonly TestHandKind _fullHouseC6_S6_H6_H4_S4Hand
            = new TestHandKind("C6,S6,H6,H4,S4", TestHandKind.FullHouse);

        private readonly TestHandKind _highCardSA_S5_S3_S7_H9Hand
            = new TestHandKind("SA,S5,S3,S7,H9", TestHandKind.HighCard);

        private readonly TestHandKind _highCardSA_S5_S4_S7_H9Hand =
            new TestHandKind("SA,S5,S4,S7,H9", TestHandKind.HighCard);

        private readonly TestHandKind _onePairC6_S6_S2_S4_S5Hand =
            new TestHandKind("C6,S6,S2,S4,S5", TestHandKind.OnePair);

        private readonly TestHandKind _onePairC6_S6_S3_S4_S5Hand
            = new TestHandKind("C6,S6,S3,S4,S5", TestHandKind.OnePair);

        private readonly PokerGame _pokerGame = new PokerGame(PlayerOne, PlayerTwo);
        private readonly TestHandKind _straight10JQKAHand = new TestHandKind("SA,S10,SQ,HJ,SK", TestHandKind.Straight);
        private readonly TestHandKind _straight910JQKHand = new TestHandKind("S9,S10,SQ,HJ,SK", TestHandKind.Straight);

        private readonly TestHandKind _straightA2345Hand = new TestHandKind("SA,S2,H3,S4,S5", TestHandKind.Straight);

        private readonly TestHandKind _straightNormalHand
            = new TestHandKind("S8,S9,HJ,S10,SQ", TestHandKind.Straight);

        private readonly TestHandKind _threeOfAKindS4_S4_S4_H3_S6Hand =
            new TestHandKind("S4,S4,S4,H3,S6", TestHandKind.ThreeOfAKind);

        private readonly TestHandKind _threeOfAKindS4_S4_S4_H5_H6Hand
            = new TestHandKind("S4,S4,S4,H5,S6", TestHandKind.ThreeOfAKind);

        private readonly TestHandKind _twoPairsS4_S4_S5_S5_D6Hand
            = new TestHandKind("S4,S4,S5,S5,D6", TestHandKind.TwoPairs);

        private readonly TestHandKind _twoPairS4_S4_S5_S5_D3Hand =
            new TestHandKind("S4,S4,S5,S5,D3", TestHandKind.TwoPairs);

        [TestMethod]
        public void Recognize_OnePair()
        {
            ResultShouldBePlayerOneWin(_onePairC6_S6_S3_S4_S5Hand, _highCardSA_S5_S3_S7_H9Hand);
        }

        [TestMethod]
        public void Recognize_FourOfAKind()
        {
            ResultShouldBePlayerOneWin(_fourOfAKindS2_H2_D2_S2_SAHand, _highCardSA_S5_S3_S7_H9Hand);
        }

        [TestMethod]
        public void Recognize_FullHouse()
        {
            ResultShouldBePlayerOneWin(_fullHouseC6_S6_H6_H4_S4Hand, _highCardSA_S5_S3_S7_H9Hand);
        }

        [TestMethod]
        public void Recognize_ThreeOfAKind()
        {
            ResultShouldBePlayerOneWin(_threeOfAKindS4_S4_S4_H5_H6Hand, _highCardSA_S5_S3_S7_H9Hand);
        }

        [TestMethod]
        public void Recognize_TwoPairs()
        {
            ResultShouldBePlayerOneWin(_twoPairsS4_S4_S5_S5_D6Hand, _highCardSA_S5_S3_S7_H9Hand);
        }

        [TestMethod]
        public void Recognize_Flush()
        {
            ResultShouldBePlayerOneWin(_flushA3579Hand, _highCardSA_S5_S3_S7_H9Hand);
        }

        [TestMethod]
        public void Recognize_Straight()
        {
            ResultShouldBePlayerOneWin(_straightNormalHand, _highCardSA_S5_S3_S7_H9Hand);
        }

        [TestMethod]
        public void Recognize_FlushStraight()
        {
            ResultShouldBePlayerOneWin(_flushStraight23456Hand, _highCardSA_S5_S3_S7_H9Hand);
        }

        [TestMethod]
        public void HandKind_Order()
        {
            var testHandKindList = new List<TestHandKind>
            {
                _flushStraight23456Hand,
                _fourOfAKindS2_H2_D2_S2_SAHand,
                _fullHouseC6_S6_H6_H4_S4Hand,
                _flushA3579Hand,
                _straightNormalHand,
                _threeOfAKindS4_S4_S4_H5_H6Hand,
                _twoPairsS4_S4_S5_S5_D6Hand,
                _onePairC6_S6_S3_S4_S5Hand
            };
            foreach (var t in GetAllHandKindCompareSituation(testHandKindList))
                ResultShouldBePlayerTwoWin(t.SmallerHand, t.BiggerHand);
        }

        [TestMethod]
        public void Straight_Starts_With_Ace()
        {
            ResultShouldBePlayerOneWin(_straightA2345Hand, _highCardSA_S5_S3_S7_H9Hand);
        }

        [TestMethod]
        public void Straight_Ends_With_King()
        {
            ResultShouldBePlayerOneWin(_straight910JQKHand, _highCardSA_S5_S3_S7_H9Hand);
        }

        [TestMethod]
        public void Straight_Ends_With_Ace()
        {
            ResultShouldBePlayerOneWin(_straight10JQKAHand, _highCardSA_S5_S3_S7_H9Hand);
        }

        [TestMethod]
        public void Find_Key_Card_In_Straight()
        {
            ResultShouldBePlayerTwoWin(_straightA2345Hand, _straight10JQKAHand, "K");
        }

        [TestMethod]
        public void Find_Key_Card_In_FlushStraight()
        {
            ResultShouldBePlayerOneWin(_flushStraight34567Hand, _flushStraight23456Hand, "7");
        }

        [TestMethod]
        public void Find_Key_Card_In_Flush()
        {
            ResultShouldBePlayerTwoWin(_flushA3579Hand, _flushA4579Hand, "4");
        }

        [TestMethod]
        public void Find_Key_Card_In_One_Pair()
        {
            ResultShouldBePlayerOneWin(_onePairC6_S6_S3_S4_S5Hand, _onePairC6_S6_S2_S4_S5Hand, "3");
        }

        [TestMethod]
        public void Find_Key_Card_In_Four_Of_A_Kind()
        {
            ResultShouldBePlayerOneWin(_fourOfAKindS2_H2_D2_S2_SAHand, _fourOfAKindS2_H2_D2_S2_SkHand, "A");
        }

        [TestMethod]
        public void Find_Key_Card_In_Three_Of_A_Kind()
        {
            ResultShouldBePlayerOneWin(_threeOfAKindS4_S4_S4_H5_H6Hand, _threeOfAKindS4_S4_S4_H3_S6Hand, "5");
        }

        [TestMethod]
        public void Find_Key_Card_In_FullHouse()
        {
            ResultShouldBePlayerOneWin(_fullHouseC6_S6_H6_H4_S4Hand, _fullHouseC6_S6_H6_H3_S3Hand, "4");
        }

        [TestMethod]
        public void Find_Key_Card_In_Two_Pairs()
        {
            ResultShouldBePlayerOneWin(_twoPairsS4_S4_S5_S5_D6Hand, _twoPairS4_S4_S5_S5_D3Hand, "6");
        }

        [TestMethod]
        public void Find_Key_Card_In_High_Card()
        {
            ResultShouldBePlayerTwoWin(_highCardSA_S5_S3_S7_H9Hand, _highCardSA_S5_S4_S7_H9Hand, "4");
        }

        [TestMethod]
        public void Draw()
        {
            DealEveryPlayerHands(_highCardSA_S5_S3_S7_H9Hand, _highCardSA_S5_S3_S7_H9Hand);
            Assert.AreEqual("Draw", _pokerGame.Result());
        }


        private static IEnumerable<PlayerHands> GetAllHandKindCompareSituation(IReadOnlyList<TestHandKind> testHandKindList)
        {
            var playerHands = new List<PlayerHands>();
            for (var i = 0; i < testHandKindList.Count; i++)
            for (var j = i + 1; j < testHandKindList.Count; j++)
                playerHands.Add(new PlayerHands(testHandKindList[i], testHandKindList[j]));

            return playerHands;
        }


        private void DealPlayerOneHand(string hand)
        {
            _pokerGame.DealPlayerOneHand(hand);
        }

        private void DealPlayerTwoHand(string hand)
        {
            _pokerGame.DealPlayerTwoHand(hand);
        }

        private void ResultShouldBePlayerOneWin(TestHandKind playerOneCards, TestHandKind playerTwoCards,
            string keyCard = "")
        {
            DealEveryPlayerHands(playerOneCards, playerTwoCards);
            ResultShouldBe(playerOneCards.HandKindName, PlayerOne, keyCard);
        }

        private void DealEveryPlayerHands(TestHandKind playerOneCards, TestHandKind playerTwoCards)
        {
            DealPlayerOneHand(playerOneCards.CardsString);
            DealPlayerTwoHand(playerTwoCards.CardsString);
        }

        private void ResultShouldBePlayerTwoWin(TestHandKind playerOneCards, TestHandKind playerTwoCards,
            string keyCard = "")
        {
            DealEveryPlayerHands(playerOneCards, playerTwoCards);
            ResultShouldBe(playerTwoCards.HandKindName, PlayerTwo, keyCard);
        }

        private void ResultShouldBe(string handKind, string winner, string keyCard = "")
        {
            var winByHandKindString = $"{winner} Win, Because of {handKind}";
            var winByKeyCardString = $"{winByHandKindString} and key card is {keyCard}";
            Assert.AreEqual(
                keyCard == ""
                    ? winByHandKindString
                    : winByKeyCardString, _pokerGame.Result());
        }
    }

    internal class PlayerHands
    {
        public PlayerHands(TestHandKind biggerHand, TestHandKind smallerHand)
        {
            BiggerHand = biggerHand;
            SmallerHand = smallerHand;
        }

        public TestHandKind SmallerHand { get; }
        public TestHandKind BiggerHand { get; }
    }
}