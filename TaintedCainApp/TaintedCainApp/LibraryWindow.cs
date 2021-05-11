using System;
using System.Drawing;
using System.Windows.Forms;

namespace TaintedCainApp
{
    public partial class LibraryWindow : Form
    {
        public LibraryWindow()
        {
            InitializeComponent();
            ChangeButtonState();
            UpdatePageLabel();
        }

        private void showcasePanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void leaveButton_Click(object sender, EventArgs e)
        {

        }

        private void nextPage_Click(object sender, EventArgs e)
        {
            showcasePanel.NextPage();
            ChangeButtonState();
            UpdatePageLabel();
        }

        private void previousPage_Click(object sender, EventArgs e)
        {
            showcasePanel.PreviousPage();
            ChangeButtonState();
            UpdatePageLabel();

        }

        private void UpdatePageLabel()
        {
            int page = showcasePanel.CurrentPage + 1;
            int maxPage = showcasePanel.MaxPage + 1;
            pageLabel.Text = "Page " + 
                page.ToString() + 
                "/" + 
                maxPage.ToString();
        }

        private void ChangeButtonState()
        {
            Tuple<bool, bool> buttonStates = showcasePanel.GetButtonActivationState();
            previousPage.Enabled = buttonStates.Item1;
            nextPage.Enabled = buttonStates.Item2;
        }

        private void LibraryWindow_Load(object sender, EventArgs e)
        {

        }
    }
}
