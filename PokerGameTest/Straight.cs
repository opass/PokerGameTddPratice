using System.Collections.Generic;
using System.Linq;

namespace PokerGameTest
{
    public class Straight : HandKind
    {
        private Dictionary<string, string> _alphabetLookup = new Dictionary<string, string>
        {
            {"A", "1"},
            {"J", "11"},
            {"Q", "12"},
            {"K", "13"},
        };

        public override bool match(List<Card> cardList)
        {
            var numbers = cardList.Select(x =>
                int.Parse(_alphabetLookup.GetValueOrDefault(x.AlphabetNumber, x.AlphabetNumber)));
            var concat = string.Join(',', numbers.OrderBy(x => x).Select(x => x.ToString()).ToArray());
            return "1,2,3,4,5,6,7,8,9,10,11,12,13".Contains(concat);
        }

        public override string getName()
        {
            return "Straight";
        }
    }
}