using com.alientech.ui;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace com.alientech.test
{
    static class Program
    {
        /// <summary>
        /// Punto di ingresso principale dell'applicazione.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Thread t = new Thread(LaunchWindow);

            t.Start();

            Thread.Sleep(2000);

            t.Abort();

            Application.Run(new MainForm());
        }

        static void LaunchWindow()
        {
            Application.Run(new ReactiveSplashScreen());
        }
    }
}
