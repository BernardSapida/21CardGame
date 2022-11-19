using System.Numerics;

namespace Program
{
    class Program
    {
        public Hand hand_of_player = new Hand();
        public Hand hand_of_computer = new Hand();
        public Deck deck = new Deck();
        public Card card = new Card();
        public static String drawCard = "";

        /// <summary>
        /// The main function is the entry point of the program
        /// </summary>
        /// <param name="args">The command-line arguments.</param>
        static void Main(string[] args)
        {
            Program main = new Program();
            main.startGame();
        }

        /// <summary>
        /// The function starts the game by drawing two cards for the player and the computer, then it
        /// loops through the player and computer playing their hands until one of them has a hand value
        /// of 21 or greater.
        /// </summary>
        public void startGame()
        {
            drawTwoCards();

            while(true)
            {
                playerPlay();
                computerPlay();
                Console.WriteLine("\n*************************************\n");

                if (hand_of_player.obtainHandValue() >= 21 && hand_of_computer.obtainHandValue() >= 21)
                {
                    displayResult();
                    break;
                }
            }
        }

        /// <summary>
        /// The function draws two cards for the player and two cards for the computer
        /// </summary>
        public void drawTwoCards()
        {
            deck.shuffleDeck();
            draw("player");
            draw("player");
            Console.WriteLine("Total hand value is " + hand_of_player.obtainHandValue());
            Console.WriteLine("\n*************************************\n");
            draw("computer");
            draw("computer");
        }

        /// <summary>
        /// If the computer's hand value is less than 21, the computer will draw a card
        /// </summary>
        public void computerPlay()
        {
            Random random = new Random();

            if(((random.NextInt64(1, 3) == 1 && hand_of_computer.obtainHandValue() != 21) && hand_of_computer.obtainHandValue() < 21) || (hand_of_player.obtainHandValue() > 21 && hand_of_computer.obtainHandValue() < 21) || hand_of_computer.obtainHandValue() < 21)
            {
                draw("computer");
                Console.WriteLine("Computer drew a card.");
            }
            else
            {
                Console.WriteLine("Computer passed...");
            }
        }

        /// <summary>
        /// If the player's hand value is less than or equal to 21, and the player chooses to draw, then
        /// draw a card for the player.
        /// </summary>
        public void playerPlay()
        {
            if (hand_of_player.obtainHandValue() <= 21)
            {
                if (askUserInput().Equals("1"))
                {
                    draw("player");
                    Console.WriteLine("Total hand value is " + hand_of_player.obtainHandValue());
                    Console.WriteLine("\n*************************************\n");
                }
            }
            else
            {
                Console.WriteLine("No hope for victory");
                Console.WriteLine("\n*************************************\n");
            }
        }

        /// <summary>
        /// It asks the user to input a choice, and if the choice is not 1 or 2, it will ask the user to
        /// input again until the choice is 1 or 2.
        /// </summary>
        /// <returns>
        /// The user's choice.
        /// </returns>
        public String askUserInput()
        {
            Console.WriteLine("Player, would you like to draw or pass?");
            Console.WriteLine("[1] Draw");
            Console.WriteLine("[2] Pass");
            Console.Write("Choice: ");
            string user_choice = Console.ReadLine();

            while (!(user_choice.Equals("1") || user_choice.Equals("2")))
            {
                Console.WriteLine("Your answer is not accepted!");
                Console.WriteLine("\n*************************************\n");
                Console.WriteLine("Player, would you like to draw or pass?");
                Console.WriteLine("[1] Draw");
                Console.WriteLine("[2] Pass");
                Console.Write("Choice: ");
                user_choice = Console.ReadLine();
            }

            Console.WriteLine("Choice accepted...");
            Console.WriteLine("\n*************************************\n");

            return user_choice;
        }

        /// <summary>
        /// The function draws a card from the deck and adds it to the player's hand
        /// </summary>
        /// <param name="String">player</param>
        public void draw(String player)
        {
            if (player.Equals("player"))
            {
                drawCard = deck.drawCard();
                Console.WriteLine("Player drew " + drawCard);
                card.addCard("player", drawCard);
                hand_of_player.incrementHandValue(drawCard);
            }

            if (player.Equals("computer"))
            {
                drawCard = deck.drawCard();
                card.addCard("computer", drawCard);
                hand_of_computer.incrementHandValue(drawCard);
            }
        }

        /// <summary>
        /// It displays the result of the game
        /// </summary>
        public void displayResult()
        {
            if((hand_of_player.obtainHandValue() > 21 && hand_of_computer.obtainHandValue() > 21) || (hand_of_player.obtainHandValue() > 21 && hand_of_computer.obtainHandValue() == 21))
            {
                Console.WriteLine("Hand of Player with a value of " + hand_of_player.obtainHandValue());
                card.displayCards("player");
                Console.WriteLine("\n***************** VS *****************\n");
                Console.WriteLine("Hand of Computer with a value of " + hand_of_computer.obtainHandValue());
                card.displayCards("computer");
                Console.WriteLine("You lose! Try again next time!");
            }
            else if (hand_of_player.obtainHandValue() == 21 && hand_of_computer.obtainHandValue() == 21)
            {
                Console.WriteLine("Game ends in a draw!");
            }
            else if (hand_of_player.obtainHandValue() == 21 && hand_of_computer.obtainHandValue() > 21)
            {
                Console.WriteLine("Hand of Player with a value of " + hand_of_player.obtainHandValue());
                card.displayCards("player");
                Console.WriteLine("\n***************** VS *****************\n");
                Console.WriteLine("Hand of Computer with a value of " + hand_of_computer.obtainHandValue());
                card.displayCards("computer");
                Console.WriteLine("Congratulations! You win!");
            }
        }
    }
}