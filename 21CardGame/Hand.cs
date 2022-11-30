namespace Program
{
    internal class Hand
    {
        int handValue;

        /// <summary>
        /// This function displays the total value of the hand
        /// </summary>
        public void displayHandValue()
        {
            /* Printing the total value of the hand. */
            Console.WriteLine("Total hand value is " + handValue);
        }

        /// <summary>
        /// It returns the value of the hand.
        /// </summary>
        /// <returns>
        /// The handValue is being returned.
        /// </returns>
        public int getHandValue()
        {
            return handValue;
        }

        /// <summary>
        /// This function takes a string as a parameter, splits the string into an array of strings, and
        /// then adds the value of the card to the handValue variable
        /// </summary>
        /// <param name="string">card</param>
        public void addHandValue(string card)
        {
            /* Splitting the string into an array of strings, and then adding the value of the card to
            the handValue variable. */
            string drewCard = card.Split(" ")[0];
            int numberOfAce = 0;

            /* Adding the value of the card to the handValue variable. */
            if (drewCard.Equals("Ace"))
            {
                handValue += 1;
                numberOfAce += 1;
            }
            else if (drewCard.Equals("Jack") || drewCard.Equals("King") || drewCard.Equals("Queen")) handValue += 10;
            else handValue += Convert.ToInt16(drewCard);

            if (numberOfAce >= 1 && (handValue + 10 == 21)) handValue += 10;
        }
    }
}