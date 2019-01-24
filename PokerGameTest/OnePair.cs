using System.Collections.Generic;
using System.Linq;

namespace PokerGameTest
{
    public class OnePair : HandKind
    {
        public override bool Match(List<Card> cardList)
        {
            return cardList.GroupBy(x => x.AlphabetNumber).Count() == 4;
        }

        public override string GetName()
        {
            return "One Pair";
        }

        public override int GetPriority()
        {
            return 7;
        }

        public override List<Card> GetKeyCardList(IEnumerable<Card> cardList)
        {
            var groupByAlphabetNumber = cardList.GroupBy(x => x.AlphabetNumber);
            var pairCard = groupByAlphabetNumber.Where(x => x.Count() == 2).Select(y => y.ToList()[0]).ToList()
                .GetRange(0, 1);
            var nonPairCard = groupByAlphabetNumber.Where(x => x.Count() != 2).Select(y => y.ToList()[0])
                .OrderByDescending(card => card.KeyCardValue).ToList();

            return pairCard.Concat(nonPairCard).ToList();
        }
    }
}