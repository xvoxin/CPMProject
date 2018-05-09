using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CPMForms
{
    class Startup
    {
        private static Program _program;
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            _program = new Program();
            Application.Run(new MultiFormContext(new Form1(_program.DrawHarmonogram()), new Form2(_program.Activites)));
        }
    }
}
