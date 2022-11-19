namespace Program
{
    internal class Card
    {
        String[] playerCards = { };
        String[] computerCards = { };

        public void addCard(String currentPlayer, String card)
        {
            extendsCardsLength(currentPlayer);
            if (currentPlayer.Equals("player")) playerCards[playerCards.Length - 1] = card;
            if (currentPlayer.Equals("computer")) computerCards[computerCards.Length - 1] = card;
        }

        public void displayCards(String currentPlayer)
        {
            if (currentPlayer.Equals("player"))
            {
                for (int i = 0; i < playerCards.Length; i++) Console.WriteLine(playerCards[i]);
            }

            if (currentPlayer.Equals("computer"))
            {
                for (int i = 0; i < computerCards.Length; i++) Console.WriteLine(computerCards[i]);
            }
        }

        public void extendsCardsLength(String currentPlayer)
        {
            if (currentPlayer.Equals("player"))
            {
                String[] tempArray = new string[playerCards.Length + 1];
                playerCards.CopyTo(tempArray, 0);
                playerCards = tempArray;
            }

            if (currentPlayer.Equals("computer"))
            {
                String[] tempArray = new string[computerCards.Length + 1];
                computerCards.CopyTo(tempArray, 0);
                computerCards = tempArray;
            }
        }
    }
}