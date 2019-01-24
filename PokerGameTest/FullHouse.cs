using System.Collections.Generic;
using System.Linq;

namespace PokerGameTest
{
    public class FullHouse : HandKind
    {
        public override bool Match(List<Card> cardList)
        {
            return cardList.GroupBy(x => x.AlphabetNumber).Count() == 2 &&
                   cardList.GroupBy(x => x.AlphabetNumber).Select(x => x.Count()).Max() == 3;
        }

        public override string GetName()
        {
            return "Full House";
        }

        public override int GetPriority()
        {
            return 2;
        }

        public override List<Card> GetKeyCardList(IEnumerable<Card> cardList)
        {
            var groupByAlphabetNumber = cardList.GroupBy(x => x.AlphabetNumber);
            var threePair = groupByAlphabetNumber.Where(x => x.Count() == 3).Select(y => y.ToList()[0]).ToList()
                .GetRange(0, 1);
            var twoPair = groupByAlphabetNumber.Where(x => x.Count() == 2).Select(y => y.ToList()[0]).ToList()
                .GetRange(0, 1);

            return threePair.Concat(twoPair).ToList();
        }
    }
}