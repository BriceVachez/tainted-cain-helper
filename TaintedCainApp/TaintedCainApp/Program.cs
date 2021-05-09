using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaintedCainApp
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

            DataUpdater.GenerateItemsFromWiki();
            ItemManager.ReadItemsFromFile();
            ItemManager.DisplayAllItems();
            
            Application.Run(new MainWindow());
        }
    }
}
