using System.Collections.Generic;

namespace PokerGameTest
{
    public class Card
    {
        private readonly Dictionary<string, string> _alphabetLookupAceAs14 = new Dictionary<string, string>
        {
            {"A", "14"},
            {"J", "11"},
            {"Q", "12"},
            {"K", "13"}
        };

        public Card(string cardString)
        {
            Suit = cardString[0];
            AlphabetNumber = cardString.Substring(1);
            KeyCardValue = int.Parse(_alphabetLookupAceAs14.GetValueOrDefault(AlphabetNumber, AlphabetNumber));
        }

        public string AlphabetNumber { get; }

        public char Suit { get; }

        public int KeyCardValue { get; }
    }
}