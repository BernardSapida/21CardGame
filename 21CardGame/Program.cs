namespace Program
{
    class Program
    {
        Card card = new Card();
        Deck deck = new Deck();
        Hand playerHand = new Hand();
        Hand computerHand = new Hand();
        Boolean haveWinner = false;
        static String drawCard = "";

        static void Main(string[] args)
        {
            Program main = new Program();

            main.startGame();
        }

        public void startGame()
        {
            firstDrawCard();

            while(!haveWinner)
            {
                playerTurns();
                computerTurns();
                Console.WriteLine("\n=====================================\n");

                if (playerHand.getHandValue() >= 21 && computerHand.getHandValue() >= 21)
                {
                    checkWinner();
                    break;
                }
            }
        }

        public void firstDrawCard()
        {
            // Shuffling deck
            deck.shuffleDeck();

            draw("player");
            draw("player");
            Console.WriteLine("Total hand value is " + playerHand.getHandValue());

            draw("computer");
            draw("computer");
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

            if(((random.NextInt64(1, 3) == 1 && computerHand.getHandValue() != 21) && computerHand.getHandValue() < 21) || (playerHand.getHandValue() > 21 && computerHand.getHandValue() < 21) || computerHand.getHandValue() < 21)
            {
                draw("computer");
                Console.WriteLine("Computer drew a card.");
            }
            else pass("computer");
        }

        public void playerTurns()
        {
            if (playerHand.getHandValue() <= 21)
            {
                if (queryChoice().Equals("1"))
                {
                    draw("player");
                    Console.WriteLine("Total hand value is " + playerHand.getHandValue());
                }
            }
            else
            {
                Console.WriteLine("No hope for victory");
                Console.WriteLine("\n=====================================\n");
            }

        }

        public void checkWinner()
        {
            if((playerHand.getHandValue() > 21 && computerHand.getHandValue() > 21) || (playerHand.getHandValue() > 21 && computerHand.getHandValue() == 21))
            {
                Console.WriteLine("Hand of Player with a value of " + playerHand.getHandValue());
                card.displayCards("player");
                Console.WriteLine("\n------------------ VS ------------------\n");
                Console.WriteLine("Hand of Computer with a value of " + computerHand.getHandValue());
                card.displayCards("computer");
                Console.WriteLine("You lose! Try again next time!");
            }
            else if (playerHand.getHandValue() == 21 && computerHand.getHandValue() == 21)
            {
                Console.WriteLine("Game ends in a draw!");
            }
            else if (playerHand.getHandValue() == 21 && computerHand.getHandValue() > 21)
            {
                Console.WriteLine("Hand of Player with a value of " + playerHand.getHandValue());
                card.displayCards("player");
                Console.WriteLine("\n------------------ VS ------------------\n");
                Console.WriteLine("Hand of Computer with a value of " + computerHand.getHandValue());
                card.displayCards("computer");
                Console.WriteLine("Congratulations! You win!");
            }
        }
    }
}