using System;
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
            if (Config.Sets.Running_OPCUA) Config.StartOPCUA();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new formMain());
        }
    }
}
