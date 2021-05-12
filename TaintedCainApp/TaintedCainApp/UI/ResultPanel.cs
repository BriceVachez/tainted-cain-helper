using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;

using TaintedCainApp.Model;

namespace TaintedCainApp.UI
{
    public class ResultPanel : Panel
    {
        private List<List<TreeNodePanel>> sortedPanels;

        private int itemsPerPage;

        private int currentPage;
        public int CurrentPage { get => currentPage; }

        private int maxPage;
        public int MaxPage { get => maxPage; }

        private ItemNode root;

        public ResultPanel(ItemNode _root) : base()
        {
            root = _root;
            currentPage = 0;
            itemsPerPage = 10;
            maxPage = root.CountLeaf() / itemsPerPage;

            sortedPanels = GenerateAllPanels(root);

            Display();
        }

        private List<List<TreeNodePanel>> GenerateAllPanels(ItemNode root)
        {
            List<List<TreeNodePanel>> panelsList = new List<List<TreeNodePanel>>();
            foreach(ItemNode child in root.Children)
            {
                List<List<TreeNodePanel>> panelsToAdd = GeneratePanels(child);
                panelsList.AddRange(panelsToAdd);
            }
            return panelsList;
        }

        private List<List<TreeNodePanel>> GeneratePanels(
            ItemNode parent
            )
        {
            List<List<TreeNodePanel>> panelsList = new List<List<TreeNodePanel>>();
            TreeNodePanel panel = new TreeNodePanel(parent);
            if (parent.IsLeaf())
            {
                List<TreeNodePanel> panels = new List<TreeNodePanel> { panel };
                panelsList = new List<List<TreeNodePanel>> { panels };
                return panelsList;
            }

            foreach (ItemNode child in parent.Children)
            {
                List<List<TreeNodePanel>> childPanelList = GeneratePanels(child);
                foreach (List<TreeNodePanel> childPanel in childPanelList)
                {
                    List<TreeNodePanel> thesePanels = new List<TreeNodePanel> { panel };
                    thesePanels.AddRange(childPanel);
                    panelsList.Add(thesePanels);
                }
            }

            return panelsList;
        }

        private void Display()
        {
            try
            {
                foreach (List<TreeNodePanel> panels in sortedPanels)
                {
                    foreach (TreeNodePanel panel in panels)
                    {
                        Controls.Remove(panel);
                    }
                }
            }
            catch (Exception e)
            {

            }

            if(root.IsLeaf())
            {
                return;
            }

            int maxIndex = Math.Min(
                root.CountLeaf(),
                itemsPerPage * (currentPage + 1)
                );

            int location = 0;
            for (int i = currentPage * itemsPerPage; i < maxIndex; ++i)
            {
                List<TreeNodePanel> panelsToAdd = sortedPanels[i];
                for (int j = 0; j < panelsToAdd.Count; ++j)
                {
                    TreeNodePanel toAdd = panelsToAdd[j];
                    toAdd.Location = new Point(j*208, location);
                    Controls.Add(toAdd);
                }
                location += 96;
            }
        }
        public Tuple<bool, bool> GetButtonActivationState()
        {
            return new Tuple<bool, bool>(
                currentPage != 0,
                currentPage != maxPage
                );
        }

        public void FirstPage()
        {
            currentPage = 0;
            Display();
        }

        public void PreviousPage()
        {
            currentPage -= 1;
            Display();
        }

        public void NextPage()
        {
            currentPage += 1;
            Display();
        }

        public void LastPage()
        {
            currentPage = maxPage;
            Display();
        }
    }
}
