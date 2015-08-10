using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    class Dealer : Player, IParticipant
    {
        private string name;

        public new string Name
        {
            get { return name; }
            set { name = "Mike"; } // dealer's name doesn't matter; just implementing this as it implements Participant
        }

        private int cardUp;

        public void DealerShow()
        {
            cardUp = 0;
            CalcSum(ref cardUp);
            Console.WriteLine("Value of dealer's card facing up is {0}", cardUp);
        }

        public new int Play()
        {
            Console.WriteLine("Dealer playing now...");
            int sumCards = cardUp;
            
            while (sumCards < 17)
            {
                    CalcSum(ref sumCards);
                    Console.WriteLine("Dealer's sum = {0}", sumCards);
            }

            return sumCards;
        }       
    }
}
