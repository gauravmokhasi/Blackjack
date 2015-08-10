using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    class Program
    {
        static void Main(string[] args)
        {
            Boolean playAgain = true;
            IParticipant player = new Player();
            Dealer dealer = new Dealer();

            Console.Write("Enter Player name: ");
            player.Name = Console.ReadLine();
            Console.WriteLine();

            while (playAgain)
            {
                Boolean bust = false;
                dealer.DealerShow();
                Console.WriteLine();

                int playerSum = player.Play();
                Console.WriteLine();

                int dealerSum = 0;

                if (playerSum <= 21)
                {
                    dealerSum = dealer.Play();
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Bust! You lose.");
                    bust = true;
                }

                if (!bust)
                {
                    if (dealerSum < playerSum || dealerSum > 21)
                    {
                        if (playerSum == 21)
                        {
                            Console.WriteLine("Blackjack!");
                        }
                        Console.WriteLine("Congrats! You beat the dealer.");
                    }
                    else if (dealerSum == playerSum)
                    {
                        Console.WriteLine("You neither win nor lose.");
                    }
                    else
                    {
                        Console.WriteLine("Sorry, you lose.");
                    }
                }

                Console.WriteLine();
                Console.WriteLine("Hit y to play again. Any other key to exit.");
                String play = Console.ReadLine();
                if (play.Equals("y") || play.Equals("Y"))
                    playAgain = true;
                else
                    playAgain = false;

                Console.Clear(); 
            }
        }
    }
}
