using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Threading;
using System.Windows.Forms;

namespace StockDataVisualizer
{
    static class Program
    {
        private static Mutex oneAppOnly;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool createdNew = false;

            oneAppOnly = new Mutex(false,"SysMutex",out createdNew);
            if (createdNew)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new StockDataVisualizer());
            } else
            {
                MessageBox.Show("Only one Instance of the application can run");
            }
        }
    }
}
