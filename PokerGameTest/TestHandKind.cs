namespace PokerGameTest
{
    public class TestHandKind
    {
        public const string Straight = "Straight";
        public const string FlushStraight = "Flush Straight";
        public const string Flush = "Flush";
        public const string OnePair = "One Pair";
        public const string FourOfAKind = "Four of a Kind";
        public const string ThreeOfAKind = "Three of a Kind";
        public const string FullHouse = "Full House";
        public const string TwoPairs = "Two Pairs";
        public const string HighCard = "High Card";

        public TestHandKind(string cardsString, string handKindName)
        {
            CardsString = cardsString;
            HandKindName = handKindName;
        }

        public string CardsString { get; }
        public string HandKindName { get; }
    }
}