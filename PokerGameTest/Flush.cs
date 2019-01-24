using System.Collections.Generic;
using System.Linq;

namespace PokerGameTest
{
    public class Flush : HandKind
    {
        public override bool Match(List<Card> cardList)
        {
            return cardList.GroupBy(x => x.Suit).Count() == 1;
        }

        public override string GetName()
        {
            return "Flush";
        }

        public override int GetPriority()
        {
            return 3;
        }

        public override List<Card> GetKeyCardList(IEnumerable<Card> cardList)
        {
            return cardList.OrderByDescending(card => card.KeyCardValue).ToList();
        }
    }
}