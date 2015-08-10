using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    class Player : IParticipant
    {
        public string Name { get; set; }

        public int Play()
        {
            Console.WriteLine("{0} playing now...", this.Name);
            int sumCards = 0;
            while (sumCards <= 21)
            {
                Console.WriteLine("h for hit, s for stand");
                String nextMove = Console.ReadLine();

                if (nextMove.ToLower().Equals("h"))
                {
                    CalcSum(ref sumCards);
                    Console.WriteLine("Your sum = {0}", sumCards);
                }
                else if (nextMove.ToLower().Equals("s"))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("invalid input, try again");
                }
                Console.WriteLine();
            }

            return sumCards;
        }

        public void CalcSum(ref int sumCards)
        {
            int cardValue = GetCardVal(sumCards);
            sumCards += cardValue;
        }

        public int GetCardVal(int sumCards)
        {
            string card;
            int cardValue = 0;

            String[] suit = {
                                "Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King"
                            };

            int position = RandomNumber(0, 12);
            card = suit[position];

            Console.WriteLine("Card = {0}", card);

            switch (card)
            {
                case "2":
                case "3":
                case "4":
                case "5":
                case "6":
                case "7":
                case "8":
                case "9":
                case "10": int.TryParse(card, out cardValue); break;
                case "Ace": cardValue = (sumCards + 11 > 21) ? 1 : 11; break;
                case "Jack":
                case "Queen":
                case "King": cardValue = 10; break;
            }

            return cardValue;
        }

        private static readonly Random random = new Random();
        private static readonly object syncLock = new object();

        public static int RandomNumber(int min, int max) // stackoverflow.com/questions/767999/random-number-generator-only-generating-one-random-number
        {
            lock (syncLock)
            { // synchronize
                return random.Next(min, max);
            }
        }
    }
}
