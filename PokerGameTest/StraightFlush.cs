using System.Collections.Generic;
using System.Linq;

namespace PokerGameTest
{
    public class StraightFlush : HandKind
    {
        private static string Name { get; } = "Flush Straight";

        public override bool Match(List<Card> cardList)
        {
            return new Straight().Match(cardList) && new Flush().Match(cardList);
        }

        public override string GetName()
        {
            return Name;
        }

        public override int GetPriority()
        {
            return 0;
        }

        public override List<Card> GetKeyCardList(IEnumerable<Card> cardList)
        {
            return cardList.OrderByDescending(card => card.KeyCardValue).ToList().GetRange(0, 2);
        }
    }
}