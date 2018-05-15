using LIU;
using System;
using System.Windows.Forms;

namespace LIUForms
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
            Application.Run(new MultiFormContext(new Form1(_program.FixedActivities)));
        }
    }
}
