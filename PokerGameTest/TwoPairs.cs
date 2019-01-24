using System.Collections.Generic;
using System.Linq;

namespace PokerGameTest
{
    public class TwoPairs : HandKind
    {
        public override bool Match(List<Card> cardList)
        {
            return cardList.GroupBy(x => x.AlphabetNumber).Count() == 3;
        }

        public override string GetName()
        {
            return "Two Pairs";
        }

        public override int GetPriority()
        {
            return 6;
        }

        public override List<Card> GetKeyCardList(IEnumerable<Card> cardList)
        {
            var groupByAlphabetNumber = cardList.GroupBy(x => x.AlphabetNumber);
            var twoPairs = groupByAlphabetNumber.Where(x => x.Count() == 2).Select(y => y.ToList()[0]).ToList();
            var singleCard = groupByAlphabetNumber.Where(x => x.Count() == 1).Select(y => y.ToList()[0]).ToList();

            return twoPairs.Concat(singleCard).ToList();
        }
    }
}