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

        public LibraryItemPanel(Item _item)
        {
            item = _item;
            pickUpImages = new List<PictureBox>();
            currentRecipeIndex = 0;

            itemPicture = new PictureBox();
            itemPicture.ImageLocation = "../../../../data/Images/Items/" +
                item.ItemId.ToString() +
                ".png";
            itemPicture.SizeMode = PictureBoxSizeMode.AutoSize;
            Controls.Add(itemPicture);

            for (int i = 0; i < 8; ++i)
            {
                PictureBox pickUpBox = new PictureBox();
                pickUpBox.Size = new Size(
                    itemPicture.Width / 2,
                    itemPicture.Height / 2
                    );
                pickUpBox.SizeMode = PictureBoxSizeMode.StretchImage;
                pickUpBox.Location = new Point(
                    itemPicture.Width + 10 + i % 4 * pickUpBox.Width,
                    i / 4 * pickUpBox.Height);
                Controls.Add(pickUpBox);
                pickUpImages.Add(pickUpBox);
            }

            LoadRecipe(currentRecipeIndex);
        }

        private void LoadRecipe(int recipeIndex)
        {
            Recipe recipeToDisplay = item.Recipes[recipeIndex];
            int pictureBoxIndex = 0;
            foreach(KeyValuePair<PickUp, int> component in recipeToDisplay.Components)
            {
                for(int i = 0; i < component.Value; ++i)
                {
                    pickUpImages[pictureBoxIndex++].ImageLocation =
                        "../../../../data/Images/Pickups/" +
                        ((int)component.Key).ToString() +
                        ".png";
                }
            }
        }
    }
}
