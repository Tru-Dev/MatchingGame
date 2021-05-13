using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MatchingGame
{
    public partial class Form1 : Form
    {
        Random random = new Random();

        List<string> matchingItems = new List<string>()
        {
            "2", "1 + 1", "3", "1 + 2", "4", "2 + 2", "5", "2 + 3",
            "6", "3 + 3", "7", "3 + 4", "8", "4 + 4", "9", "4 + 5",
        };

        MatchingLabel curr1st = null;
        MatchingLabel curr2nd = null;


        private void AssignNumbersToSquares()
        {
            int amtIters = matchingItems.Count;
            for (int i = 0; i < amtIters; i++)
            {
                int randomNumber = random.Next(matchingItems.Count);
                tableLayoutPanel1.Controls.Add(new MatchingLabel
                {
                    Text = matchingItems[randomNumber],
                    ForeColor = tableLayoutPanel1.BackColor
                });
                matchingItems.RemoveAt(randomNumber);
            }
        }

        public Form1()
        {
            InitializeComponent();

            AssignNumbersToSquares();
        }

    }
}
