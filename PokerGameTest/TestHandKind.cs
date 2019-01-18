namespace PokerGameTest
{
    public class TestHandKind
    {
        public TestHandKind(string cardsString, string handKindName)
        {
            CardsString = cardsString;
            HandKindName = handKindName;
        }

        public string CardsString { get; }
        public string HandKindName { get; }
    }
}