namespace Program
{
    internal class Card
    {
        String[] cards_of_player = { };
        String[] cards_of_computer = { };

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

        public void addCard(String player, String playerCard)
        {
            extendsCards(player);
            if (player.Equals("player"))
            {
                cards_of_player[cards_of_player.Length - 1] = playerCard;
            }

            if (player.Equals("computer"))
            {
                cards_of_computer[cards_of_computer.Length - 1] = playerCard;
            }
        }
    }
}