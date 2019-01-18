using System.Collections.Generic;
using System.Linq;

namespace PokerGameTest
{
    public class OnePair : HandKind
    {
        public override bool match(List<Card> cardList)
        {
            return cardList.GroupBy(x => x.AlphabetNumber).Count() == 4;
        }

        public override string getName()
        {
            return "One Pair";
        }
    }
}