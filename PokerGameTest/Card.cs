namespace PokerGameTest
{
    public class Card
    {
        private string _alphabetNumber;
        private readonly char _suit;

        public Card(string cardString)
        {
            _suit = cardString[0];
            _alphabetNumber = cardString.Substring(1);
        }

        public string AlphabetNumber
        {
            get { return _alphabetNumber; }
        }

        public char Suit
        {
            get { return _suit; }
        }
    }
}