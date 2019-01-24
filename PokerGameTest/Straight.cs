using System.Collections.Generic;
using System.Linq;

namespace PokerGameTest
{
    public class Straight : HandKind
    {
        private readonly Dictionary<string, string> _alphabetLookup = new Dictionary<string, string>
        {
            {"A", "1"},
            {"J", "11"},
            {"Q", "12"},
            {"K", "13"}
        };

        private readonly Dictionary<string, string> _alphabetLookupAceAs14 = new Dictionary<string, string>
        {
            {"A", "14"},
            {"J", "11"},
            {"Q", "12"},
            {"K", "13"}
        };


        public override bool Match(List<Card> cardList)
        {
            return "1,2,3,4,5,6,7,8,9,10,11,12,13".Contains(
                       JoinNumbersWithComma(cardListToNumbers(cardList, _alphabetLookup))) ||
                   "1,2,3,4,5,6,7,8,9,10,11,12,13,14".Contains(
                       JoinNumbersWithComma(cardListToNumbers(cardList, _alphabetLookupAceAs14)));
        }

        private static IEnumerable<int> cardListToNumbers(IEnumerable<Card> cardList, IReadOnlyDictionary<string, string> lookup)
        {
            var numbers = cardList.Select(x =>
                int.Parse(lookup.GetValueOrDefault(x.AlphabetNumber, x.AlphabetNumber)));
            return numbers;
        }

        private static string JoinNumbersWithComma(IEnumerable<int> numbers)
        {
            var concat = string.Join(',', numbers.OrderBy(x => x).Select(x => x.ToString()).ToArray());
            return concat;
        }

        public override string GetName()
        {
            return "Straight";
        }

        public override int GetPriority()
        {
            return 4;
        }

        public override List<Card> GetKeyCardList(IEnumerable<Card> cardList)
        {
            return cardList.OrderByDescending(card => card.KeyCardValue).ToList().GetRange(0, 2);
        }
    }
}