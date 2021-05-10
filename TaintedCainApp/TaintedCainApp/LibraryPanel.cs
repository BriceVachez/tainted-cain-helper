using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace TaintedCainApp
{
    public class LibraryPanel : Panel
    {
        private List<LibraryItemPanel> itemPanels;
        public LibraryPanel() : base()
        {
            itemPanels = new List<LibraryItemPanel>();
            int verticalLocation = 0;
            foreach (Item item in ItemManager.Items)
            {
                LibraryItemPanel itemPanel = new LibraryItemPanel(item);
                itemPanel.AutoSize = true;
                itemPanel.Location = new Point(0, verticalLocation);

                verticalLocation += itemPanel.Height;

                itemPanels.Add(itemPanel);
                Controls.Add(itemPanel);
            }
        }
    }
}
