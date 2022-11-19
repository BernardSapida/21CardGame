namespace Program
{
    internal class Hand
    {
        int value_in_hand;

        /// <summary>
        /// It takes a string, splits it into an array, and then checks the first element of the array
        /// to see if it's an Ace, Queen, King, or Jack. If it is, it adds 11, 10, 10, or 10 to the
        /// value_in_hand variable. If it's not, it converts the first element of the array to an
        /// integer and adds it to the value_in_hand variable
        /// </summary>
        /// <param name="String">playerCard</param>
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

        /// <summary>
        /// It returns the value of the hand.
        /// </summary>
        /// <returns>
        /// The value of the hand.
        /// </returns>
        public int obtainHandValue()
        {
            return value_in_hand;
        }
        
        /// <summary>
        /// Prints the value of the hand to the console.
        /// </summary>
        public void printHandValue()
        {
            Console.WriteLine("Total hand value is " + value_in_hand);
        }
    }
}