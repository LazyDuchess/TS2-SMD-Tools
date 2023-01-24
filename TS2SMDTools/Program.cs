using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TS2SMDTools
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (InDebugMode())
                Application.Run(new Form1());
            else
                Application.Run(new MainForm());
        }

        static bool InDebugMode()
        {
            return true;
        }
    }
}
