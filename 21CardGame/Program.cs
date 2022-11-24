namespace Program
{
    class Program
    {
        private Card card = new Card();
        private Deck deck = new Deck();
        private Hand playerHand = new Hand();
        private Hand computerHand = new Hand();
        private Boolean haveWinner = false;
        private static String drawCard = "";

        /// <summary>
        /// The main function is the entry point of the program
        /// </summary>
        /// <param name="args">The arguments passed to the program.</param>
        static void Main(string[] args)
        {
            /* Creating a new instance of the Program class. */
            Program program = new Program();
            
            /* Calling the startGame() function. */
            program.startGame();
        }

        /// <summary>
        /// The function starts the game by shuffling the deck, drawing two cards for the player and two
        /// cards for the computer, and then it checks to see if the player or computer has a winning
        /// hand. If neither has a winning hand, the function calls the turnPlayer() and turnComputer()
        /// functions.
        /// </summary>
        public void startGame()
        {
            /* Calling the shuffleDeck() function from the Deck class. */
            deck.shuffleDeck();

            /* Drawing two cards for the player and displaying the total hand value of the player. */
            draw("player");
            draw("player");
            Console.WriteLine("Total hand value is " + playerHand.getHandValue());
            Console.WriteLine("\n----------------------------------------\n");

            /* Drawing two cards for the computer. */
            draw("computer");
            draw("computer");

            turnPlayer();
            if(playerHand.getHandValue() <= 21) turnComputer();
            Console.WriteLine("\n----------------------------------------\n");
            card.displayCards("player");
            Console.WriteLine("\n------------------ VS ------------------\n");
            card.displayCards("computer");
            Console.WriteLine("\n----------------------------------------\n");
            assessWinner();
        }

        /// <summary>
        /// It asks the user to choose between two options, and if the user doesn't choose one of the
        /// two options, it asks the user again.
        /// </summary>
        /// <returns>
        /// The choice of the player.
        /// </returns>
        public String queryChoice()
        {
            /* Asking the user to choose between two options, and if the user doesn't choose one of the
            two options, it asks the user again. */
            Console.Write("Player, would you like to draw or pass?\n[1] Draw\n[2] Pass\nChoice: ");
            string choice = Console.ReadLine();

            /* Checking if the user's choice is not equal to 1 or 2. If it is not equal to 1 or 2, it
            will ask the user to choose again. */
            while(!(choice.Equals("1") || choice.Equals("2")))
            {
                Console.WriteLine("Your answer is not accepted!");
                Console.WriteLine("\n----------------------------------------\n");
                Console.Write("Player, would you like to draw or pass?\n[1] Draw\n[2] Pass\nChoice: ");
                choice = Console.ReadLine();
            }

            Console.WriteLine("Choice accepted...");
            Console.WriteLine("\n----------------------------------------\n");

            return choice;
        }

        /// <summary>
        /// The draw function draws a card from the deck and adds it to the player's hand
        /// </summary>
        /// <param name="String">player</param>
        public void draw(String player)
        {
            /* Checking if the player is equal to player. If it is, it will draw a card from the deck,
            display the card that the player drew, add the card to the player's hand, and add the
            value of the card to the player's hand value. */
            if (player.Equals("player"))
            {
                drawCard = deck.drawNewCard();
                Console.WriteLine("Player drew " + drawCard);
                card.addCard("player", drawCard);
                playerHand.addHandValue(drawCard);
            }

            /* Drawing a card for the computer. */
            if (player.Equals("computer"))
            {
                drawCard = deck.drawNewCard();
                card.addCard("computer", drawCard);
                computerHand.addHandValue(drawCard);
            }
        }

        /// <summary>
        /// The function `pass` takes a string as an argument and prints it to the console
        /// </summary>
        /// <param name="String">The type of data that the parameter is.</param>
        public void pass(String player)
        {
            Console.WriteLine(player + " passed...");
        }

        /// <summary>
        /// If the computer's hand value is greater than 21, pass. If the computer's hand value is less
        /// than 21, draw. If the computer's hand value is 21, pass
        /// </summary>
        public void turnComputer()
        {
            while(computerHand.getHandValue() < 17)
            {
                draw("computer");
                Console.WriteLine("Computer drew a card.");
            }
        }

        /// <summary>
        /// If the player's hand value is less than or equal to 21, and the player chooses to draw, then
        /// draw a card for the player and display the player's hand value
        /// </summary>
        public void turnPlayer()
        {
            /* Checking if the player's hand value is less than or equal to 21. If it is, it will ask
            the user to choose between two options. If the user chooses to draw, it will draw a card
            for the player and display the player's hand value. If the player's hand value is
            greater than 21, it will display a message. */
            while(playerHand.getHandValue() < 21)
            {
                if (queryChoice().Equals("1"))
                {
                    draw("player");
                    Console.WriteLine("Total hand value is " + playerHand.getHandValue());
                    Console.WriteLine("\n----------------------------------------\n");

                    if(playerHand.getHandValue() > 21) Console.WriteLine("No hope for victory");
                }
                else break;
            }
        }

        /// <summary>
        /// This function checks the winner of the game.
        /// </summary>
        public void assessWinner()
        {
            if(playerHand.getHandValue() > 21 && computerHand.getHandValue() < 21) Console.WriteLine("Game ended. You are BUST!");
            else if((playerHand.getHandValue() == 21 && computerHand.getHandValue() == 21) || (playerHand.getHandValue() == computerHand.getHandValue()))
            {
                Console.WriteLine("Game ended in DRAW!");
            }
            else if(
                (computerHand.getHandValue() == 21) ||
                ((computerHand.getHandValue() < 21 && playerHand.getHandValue() > 21) ||
                ((computerHand.getHandValue() < 21 && playerHand.getHandValue() < 21) && (computerHand.getHandValue() > playerHand.getHandValue())))
            )
            {
                Console.WriteLine("Game ended. Dealer wins!");
            }
            else if(
                (playerHand.getHandValue() == 21) ||
                (playerHand.getHandValue() < 21 && computerHand.getHandValue() > 21) ||
                ((playerHand.getHandValue() < 21 && computerHand.getHandValue() < 21) && (playerHand.getHandValue() > computerHand.getHandValue()))
            )
            {
                Console.WriteLine("Congratulations! You win!");
            }
        }
    }
}