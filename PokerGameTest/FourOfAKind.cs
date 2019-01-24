using System.Collections.Generic;
using System.Linq;

namespace PokerGameTest
{
    public class FourOfAKind : HandKind
    {
        private static string Name { get; } = "Four of a Kind";

        public override bool Match(List<Card> cardList)
        {
            return cardList.GroupBy(x => x.AlphabetNumber).Count() == 2 &&
                   cardList.GroupBy(x => x.AlphabetNumber).Select(x => x.Count()).Max() == 4;
        }

        public override string GetName()
        {
            return Name;
        }

        public override int GetPriority()
        {
            return 1;
        }

        public override List<Card> GetKeyCardList(IEnumerable<Card> cardList)
        {
            var groupByAlphabetNumber = cardList.GroupBy(x => x.AlphabetNumber);
            var pairCard = groupByAlphabetNumber.Where(x => x.Count() == 4).Select(y => y.ToList()[0]).ToList()
                .GetRange(0, 1);
            var nonPairCard = groupByAlphabetNumber.Where(x => x.Count() != 4).Select(y => y.ToList()[0])
                .OrderByDescending(card => card.KeyCardValue).ToList();

            return pairCard.Concat(nonPairCard).ToList();
        }
    }
}