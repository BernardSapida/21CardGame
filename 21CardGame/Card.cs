namespace Program
{
    internal class Card
    {
        private String[] playerCards = { };
        private String[] computerCards = { };

        /// <summary>
        /// It adds a card to the player's or computer's hand
        /// </summary>
        /// <param name="String">currentPlayer</param>
        /// <param name="String">currentPlayer</param>
        public void addCard(String currentPlayer, String card)
        {
            /* Calling the function `extendsCardsLength` and passing the parameter `currentPlayer` to
            it. */
            extendsCardsLength(currentPlayer);
            
            /* Adding a card to the player's hand. */
            if (currentPlayer.Equals("player")) playerCards[playerCards.Length - 1] = card;

            /* Adding a card to the computer's hand. */
            if (currentPlayer.Equals("computer")) computerCards[computerCards.Length - 1] = card;
        }

        /// <summary>
        /// This function displays the cards of the player or computer
        /// </summary>
        /// <param name="String">currentPlayer</param>
        public void displayCards(String currentPlayer)
        {
            /* It's displaying the cards of the player. */
            if (currentPlayer.Equals("player"))
            {
                for (int i = 0; i < playerCards.Length; i++) Console.WriteLine(playerCards[i]);
            }

            /* It's displaying the cards of the computer. */
            if (currentPlayer.Equals("computer"))
            {
                for (int i = 0; i < computerCards.Length; i++) Console.WriteLine(computerCards[i]);
            }
        }

        /// <summary>
        /// It takes a string as a parameter and if the string is equal to "player" it creates a new
        /// array that is one element larger than the playerCards array and copies the contents of the
        /// playerCards array into the new array. 
        /// 
        /// If the string is equal to "computer" it creates a new array that is one element larger than
        /// the computerCards array and copies the contents of the computerCards array into the new
        /// array. 
        /// 
        /// The reason I'm doing this is because I want to add a new element to the array.
        /// </summary>
        /// <param name="String">currentPlayer</param>
        public void extendsCardsLength(String currentPlayer)
        {
            /* It's creating a new array that is one element larger than the playerCards array and
            copies the contents of the playerCards array into the new array. */
            if (currentPlayer.Equals("player"))
            {
                String[] tempArray = new string[playerCards.Length + 1];
                playerCards.CopyTo(tempArray, 0);
                playerCards = tempArray;
            }

            /* It's creating a new array that is one element larger than the computerCards array and
            copies the contents of the computerCards array into the new array. */
            if (currentPlayer.Equals("computer"))
            {
                String[] tempArray = new string[computerCards.Length + 1];
                computerCards.CopyTo(tempArray, 0);
                computerCards = tempArray;
            }
        }
    }
}