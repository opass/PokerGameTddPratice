using System.Collections.Generic;

namespace PokerGameTest
{
    public class Hand
    {
        private static readonly List<HandKind> HandKindMatchers = new List<HandKind>
        {
            new StraightFlush(),
            new FourOfAKind(),
            new FullHouse(),
            new Flush(),
            new Straight(),
            new ThreeOfAKind(),
            new TwoPairs(),
            new OnePair()
        };

        private readonly List<Card> _cardList;

        public Hand(List<Card> cardList)
        {
            _cardList = cardList;
            HandKind = GetHandKind(cardList);
        }

        public HandKind HandKind { get; }

        private static HandKind GetHandKind(List<Card> cardList)
        {
            foreach (var matcher in HandKindMatchers)
                if (matcher.Match(cardList))
                    return matcher;

            return new HighCard();
        }

        public List<Card> GetKeyCardList()
        {
            return HandKind.GetKeyCardList(_cardList);
        }
    }
}