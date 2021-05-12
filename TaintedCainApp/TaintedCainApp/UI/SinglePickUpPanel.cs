using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using System.Drawing;

using TaintedCainApp.Model;

namespace TaintedCainApp.UI
{
    public class SinglePickUpPanel : Panel
    {
        private PictureBox pickUpImage;

        private NumericUpDown counter;

        private PickUp pickUp;
        public PickUp PickUp { get => pickUp; }

        public SinglePickUpPanel(PickUp _pickUp) : base()
        {
            pickUp = _pickUp;

            pickUpImage = new PictureBox();
            pickUpImage.ImageLocation = "../../../../data/Images/Pickups/" +
                (int)pickUp +
                ".png";

            pickUpImage.Size = new Size(32, 32);
            pickUpImage.Location = new Point(0, 0);
            pickUpImage.SizeMode = PictureBoxSizeMode.Zoom;
            Controls.Add(pickUpImage);

            counter = new NumericUpDown();
            counter.Value = 0;
            counter.Minimum = 0;
            counter.Maximum = 99;
            counter.Location = new Point(40, 0);
            counter.Size = new Size(64, 32);
            Controls.Add(counter);
        }

        public int GetValue()
        {
            return (int)counter.Value;
        }
    }
}
