using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MatchingGame
{
    public partial class MatchingLabel : Label
    {
        

        public MatchingLabel()
        {
            InitializeComponent();

            TextAlign = ContentAlignment.MiddleCenter;
            Dock = DockStyle.Fill;
            AutoSize = false;
            Font = new Font("Segoe UI Light", 32f, FontStyle.Regular);

            Click += MatchingClick;
        }

        private void MatchingClick(object sender, EventArgs e)
        {
            MatchingLabel clicked = sender as MatchingLabel;
            if (clicked != null)
            {
                if (clicked.ForeColor != Color.Black) {
                    clicked.ForeColor = Color.Black;
                }
            }
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
    }
}
