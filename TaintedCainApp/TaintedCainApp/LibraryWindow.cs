using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;

namespace TaintedCainApp
{
    public partial class LibraryWindow : Form
    {

        private List<int> availableItemsPerPage =
            new List<int>
        {
            10,
            20,
            50,
            100,
            200
        };

        public LibraryWindow()
        {
            InitializeComponent();
            LoadRadioButtons();
            ChangeButtonState();
            UpdatePageLabel();
        }

        private void LoadRadioButtons()
        {

            int location = 0;
            //Load the radio buttons
            foreach (int itemsPerPage in availableItemsPerPage)
            {
                RadioButton pageChoser = new RadioButton();

                pageChoser.Text = itemsPerPage.ToString();

                if (pageChoser.Text == "10")
                {
                    pageChoser.Checked = true;

                }
                pageChoser.Location = new Point(location, 0);
                location += pageChoser.Width;
                pageNumberChosingPanel.Controls.Add(pageChoser);
            }
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

        private void pageNumberChosingPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            var checkedButton = pageNumberChosingPanel.
                Controls.
                OfType<RadioButton>().
                FirstOrDefault(radio => radio.Checked);

            showcasePanel.ChangeItemsPerPage(
                Int32.Parse(checkedButton.Text));

            ChangeButtonState();
            UpdatePageLabel();
            
        }
    }
}
