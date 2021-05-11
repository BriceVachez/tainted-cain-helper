using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using System.Drawing;

namespace TaintedCainApp
{
    public class PickUpCounterPanel : Panel
    {
        List<SinglePickUpPanel> counters;
        public PickUpCounterPanel() : base()
        {
            counters = new List<SinglePickUpPanel>();
            var pickUps = Enum.GetValues(typeof(PickUp));
            for (int i = 0; i < pickUps.Length; ++i)
            {
                SinglePickUpPanel counter = new SinglePickUpPanel((PickUp)pickUps.GetValue(i));
                counter.Size = new Size(110, 32);
                AutoScroll = true;
                //counter.Scale(new SizeF(1, 1));
                counter.Location = new Point(
                    i % 3 * 120,
                    i / 3 * 40
                    );
                Controls.Add(counter);
                counters.Add(counter);
            }
        }

        public Dictionary<PickUp, int> GetAllPickUps()
        {
            Dictionary<PickUp, int> pickUps = new Dictionary<PickUp, int>();
            foreach (SinglePickUpPanel counter in counters)
            {
                pickUps.Add(
                    counter.PickUp,
                    counter.GetValue()
                    );
            }

            return pickUps;
        }
    }
}
