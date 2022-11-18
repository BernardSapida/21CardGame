namespace Program
{
    internal class Hand
    {
        int handValue;

        public void displayHandValue()
        {
            Console.WriteLine("Total hand value is " + handValue);
        }

        public int getHandValue()
        {
            return handValue;
        }

        public void addHandValue(String card)
        {
            String drewCard = card.Split(" ")[0];
            if (drewCard.Equals("Ace")) handValue += 11;
            else if (drewCard.Equals("Jack") || drewCard.Equals("King") || drewCard.Equals("Queen")) handValue += 10;
            else handValue += Convert.ToInt16(drewCard);
        }
    }
}