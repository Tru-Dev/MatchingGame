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

        static string[] itemSource = {
            "2", "1 + 1", "3", "1 + 2", "4", "2 + 2", "5", "2 + 3",
            "6", "3 + 3", "7", "3 + 4", "8", "4 + 4", "9", "4 + 5",
        };

        List<string> matchingItems = new List<string>(itemSource);

        MatchingLabel curr1st = null;
        MatchingLabel curr2nd = null;

        DataTable calculator = new DataTable();

        private void AssignNumbersToSquares()
        {
            int amtIters = matchingItems.Count;
            for (int i = 0; i < amtIters; i++)
            {
                int randomNumber = random.Next(matchingItems.Count);
                MatchingLabel labelCurrentlyCreating = new MatchingLabel
                {
                    Text = matchingItems[randomNumber],
                    ForeColor = tableLayoutPanel1.BackColor
                };
                labelCurrentlyCreating.Click += MatchingClick;
                tableLayoutPanel1.Controls.Add(labelCurrentlyCreating);
                matchingItems.RemoveAt(randomNumber);
            }
        }

        private void MatchingClick(object sender, EventArgs e)
        {
            MatchingLabel clicked = sender as MatchingLabel;
            if (clicked != null)
            {
                if (clicked.ForeColor != Color.Black)
                {
                    if (curr1st == null)
                    {
                        curr1st = clicked;
                        curr1st.ForeColor = Color.Black;
                    }
                    else if (curr2nd == null)
                    {
                        curr2nd = clicked;
                        curr2nd.ForeColor = Color.Black;

                        if ((int) calculator.Compute(curr1st.Text, null) == (int)calculator.Compute(curr2nd.Text, null))
                        {
                            curr1st = curr2nd = null;
                            CheckForWinner();
                            return;
                        }

                        timer1.Start(); 
                    }
                }
            }
        }

        private void TimerTick(object sender, EventArgs e)
        {
            timer1.Stop();
            curr1st.ForeColor = curr1st.BackColor;
            curr2nd.ForeColor = curr2nd.BackColor;

            curr1st = curr2nd = null;
        }

        private void CheckForWinner()
        {
            foreach (Control ctrl in tableLayoutPanel1.Controls)
            {
                MatchingLabel labelCurrentlyChecking = ctrl as MatchingLabel;
                if (labelCurrentlyChecking != null && labelCurrentlyChecking.ForeColor == labelCurrentlyChecking.BackColor)
                {
                    return;
                }
            }
            MessageBox.Show("You matched it all!", "You can add!");
            Close();
        }

        public Form1()
        {
            InitializeComponent();

            AssignNumbersToSquares();

            timer1.Tick += TimerTick;
        }

    }
}
