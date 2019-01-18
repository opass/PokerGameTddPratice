using System.Collections.Generic;
using System.Linq;

namespace PokerGameTest
{
    public class PokerGame
    {
        private readonly List<HandKind> _handKindMatchers = new List<HandKind>
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

        private readonly string _playerOne;
        private readonly string _playerTwo;
        private string _playerOneCards;
        private string _playerTwoCards;

        public PokerGame(string playerOne, string playerTwo)
        {
            _playerOne = playerOne;
            _playerTwo = playerTwo;
        }

        public string Result()
        {
            var playerOneHandKind = GetHandKind(_playerOneCards.Split(",").Select(x => new Card(x)).ToList());
            var playerTwoHandKind = GetHandKind(_playerTwoCards.Split(",").Select(x => new Card(x)).ToList());
            return playerTwoHandKind.getName() == StraightFlush.Name
                ? WinByHandKind(playerTwoHandKind.getName(), _playerTwo)
                : WinByHandKind(playerOneHandKind.getName(), _playerOne);
        }

        private HandKind GetHandKind(List<Card> cardList)
        {
            foreach (var matcher in _handKindMatchers)
                if (matcher.match(cardList))
                    return matcher;

            return new HighCard();
        }

        private static string WinByHandKind(string handKind, string winner)
        {
            return $"{winner} Win, Because of {handKind}";
        }

        public void DealPlayerOneHand(string firstPlayerHand)
        {
            _playerOneCards = firstPlayerHand;
        }

        public void DealPlayerTwoHand(string secondPlayerHand)
        {
            _playerTwoCards = secondPlayerHand;
        }
    }
}