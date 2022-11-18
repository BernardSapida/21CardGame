namespace Program
{
    internal class Card
    {
        String[] player_cards = { };
        String[] computer_cards = { };

        public void addCard(String player, String card)
        {
            extendsCards(player);
            if (player.Equals("player")) player_cards[player_cards.Length - 1] = card;
            if (player.Equals("computer")) computer_cards[computer_cards.Length - 1] = card;
        }

        public void displayCards(String player)
        {
            if (player.Equals("player"))
            {
                for (int i = 0; i < player_cards.Length; i++)
                {
                    Console.WriteLine(player_cards[i]);
                }
            }

            if (player.Equals("computer"))
            {
                for (int i = 0; i < computer_cards.Length; i++)
                {
                    Console.WriteLine(computer_cards[i]);
                }
            }
        }

        public void extendsCards(String player)
        {
            if (player.Equals("player"))
            {
                String[] temp = new string[player_cards.Length + 1];
                player_cards.CopyTo(temp, 0);
                player_cards = temp;
            }

            if (player.Equals("computer"))
            {
                String[] temp = new string[computer_cards.Length + 1];
                computer_cards.CopyTo(temp, 0);
                computer_cards = temp;
            }
        }
    }
}