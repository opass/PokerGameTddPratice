using System.Collections.Generic;

namespace PokerGameTest
{
    public abstract class HandKind
    {
        public abstract bool Match(List<Card> cardList);
        public abstract string GetName();
        public abstract int GetPriority();

        public abstract List<Card> GetKeyCardList(IEnumerable<Card> cardList);
    }
}