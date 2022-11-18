namespace Program
{
    class Program
    {
        Card card = new Card();
        Deck deck = new Deck();
        Hand playerHand = new Hand();
        Hand computerHand = new Hand();
        static String drawCard = "";

        static void Main(string[] args)
        {
            Program main = new Program();

            main.startGame();
        }

        public void startGame()
        {
            firstDrawCard();
        }

        public void firstDrawCard()
        {
            // Shuffling deck
            deck.shuffleDeck();

            draw("player");
            draw("player");
            Console.WriteLine("Total hand value is " + playerHand.getHandValue());
            Console.WriteLine("\n=====================================\n");

            draw("computer");
            draw("computer");

            while (true)
            {
                if(!playerTurns()) break;
                Console.WriteLine("\n=====================================\n");
                if (computerHand.getHandValue() < 21) computerTurns();
            }
        }

        public String queryChoice()
        {
            Console.Write("Player, would you like to draw or pass?\n[1] Draw\n[2] Pass\nChoice: ");
            string choice = Console.ReadLine();

            while(!(choice.Equals("1") || choice.Equals("2")))
            {
                Console.WriteLine("Your answer is not accepted!");
                Console.WriteLine("\n=====================================\n");

                Console.Write("Player, would you like to draw or pass?\n[1] Draw\n[2] Pass\nChoice: ");
                choice = Console.ReadLine();
            }

            Console.WriteLine("Choice accepted...");
            Console.WriteLine("\n=====================================\n");

            return choice;
        }

        public void draw(String player)
        {
            if (player.Equals("player"))
            {
                drawCard = deck.drawCard();
                Console.WriteLine("Player drew " + drawCard);
                card.addCard("player", drawCard);
                playerHand.addHandValue(drawCard);
            }

            if (player.Equals("computer"))
            {
                drawCard = deck.drawCard();
                card.addCard("computer", drawCard);
                computerHand.addHandValue(drawCard);
            }
        }

        public void pass(String player)
        {
            Console.WriteLine(player + " passed...");
        }

        public void computerTurns()
        {
            Random random = new Random();

            if((random.NextInt64(1, 3) == 1 && computerHand.getHandValue() != 21) || playerHand.getHandValue() > 21)
            {
                draw("computer");
                Console.WriteLine("Computer drew a card.");
            }
            else pass("computer");
        }

        public Boolean playerTurns()
        {
            if (playerHand.getHandValue() > 21 && computerHand.getHandValue() > 21)
            {
                Console.WriteLine("Hand of Player with a value of " + playerHand.getHandValue());
                card.displayCards("player");
                Console.WriteLine("\n------ VS ------\n");
                Console.WriteLine("Hand of Computer with a value of " + computerHand.getHandValue());
                card.displayCards("computer");
                Console.WriteLine("\n=====================================\n");
                Console.WriteLine("You lose! Try again next time!");
                return false;
            }
            else if (playerHand.getHandValue() == 21 && computerHand.getHandValue() == 21)
            {
                Console.WriteLine("Game ends in a draw!");
                return false;
            }
            else if (playerHand.getHandValue() == 21 && computerHand.getHandValue() > 21)
            {
                Console.WriteLine("Hand of Player with a value of " + playerHand.getHandValue());
                card.displayCards("player");
                Console.WriteLine("\n\n------ VS ------\n\n");
                Console.WriteLine("Hand of Computer with a value of " + computerHand.getHandValue());
                card.displayCards("computer");
                Console.WriteLine("\n=====================================\n");
                Console.WriteLine("Congratulations! You win!");
                return false;
            }

            if (playerHand.getHandValue() <= 21)
            {
                if (queryChoice().Equals("1"))
                {
                    draw("player");
                    Console.WriteLine("Total hand value is " + playerHand.getHandValue());
                }
            }
            else Console.WriteLine("No hope for victory");

            return true;
        }
    }
}