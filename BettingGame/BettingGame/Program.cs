using CashTrade;

namespace BettingGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            double odds = .75;
            Guy player = new Guy() { Cash = 100, Name = "The player" };

            Console.WriteLine("Welcome to the Casino. The odds are " + odds);

            while (player.Cash > 0)
            {
                player.WriteMyInfo();
                Console.WriteLine("How much do you want to bet? ");
                string howMuch = Console.ReadLine();
                if (int.TryParse(howMuch, out int amount))
                {
                    int pot = player.GiveCash(amount) * 2;
                    if (pot > 0)
                    {
                        if (random.NextDouble() > odds)
                        {
                            int winnings = pot;
                            Console.WriteLine("You win " + winnings);
                            player.ReceiveCash(winnings);
                        }
                        else
                        {
                            Console.WriteLine("Bad luck, you lose");
                        }
                    }
                }
                else 
                { 
                    Console.WriteLine("Please enter a valid number"); 
                }
            }
            Console.WriteLine("The house always wins");
        }
    }
}