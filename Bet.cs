using System.Windows.Forms;

namespace RacingProject
{
    internal class Bet
    {
        public int Amount { get; set; }
        public int Bike { get; set; }
        public Guy Bettor { get; set; }


        public string GetDescription()
        {
            if (Amount == 0)
            {
                return Bettor.Name + " hasn't placed a bet";
            }
            else
            {
                return Bettor.Name + " bets " + Amount + " on Bike " + Bike;
            }
        }

        public int PayOut(int winner)
        {
            if (Bike == winner)
            {
                int amount = Amount;
                MessageBox.Show(Bettor.Name + " takes the money!!");
                ClearBet();
                return Bettor.Cash += amount * 3;
            }
            else
            {
                ClearBet();
                return 0;

            }
        }

        public void ClearBet()
        {
            Amount = 0;
            Bike = 0;
        }
    }
}