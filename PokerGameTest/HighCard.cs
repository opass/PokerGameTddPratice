using System.Collections.Generic;
using System.Linq;

namespace PokerGameTest
{
    internal class HighCard : HandKind
    {
        public override bool Match(List<Card> cardList)
        {
            return true; // nothing to do
        }

        public override string GetName()
        {
            return "High Card";
        }

        public override int GetPriority()
        {
            return 8;
        }

        public override List<Card> GetKeyCardList(IEnumerable<Card> cardList)
        {
            return cardList.OrderByDescending(card => card.KeyCardValue).ToList();
        }
    }
}