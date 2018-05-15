using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace CPMForms
{
    public partial class Form1 : Form
    {
        private List<ActivityRect> _actsRec;
        public Form1(List<ActivityRect> actsRec)
        { 
            InitializeComponent();
            _actsRec = actsRec;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var cell = 40;
            Graphics g = e.Graphics;
            // And a rect with some text...
            foreach (var act in _actsRec)
            {
                var r = new Rectangle(cell * act.StartTime, (act.Height + 5) * act.Line, act.Width, act.Height);
                g.DrawRectangle(Pens.Blue, r);
                g.DrawString(act.Name, new Font("Arial", 12), Brushes.Black, r);
            }
           
        }
    }
}
