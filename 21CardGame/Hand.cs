namespace Program
{
    internal class Hand
    {
        int value_in_hand;

        public void incrementHandValue(String playerCard)
        {
            String card_drew = playerCard.Split(" ")[0];

            if (card_drew.Equals("Ace"))
            {
                value_in_hand += 11;
            }
            else if (card_drew.Equals("Queen") || card_drew.Equals("King") || card_drew.Equals("Jack"))
            {
                value_in_hand += 10;
            }
            else
            {
                value_in_hand += Convert.ToInt16(card_drew);
            }
        }

        public int obtainHandValue()
        {
            return value_in_hand;
        }
        
        public void printHandValue()
        {
            Console.WriteLine("Total hand value is " + value_in_hand);
        }
    }
}