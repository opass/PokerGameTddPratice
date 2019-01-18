using System.Collections.Generic;

namespace PokerGameTest
{
    internal class HighCard : HandKind
    {
        public override bool match(List<Card> cardList)
        {
            return true; // nothing to do
        }

        public override string getName()
        {
            return "High Card";
        }
    }
}