namespace PokerGameTest
{
    public struct TestHandKind
    {
        public static class FlushStraight
        {
            public static string Name
            {
                get { return "Flush Straight"; }
            }

            public static string NormalHand
            {
                get { return "S2,S3,S4,S5,S6"; }
            }
        }

        public static class FourOfAKind
        {
            public static string NormalHand
            {
                get { return "S2,H2,D2,S2,SA"; }
            }
        }

        public static class HighCard
        {
            public static string NormalHand
            {
                get { return "SA,S5,S3,S7,H9"; }
            }
        }

        public static class Straight
        {
            public static string NormalHand
            {
                get { return "S8,S9,HJ,S10,SQ"; }
            }
        }

        public static class Flush
        {
            public static string NormalHand
            {
                get { return "SA,S5,S3,S7,S9"; }
            }
        }

        public static class TwoPairs
        {
            public static string NormalHand
            {
                get { return "S4,S4,S5,S5,D6"; }
            }
        }

        public static class ThreeOfAKind
        {
            public static string NormalHand
            {
                get { return "S4,S4,S4,H5,S6"; }
            }
        }

        public static class FullHouse
        {
            public static string NormalHand
            {
                get { return "C6,S6,H6,H4,S4"; }
            }
        }

        public static class OnePair
        {
            public static string NormalHand
            {
                get { return "C6,S6,S2,S4,S5"; }
            }
        }

    }
}