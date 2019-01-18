using System.Collections.Generic;
using System.Linq;

namespace PokerGameTest
{
    public class ThreeOfAKind : HandKind
    {
        public override bool match(List<Card> cardList)
        {
            return cardList.GroupBy(x => x.AlphabetNumber).Select(x => x.Count()).Max() == 3;
        }

        public override string getName()
        {
            return "Three of a Kind";
        }
    }
}