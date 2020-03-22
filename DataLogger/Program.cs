using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DataManager;

namespace DataLogger
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (Config.Sets.Running) Config.Start();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new formMain());
        }
    }
}
