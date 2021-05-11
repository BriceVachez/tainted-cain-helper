using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaintedCainApp
{
    public partial class MainAppWindow : Form
    {
        Form openingForm;
        public MainAppWindow(Form callingForm)
        {
            openingForm = callingForm;
            FormClosing += new FormClosingEventHandler(MainAppWindow_FormClosing);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            InitializeComponent();
        }

        private void library_Click_Click(object sender, EventArgs e)
        {
            using (LibraryWindow libraryWindow = new LibraryWindow())
            {
                libraryWindow.ShowDialog(this);
            }
        }

        private void MainAppWindow_Load(object sender, EventArgs e)
        {

        }

        private void MainAppWindow_FormClosing(object sender, EventArgs e)
        {
            openingForm.Close();
        }
    }
}
