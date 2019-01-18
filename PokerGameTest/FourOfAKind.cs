using System.Collections.Generic;
using System.Linq;

namespace PokerGameTest
{
    public class FourOfAKind : HandKind
    {
        private static string Name { get; } = "Four of a Kind";

        public override bool match(List<Card> cardList)
        {
            return cardList.GroupBy(x => x.AlphabetNumber).Count() == 2 &&
                   cardList.GroupBy(x => x.AlphabetNumber).Select(x => x.Count()).Max() == 4;
        }

        public override string getName()
        {
            return Name;
        }
    }
}