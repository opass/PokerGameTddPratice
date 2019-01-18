using System.Collections.Generic;

namespace PokerGameTest
{
    public abstract class HandKind
    {
        public abstract bool match(List<Card> cardList);
        public abstract string getName();
    }
}