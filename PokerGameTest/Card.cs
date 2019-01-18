namespace PokerGameTest
{
    public class Card
    {
        public Card(string cardString)
        {
            Suit = cardString[0];
            AlphabetNumber = cardString.Substring(1);
        }

        public string AlphabetNumber { get; }

        public char Suit { get; }
    }
}