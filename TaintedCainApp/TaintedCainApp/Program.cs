using System;
using System.Windows.Forms;

using System.IO;

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

            Directory.CreateDirectory("../../../../data/Images/Items");
            Directory.CreateDirectory("../../../../data/Images/Pickups");

            UI.MainMenu mainMenu = new UI.MainMenu();
            Application.Run(mainMenu);
        }
    }
}
