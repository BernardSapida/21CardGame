using System.Numerics;

namespace Program
{
    class Program
    {
        private Deck deck = new Deck();
        private Hand hand_of_player = new Hand();
        private Hand hand_of_computer = new Hand();
        private Card card = new Card();
        private static String drawCard = "";

        static void Main(string[] args)
        {
            Program main = new Program();
            main.startGame();
        }

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
                    checkWinner();
                    break;
                }
            }
        }

        public void drawTwoCards()
        {
            deck.shuffleDeck();
            draw("player");
            draw("player");
            Console.WriteLine("Total hand value is " + hand_of_player.obtainHandValue());
            draw("computer");
            draw("computer");
        }

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

        public void playerPlay()
        {
            if (hand_of_player.obtainHandValue() <= 21)
            {
                if (queryInput().Equals("1"))
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

        public String queryInput()
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

        public void checkWinner()
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