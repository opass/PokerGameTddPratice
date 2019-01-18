using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PokerGameTest
{
    [TestClass]
    public class PokerGameTestClass
    {
        private PokerGame _pokerGame = new PokerGame("Joey", "Tom");

        [TestMethod]
        public void Recognize_OnePair()
        {
            DealPlayerOneHand(TestHandKind.OnePair.NormalHand);
            DealPlayerTwoHand(TestHandKind.HighCard.NormalHand);
            ResultShouldBe("One Pair", "Joey");
        }


        [TestMethod]
        public void Recognize_FourOfAKind()
        {
            DealPlayerOneHand(TestHandKind.FourOfAKind.NormalHand);
            DealPlayerTwoHand(TestHandKind.HighCard.NormalHand);
            ResultShouldBe("Four of a Kind", "Joey");
        }


        [TestMethod]
        public void Recognize_FullHouse()
        {
            DealPlayerOneHand(TestHandKind.FullHouse.NormalHand);
            DealPlayerTwoHand(TestHandKind.HighCard.NormalHand);
            ResultShouldBe("Full House", "Joey");
        }

        [TestMethod]
        public void Recognize_ThreeOfAKind()
        {
            DealPlayerOneHand(TestHandKind.ThreeOfAKind.NormalHand);
            DealPlayerTwoHand(TestHandKind.HighCard.NormalHand);
            ResultShouldBe("Three of a Kind", "Joey");
        }

        [TestMethod]
        public void Recognize_TwoPairs()
        {
            DealPlayerOneHand(TestHandKind.TwoPairs.NormalHand);
            DealPlayerTwoHand(TestHandKind.HighCard.NormalHand);
            ResultShouldBe("Two Pairs", "Joey");
        }

        [TestMethod]
        public void Recognize_Flush()
        {
            DealPlayerOneHand(TestHandKind.Flush.NormalHand);
            DealPlayerTwoHand(TestHandKind.HighCard.NormalHand);
            ResultShouldBe("Flush", "Joey");
        }

        [TestMethod]
        public void Recognize_Straight()
        {
            DealPlayerOneHand(TestHandKind.Straight.NormalHand);
            DealPlayerTwoHand(TestHandKind.HighCard.NormalHand);
            ResultShouldBe("Straight", "Joey");
        }

        [TestMethod]
        public void Recognize_FlushStraight()
        {
            DealPlayerOneHand(TestHandKind.FlushStraight.NormalHand);
            DealPlayerTwoHand(TestHandKind.HighCard.NormalHand);
            ResultShouldBe(TestHandKind.FlushStraight.Name, "Joey");
        }

        [TestMethod]
        public void FlushStraight_BiggerThan_EveryOther()
        {
            DealPlayerTwoHand(TestHandKind.FlushStraight.NormalHand);

            DealPlayerOneHand(TestHandKind.FourOfAKind.NormalHand);
            ResultShouldBe(TestHandKind.FlushStraight.Name, "Tom");
            
            DealPlayerOneHand(TestHandKind.FullHouse.NormalHand);
            ResultShouldBe(TestHandKind.FlushStraight.Name, "Tom");
            
            DealPlayerOneHand(TestHandKind.Flush.NormalHand);
            ResultShouldBe(TestHandKind.FlushStraight.Name, "Tom");
            
            DealPlayerOneHand(TestHandKind.Straight.NormalHand);
            ResultShouldBe(TestHandKind.FlushStraight.Name, "Tom");
            
            DealPlayerOneHand(TestHandKind.ThreeOfAKind.NormalHand);
            ResultShouldBe(TestHandKind.FlushStraight.Name, "Tom");
            
            DealPlayerOneHand(TestHandKind.TwoPairs.NormalHand);
            ResultShouldBe(TestHandKind.FlushStraight.Name, "Tom");
            
            DealPlayerOneHand(TestHandKind.OnePair.NormalHand);
            ResultShouldBe(TestHandKind.FlushStraight.Name, "Tom");
            
            
        }
        [TestMethod]
        [Ignore]
        public void FourOfAKind_BiggerThan_Others()
        {
            
            DealPlayerTwoHand(TestHandKind.FourOfAKind.NormalHand);
            
            DealPlayerOneHand(TestHandKind.FullHouse.NormalHand);
            ResultShouldBe(TestHandKind.FourOfAKind.Name, "Tom");
            
            DealPlayerOneHand(TestHandKind.Flush.NormalHand);
            ResultShouldBe(TestHandKind.FourOfAKind.Name, "Tom");
            
            DealPlayerOneHand(TestHandKind.Straight.NormalHand);
            ResultShouldBe(TestHandKind.FourOfAKind.Name, "Tom");
            
            DealPlayerOneHand(TestHandKind.ThreeOfAKind.NormalHand);
            ResultShouldBe(TestHandKind.FourOfAKind.Name, "Tom");
            
            DealPlayerOneHand(TestHandKind.TwoPairs.NormalHand);
            ResultShouldBe(TestHandKind.FourOfAKind.Name, "Tom");
            
            DealPlayerOneHand(TestHandKind.OnePair.NormalHand);
            ResultShouldBe(TestHandKind.FourOfAKind.Name, "Tom");
            
        }
       

        private void DealPlayerOneHand(string hand)
        {
            _pokerGame.DealPlayerOneHand(hand);
        }

        private void DealPlayerTwoHand(string hand)
        {
            _pokerGame.DealPlayerTwoHand(hand);
        }


        private void ResultShouldBe(string handKind, string winner)
        {
            Assert.AreEqual($"{winner} Win, Because of {handKind}", _pokerGame.Result());
        }
    }
}