using LIU.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LIUForms
{
    public partial class Form1 : Form
    {
        private Activity[] _acts;
        public Form1(Activity[] acts)
        {
            InitializeComponent();
            _acts = acts;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var width = 60;
            var height = 30;
            Graphics g = e.Graphics;
            // And a rect with some text...
            for(int i = 0; i < _acts.Length; i++)
            {
                var r = new Rectangle(i * width, 10, width, height);
                var d = new Rectangle(i * width, 50, width, 15);
                g.DrawRectangle(Pens.Blue, r);
                g.DrawRectangle(Pens.Black, d);
                g.DrawString((i + 1).ToString(), new Font("Arial", 12), Brushes.Black, d);
                if(_acts[i] != null)
                {
                    g.DrawString("Z" + _acts[i].Id, new Font("Arial", 12), Brushes.Black, r);
                }
            }

        }
    }
}
