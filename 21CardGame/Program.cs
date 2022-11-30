using System.Numerics;

namespace Program
{
    class Program
    {
        public Hand hand_of_player = new Hand();
        public Hand hand_of_computer = new Hand();
        public Deck deck = new Deck();
        public Card card = new Card();
        public static string drawCard = "";

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
        /// The function starts the game by drawing two cards for the player and the computer, then the
        /// player plays, then the computer plays, then the cards are displayed, and finally the result
        /// is displayed.
        /// </summary>
        public void startGame()
        {
            drawTwoCards();

            playerPlay();
            if(hand_of_player.obtainHandValue() <= 21) computerPlay();
            Console.WriteLine("\n*************************************\n");
            card.displayCards("player");
            Console.WriteLine("\n****************** VS ******************\n");
            card.displayCards("computer");
            Console.WriteLine("\n*************************************\n");
            displayResult();
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
        /// The computer draws cards until it has a hand value of 17 or greater
        /// </summary>
        public void computerPlay()
        {
            while (hand_of_computer.obtainHandValue() < 17)
            {
                draw("computer");
                Console.WriteLine("Computer drew a card.");
            }
        }

        /// <summary>
        /// The playerPlay() function is a while loop that asks the user for input, and if the user
        /// inputs 1, the player draws a card, and the hand value is displayed. If the hand value is
        /// greater than 21, the player loses
        /// </summary>
        public void playerPlay()
        {
            while (hand_of_player.obtainHandValue() < 21)
            {
                if (askUserInput().Equals("1"))
                {
                    draw("player");
                    Console.WriteLine("Total hand value is " + hand_of_player.obtainHandValue());
                    Console.WriteLine("\n****************************************\n");

                    if (hand_of_player.obtainHandValue() > 21) Console.WriteLine("No hope for victory");
                }
                else break;
            }
        }

        /// <summary>
        /// It asks the user to input a choice, and if the choice is not 1 or 2, it will ask the user to
        /// input again until the choice is 1 or 2.
        /// </summary>
        /// <returns>
        /// The user's choice.
        /// </returns>
        public string askUserInput()
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
        /// <param name="string">player</param>
        public void draw(string player)
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

        
        public void displayResult()
        {
        /// <summary>
        /// If the player's hand value is greater than 21 and the computer's hand value is less than 21,
        /// the player is bust. If both the player's hand value and the computer's hand value are 21, or
        /// if both the player's hand value and the computer's hand value are equal, the game ends in a
        /// draw. If the computer's hand value is 21, or if the computer's hand value is less than 21
        /// and the player's hand value is greater than 21, or if the computer's hand value is less than
        /// 21 and the player's hand value is less than 21 and the computer's hand value is greater than
        /// the player's hand value, the dealer wins. If the player's hand value is 21, or if the
        /// player's hand value is less than 21 and the computer's hand value is greater than 21, or if
        /// the player's hand value is less than 21 and the computer's hand value is less than 21 and
        /// the player's hand value is greater than
        /// </summary>
            if (hand_of_player.obtainHandValue() > 21 && hand_of_computer.obtainHandValue() < 21) Console.WriteLine("Game ended. You are BUST!");
            else if ((hand_of_player.obtainHandValue() == 21 && hand_of_computer.obtainHandValue() == 21) || (hand_of_player.obtainHandValue() == hand_of_computer.obtainHandValue()))
            {
                Console.WriteLine("Game ended in DRAW!");
            }
            else if (
                (hand_of_computer.obtainHandValue() == 21) ||
                ((hand_of_computer.obtainHandValue() < 21 && hand_of_player.obtainHandValue() > 21) ||
                ((hand_of_computer.obtainHandValue() < 21 && hand_of_player.obtainHandValue() < 21) && (hand_of_computer.obtainHandValue() > hand_of_player.obtainHandValue())))
            )
            {
                Console.WriteLine("Game ended. Dealer wins!");
            }
            else if (
                (hand_of_player.obtainHandValue() == 21) ||
                (hand_of_player.obtainHandValue() < 21 && hand_of_computer.obtainHandValue() > 21) ||
                ((hand_of_player.obtainHandValue() < 21 && hand_of_computer.obtainHandValue() < 21) && (hand_of_player.obtainHandValue() > hand_of_computer.obtainHandValue()))
            )
            {
                Console.WriteLine("Congratulations! You win!");
            }
        }
    }
}