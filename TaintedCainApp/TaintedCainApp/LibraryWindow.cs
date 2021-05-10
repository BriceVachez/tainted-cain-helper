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
            LoadItemsInLibrary();
        }

        private void LoadItemsInLibrary()
        {
            int verticalLocation = 0;
            foreach(Item item in ItemManager.Items)
            {
                PictureBox itemImageBox = new PictureBox();
                itemImageBox.ImageLocation = "../../../../data/Images/Items/" +
                    item.ItemId.ToString() +
                    ".png";
                itemImageBox.SizeMode = PictureBoxSizeMode.AutoSize;
                itemImageBox.Location = new Point(0, verticalLocation);
                verticalLocation += itemImageBox.Size.Height;
                showcasePanel.Controls.Add(itemImageBox);
            }
        }

        private void showcasePanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void leaveButton_Click(object sender, EventArgs e)
        {

        }
    }
}
