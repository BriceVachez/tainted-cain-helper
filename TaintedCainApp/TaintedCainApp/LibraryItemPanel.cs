using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using System.Drawing;

namespace TaintedCainApp
{
    public class LibraryItemPanel : Panel
    {
        private int currentRecipeIndex;

        private Item item;

        private PictureBox itemPicture;

        private List<PictureBox> pickUpImages;

        private Button firstRecipeButton;
        private Button leftRecipeButton;
        private Button rightRecipeButton;
        private Button lastRecipeButton;

        public LibraryItemPanel(Item _item)
        {
            item = _item;
            pickUpImages = new List<PictureBox>();
            currentRecipeIndex = 0;

            int location = 0;

            itemPicture = new PictureBox();
            itemPicture.ImageLocation = "../../../../data/Images/Items/" +
                item.ItemId.ToString() +
                ".png";
            itemPicture.Size = new Size(32, 32);
            itemPicture.SizeMode = PictureBoxSizeMode.Zoom;
            Controls.Add(itemPicture);
            location += itemPicture.Width;

            firstRecipeButton = new Button();
            firstRecipeButton.Text = "<<";
            firstRecipeButton.Size = new Size(64, 32);
            firstRecipeButton.Location = new Point(location, 0);
            firstRecipeButton.Click += new EventHandler(firstRecipeButton_Click);
            Controls.Add(firstRecipeButton);
            location += firstRecipeButton.Width;

            leftRecipeButton = new Button();
            leftRecipeButton.Text = "<";
            leftRecipeButton.Size = new Size(64, 32);
            leftRecipeButton.Location = new Point(location, 0);
            leftRecipeButton.Click += new EventHandler(leftRecipeButton_Click);
            Controls.Add(leftRecipeButton);
            location += leftRecipeButton.Width;

            for (int i = 0; i < 8; ++i)
            {
                PictureBox pickUpBox = new PictureBox();
                pickUpBox.Size = new Size(16, 16);
                pickUpBox.SizeMode = PictureBoxSizeMode.Zoom;
                pickUpBox.Location = new Point(
                    location + i % 4 * pickUpBox.Width,
                    i / 4 * pickUpBox.Height);
                pickUpImages.Add(pickUpBox);
                Controls.Add(pickUpBox);
            }

            location += 2 * itemPicture.Width;

            rightRecipeButton = new Button();
            rightRecipeButton.Text = ">";
            rightRecipeButton.Size = new Size(64, 32);
            rightRecipeButton.Location = new Point(location, 0);
            rightRecipeButton.Click += new EventHandler(rightRecipeButton_Click);
            Controls.Add(rightRecipeButton);
            location += rightRecipeButton.Width;

            lastRecipeButton = new Button();
            lastRecipeButton.Text = ">>";
            lastRecipeButton.Size = new Size(64, 32);
            lastRecipeButton.Location = new Point(location, 0);
            lastRecipeButton.Click += new EventHandler(lastRecipeButton_Click);
            Controls.Add(lastRecipeButton);

            ChangeButtonState();
            LoadRecipe(currentRecipeIndex);
        }

        private void LoadRecipe(int recipeIndex)
        {
            Recipe recipeToDisplay = item.Recipes[recipeIndex];
            int pictureBoxIndex = 0;
            foreach (KeyValuePair<PickUp, int> component in recipeToDisplay.Components)
            {
                for (int i = 0; i < component.Value; ++i)
                {
                    pickUpImages[pictureBoxIndex++].ImageLocation =
                        "../../../../data/Images/Pickups/" +
                        ((int)component.Key).ToString() +
                        ".png";
                }
            }
        }

        private void firstRecipeButton_Click(object sender, EventArgs e)
        {
            currentRecipeIndex = 0;
            LoadRecipe(currentRecipeIndex);
            ChangeButtonState();
        }

        private void leftRecipeButton_Click(object sender, EventArgs e)
        {
            currentRecipeIndex -= 1;
            LoadRecipe(currentRecipeIndex);
            ChangeButtonState();
        }

        private void rightRecipeButton_Click(object sender, EventArgs e)
        {
            currentRecipeIndex += 1;
            LoadRecipe(currentRecipeIndex);
            ChangeButtonState();
        }

        private void lastRecipeButton_Click(object sender, EventArgs e)
        {
            currentRecipeIndex = item.Recipes.Count - 1;
            LoadRecipe(currentRecipeIndex);
            ChangeButtonState();
        }

        private void ChangeButtonState()
        {
            firstRecipeButton.Enabled = (currentRecipeIndex != 0);
            leftRecipeButton.Enabled = (currentRecipeIndex != 0);
            rightRecipeButton.Enabled = (currentRecipeIndex != item.Recipes.Count - 1);
            lastRecipeButton.Enabled = (currentRecipeIndex != item.Recipes.Count - 1);
        }
    }
}
