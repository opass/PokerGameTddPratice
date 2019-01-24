using System.Collections.Generic;
using System.Linq;

namespace PokerGameTest
{
    public class ThreeOfAKind : HandKind
    {
        public override bool Match(List<Card> cardList)
        {
            return cardList.GroupBy(x => x.AlphabetNumber).Select(x => x.Count()).Max() == 3;
        }

        public override string GetName()
        {
            return "Three of a Kind";
        }

        public override int GetPriority()
        {
            return 5;
        }

        public override List<Card> GetKeyCardList(IEnumerable<Card> cardList)
        {
            var groupByAlphabetNumber = cardList.GroupBy(x => x.AlphabetNumber);
            var pairCard = groupByAlphabetNumber.Where(x => x.Count() == 3).Select(y => y.ToList()[0]).ToList();
            var nonPairCard = groupByAlphabetNumber.Where(x => x.Count() != 3).Select(y => y.ToList()[0])
                .OrderByDescending(card => card.KeyCardValue).ToList();

            return pairCard.Concat(nonPairCard).ToList();
        }
    }
}