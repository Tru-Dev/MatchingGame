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
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
    }
}
