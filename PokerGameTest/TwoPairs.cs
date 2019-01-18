using System.Collections.Generic;
using System.Linq;

namespace PokerGameTest
{
    public class TwoPairs : HandKind
    {
        public override bool match(List<Card> cardList)
        {
            return cardList.GroupBy(x => x.AlphabetNumber).Count() == 3;
        }

        public override string getName()
        {
            return "Two Pairs";
        }
    }
}