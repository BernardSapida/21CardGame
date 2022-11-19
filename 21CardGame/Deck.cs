namespace Program
{
    internal class Deck
    {
        String[] deck =
        {
            "Ace of Spades",
            "2 of Spades",
            "3 of Spades",
            "4 of Spades",
            "5 of Spades",
            "6 of Spades",
            "7 of Spades",
            "8 of Spades",
            "9 of Spades",
            "10 of Spades",
            "Jack of Spades",
            "King of Spades",
            "Queen of Spades",

            "Ace of Hearts",
            "2 of Hearts",
            "3 of Hearts",
            "4 of Hearts",
            "5 of Hearts",
            "6 of Hearts",
            "7 of Hearts",
            "8 of Hearts",
            "9 of Hearts",
            "10 of Hearts",
            "Jack of Hearts",
            "King of Hearts",
            "Queen of Hearts",

            "Ace of Clubs",
            "2 of Clubs",
            "3 of Clubs",
            "4 of Clubs",
            "5 of Clubs",
            "6 of Clubs",
            "7 of Clubs",
            "8 of Clubs",
            "9 of Clubs",
            "10 of Clubs",
            "Jack of Clubs",
            "King of Clubs",
            "Queen of Clubs",

            "Ace of Diamonds",
            "2 of Diamonds",
            "3 of Diamonds",
            "4 of Diamonds",
            "5 of Diamonds",
            "6 of Diamonds",
            "7 of Diamonds",
            "8 of Diamonds",
            "9 of Diamonds",
            "10 of Diamonds",
            "Jack of Diamonds",
            "King of Diamonds",
            "Queen of Diamonds",
        };
        String[] shuffledDeck = new string[52];
        Random random = new Random();

        public void shuffleDeck()
        {
            Console.WriteLine("*************************************\n");
            Console.WriteLine("Start shuffling deck...");
            shuffledDeck = deck.OrderBy(c => random.Next()).ToArray();
            Console.WriteLine("Done shuffling deck...");
            Console.WriteLine("\n*************************************\n");
        }

        public String drawCard()
        {
            long index = random.NextInt64(0, 52);
            String card_drew = shuffledDeck[index];

            while (card_drew == "DREW")
            {
                index = random.NextInt64(0, 52);
                card_drew = shuffledDeck[index];
            }

            shuffledDeck[index] = "DREW";

            return card_drew;
        }
    }
}