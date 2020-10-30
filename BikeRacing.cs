using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RacingProject
{
    public partial class BikeRacing : Form
    {
        private BikeClass[] Bike = new BikeClass[4];
        private Guy[] Guy = new Guy[3];
        private Random random = new Random();
        public int GuyThatBets { get; set; }
        public BikeRacing()
        {
            InitializeComponent();
            Start();
            ResetBets();
        }
        public void Start()
        {
            int Start = racer1.Left;
            int Racetrack = racetrack.Width - racer1.Right;


            Bike[0] = new BikeClass() { MypictureBox = racer1, RacetrackLength = Racetrack, StartingPostion = Start };
            Bike[1] = new BikeClass() { MypictureBox = racer2, RacetrackLength = Racetrack, StartingPostion = Start };
            Bike[2] = new BikeClass() { MypictureBox = racer3, RacetrackLength = Racetrack, StartingPostion = Start };
            Bike[3] = new BikeClass() { MypictureBox = racer4, RacetrackLength = Racetrack, StartingPostion = Start };

            Guy[0] = new Guy() { Cash = 50, MyLabel = labelJoesBet, MyRadioButton = radioButtonJoe, Name = "Joe" };
            Guy[1] = new Guy() { Cash = 50, MyLabel = labelBobsBet, MyRadioButton = radioButtonBob, Name = "Bob" };
            Guy[2] = new Guy() { Cash = 50, MyLabel = labelAlsBet, MyRadioButton = radioButtonAl, Name = "Al" };
        }
        public void LetBikeRun()
        {
            while (true)
            {
                for (int i = 0; i < Bike.Length; i++)
                {
                    Thread.Sleep(6);
                    Bike[random.Next(0, 4)].Run();
                    if (Bike[i].Run())
                    {
                        DeclareWinner(i + 1); //array starts with 0
                        return;
                    }
                }
            }
           
        }

        public void DeclareWinner(int Winner)
        {
            MessageBox.Show("Bike " + Winner + " is the Winner!");
            for (int i = 0; i < 3; i++)
            {
                Guy[i].Collect(Winner);
                Guy[i].UpdateLabels();
                ResetBikesPosition();
                //ResetBets();
                SetMaxBet();
                if (Convert.ToInt32(Guy[i].BalanceCash()) <= 0)
                {
                    Guy[i].MyLabel.Text = "Busted";
                    Guy[i].MyLabel.ForeColor = Color.Red;
                    Guy[i].MyRadioButton.Enabled = false;
                }
                else
                {
                    if(i==0)
                    {
                        labelJoesBet.Text = "Joe hasn't placed a bet";
                    }
                    else if(i==1)
                    {
                        labelBobsBet.Text = "Bob hasn't placed a bet";
                    }
                    else if(i==2)
                    {
                        labelAlsBet.Text = "Al hasn't placed a bet";
                    }
                }
               
                   
            }

            
        }

        public void ResetBikesPosition()
        {
            for (int i = 0; i < 4; i++)
            {
                Bike[i].TakeStartingPosition();
            }
        }
        public void SetMaxBet()
        {
            if (radioButtonJoe.Checked == true)
            {
                maxBet.Text = "Max Bet is $" + Guy[0].BalanceCash();
            }
            else if (radioButtonBob.Checked == true)
            {
                maxBet.Text = "Max Bet is $" + Guy[1].BalanceCash();
            }
            else if (radioButtonAl.Checked == true)
            {
                maxBet.Text = "Max Bet is $" + Guy[2].BalanceCash();
            }
            else
            {
                maxBet.Text = "Max Bet";
            }
        }

        public void ResetBets()
        {
            for (int i = 0; i < 3; i++)
            {
                labelJoesBet.Text = "Joe hasn't placed a bet";
                labelBobsBet.Text = "Bob hasn't placed a bet";
                labelAlsBet.Text = "Al hasn't placed a bet";
            }
           
        }

        private void btnRace_Click(object sender, EventArgs e)
        {
            LetBikeRun();
        }

        private void btnBet_Click(object sender, EventArgs e)
        {
            int amount = (int)numericUpDownBet.Value;
            int Bike = (int)numericUpDownBike.Value;
            
            bool bet=Guy[GuyThatBets].PlaceBet(amount, Bike);
            if(!bet)
            {
                MessageBox.Show("You have not amount for this bet");
            }
            Guy[GuyThatBets].UpdateLabels();
        }

        private void radioButtonJoe_CheckedChanged(object sender, EventArgs e)
        {
            GuyThatBets = 0;
            Guy[GuyThatBets].UpdateLabels();
            maxBet.Text = "Max Bet is $" + Guy[GuyThatBets].BalanceCash();
            
        }

        private void radioButtonBob_CheckedChanged(object sender, EventArgs e)
        {
            GuyThatBets = 1;
            Guy[GuyThatBets].UpdateLabels();
            maxBet.Text = "Max Bet is $" + Guy[GuyThatBets].BalanceCash();
            
        }

        private void radioButtonAl_CheckedChanged(object sender, EventArgs e)
        {
            GuyThatBets = 2;
            Guy[GuyThatBets].UpdateLabels();
            maxBet.Text = "Max Bet is $" + Guy[GuyThatBets].BalanceCash();
           
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            Start();
            radioButtonJoe.Enabled = true;
            radioButtonBob.Enabled = true;
            radioButtonAl.Enabled = true;
            ResetBets();
            radioButtonJoe.Checked = false;
            radioButtonBob.Checked = false;
            radioButtonAl.Checked = false;
        }

        private void racetrack_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDownBet_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
