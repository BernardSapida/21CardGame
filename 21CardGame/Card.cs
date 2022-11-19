namespace Program
{
    internal class Card
    {
        public String[] cards_of_player = { };
        public String[] cards_of_computer = { };

        /// <summary>
        /// This function displays the cards of the player or the computer
        /// </summary>
        /// <param name="String">player</param>
        public void displayCards(String player)
        {
            if (player.Equals("player"))
            {
                for (int i = 0; i < cards_of_player.Length; i++)
                {
                    Console.WriteLine(cards_of_player[i]);
                }
            }

            if (player.Equals("computer"))
            {
                for (int i = 0; i < cards_of_computer.Length; i++)
                {
                    Console.WriteLine(cards_of_computer[i]);
                }
            }
        }

        /// <summary>
        /// It takes a string as a parameter and if the string is equal to "player" it creates a new
        /// array of strings that is one element larger than the current array of strings and copies the
        /// contents of the old array to the new array
        /// </summary>
        /// <param name="String">player</param>
        public void extendsCards(String player)
        {
            if (player.Equals("player"))
            {
                String[] temp = new string[cards_of_player.Length + 1];
                cards_of_player.CopyTo(temp, 0);
                cards_of_player = temp;
            }

            if (player.Equals("computer"))
            {
                String[] temp = new string[cards_of_computer.Length + 1];
                cards_of_computer.CopyTo(temp, 0);
                cards_of_computer = temp;
            }
        }

        /// <summary>
        /// It adds new card to the player cards
        /// </summary>
        /// <param name="String">player</param>
        /// <param name="String">card_of_player</param>
        public void addCard(String player, String card_of_player)
        {
            extendsCards(player);
            if (player.Equals("player"))
            {
                cards_of_player[cards_of_player.Length - 1] = card_of_player;
            }

            if (player.Equals("computer"))
            {
                cards_of_computer[cards_of_computer.Length - 1] = card_of_player;
            }
        }
    }
}