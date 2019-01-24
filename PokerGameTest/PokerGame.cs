using System.Linq;

namespace PokerGameTest
{
    public class PokerGame
    {
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
            var playerOneHand = new Hand(_playerOneCards.Split(",").Select(x => new Card(x)).ToList());
            var playerTwoHand = new Hand(_playerTwoCards.Split(",").Select(x => new Card(x)).ToList());

            if (playerOneHand.HandKind.GetPriority() != playerTwoHand.HandKind.GetPriority())
                return playerOneHand.HandKind.GetPriority() < playerTwoHand.HandKind.GetPriority()
                    ? WinByHandKind(playerOneHand.HandKind.GetName(), _playerOne)
                    : WinByHandKind(playerTwoHand.HandKind.GetName(), _playerTwo);
            var playerOneKeyCardList = playerOneHand.GetKeyCardList();
            var playerTwoKeyCardList = playerTwoHand.GetKeyCardList();
            for (var i = 0; i < playerOneKeyCardList.Count; i++)
            {
                if (playerOneKeyCardList[i].KeyCardValue > playerTwoKeyCardList[i].KeyCardValue)
                    return
                        $"{_playerOne} Win, Because of {playerOneHand.HandKind.GetName()} and key card is {playerOneKeyCardList[i].AlphabetNumber}";

                if (playerOneKeyCardList[i].KeyCardValue < playerTwoKeyCardList[i].KeyCardValue)
                    return
                        $"{_playerTwo} Win, Because of {playerTwoHand.HandKind.GetName()} and key card is {playerTwoKeyCardList[i].AlphabetNumber}";
            }

            return "Draw";

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