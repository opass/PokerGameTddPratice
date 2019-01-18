using System.Collections.Generic;
using System.Linq;

namespace PokerGameTest
{
    public class PokerGame
    {
        private readonly string _playerOne;
        private readonly string _playerTwo;
        private string _playerOneCards;
        private string _playerTwoCards;

        private List<HandKind> _handKindMatchers = new List<HandKind>
        {
            new StraightFlush(),
            new FourOfAKind(),
            new FullHouse(),
            new Flush(),
            new Straight(),
            new ThreeOfAKind(),
            new TwoPairs(),
            new OnePair(),
        };

        public PokerGame(string playerOne, string playerTwo)
        {
            _playerOne = playerOne;
            _playerTwo = playerTwo;
        }

        public string Result()
        {
            HandKind playerOneHandKind = GetHandKind(_playerOneCards.Split(",").Select(x => new Card(x)).ToList());
            HandKind playerTwoHandKind = GetHandKind(_playerTwoCards.Split(",").Select(x => new Card(x)).ToList());
            if (playerTwoHandKind.getName() == StraightFlush.Name)
            {
                return WinByHandKind(playerTwoHandKind.getName(), _playerTwo);
            }

            return WinByHandKind(playerOneHandKind.getName(), _playerOne);
        }

        private HandKind GetHandKind(List<Card> cardList)
        {
            for (var i = 0; i < _handKindMatchers.Count(); i++)
            {
                var matcher = _handKindMatchers[i];
                if (matcher.match(cardList))
                {
                    return matcher;
                }
            }

            return new HighCard();
        }

        private string WinByHandKind(string handKind, string winner)
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