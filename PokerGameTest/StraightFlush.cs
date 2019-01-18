using System.Collections.Generic;

namespace PokerGameTest
{
    public class StraightFlush : HandKind
    {
        public static string Name { get; } = "Flush Straight";

        public override bool match(List<Card> cardList)
        {
            return new Straight().match(cardList) && new Flush().match(cardList);
        }

        public override string getName()
        {
            return Name;
        }
    }
}