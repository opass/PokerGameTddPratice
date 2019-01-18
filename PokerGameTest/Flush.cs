using System.Collections.Generic;
using System.Linq;

namespace PokerGameTest
{
    public class Flush : HandKind
    {
        public override bool match(List<Card> cardList)
        {
            return cardList.GroupBy(x => x.Suit).Count() == 1;
        }

        public override string getName()
        {
            return "Flush";
        }
        
    }
}