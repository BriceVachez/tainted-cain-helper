using System.Collections.Generic;

using System.Windows.Forms;
using System.Drawing;
using TaintedCainApp.Model;

namespace TaintedCainApp.UI
{
    public class TreeNodePanel : Panel
    {
        private int itemId;

        private Recipe recipe;

        private PictureBox itemPicture;

        List<PictureBox> pickUpPictures;
        public TreeNodePanel(ItemNode node) : base()
        {
            itemId = node.ItemId;
            recipe = node.Recipe;

            itemPicture = new PictureBox();
            itemPicture.Size = new Size(64, 64);
            itemPicture.SizeMode = PictureBoxSizeMode.Zoom;
            itemPicture.Location = new Point(0, 0);
            itemPicture.ImageLocation = "../data/Images/Items/" +
                itemId.ToString() +
                ".png";
            Controls.Add(itemPicture);

            int pictureBoxIndex = 0;
            pickUpPictures = new List<PictureBox>();
            foreach (KeyValuePair<PickUp, int> component in recipe.Components)
            {
                for (int i = 0; i < component.Value; ++i)
                {
                    PictureBox pickUpPicture = new PictureBox();
                    pickUpPicture.Size = new Size(32,32);
                    pickUpPicture.SizeMode = PictureBoxSizeMode.Zoom;
                    pickUpPicture.Location = new Point(
                        64 + pictureBoxIndex % 4 * 32,
                        pictureBoxIndex / 4 * 32
                        );
                    pickUpPicture.ImageLocation = "../data/Images/Pickups/" +
                        ((int)component.Key).ToString() +
                        ".png";
                    pictureBoxIndex++;
                    Controls.Add(pickUpPicture);
                    pickUpPictures.Add(pickUpPicture);
                }
            }
        }
    }
}
