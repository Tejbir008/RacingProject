using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RacingProject
{
   class BikeClass
    {
        public int StartingPostion { get; set; }
        public int RacetrackLength { get; set; }
        public PictureBox MypictureBox { get; set; }
        private Random Randomizer = new Random();

        public bool Run()
        {
            int moveFoward = Randomizer.Next(1, 8);

            Point p = MypictureBox.Location;
            p.X += moveFoward;
            MypictureBox.Location = p;

            if (p.X >= RacetrackLength)
                return true;
            else
                return false;

        }

        public void TakeStartingPosition()
        {
            MypictureBox.Left = StartingPostion;
        }
    }
}
