using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;

using TaintedCainApp.Model;

using TaintedCainApp.Util;

namespace TaintedCainApp.UI
{
    public class LibraryPanel : Panel
    {
        public enum SortType
        {
            Id,
            Quality,
            Name
        };

        private Dictionary<Item, LibraryItemPanel> itemPanels;

        private List<LibraryItemPanel> sortedPanels;

        private int itemsPerPage;

        private int currentPage;
        public int CurrentPage { get => currentPage; }

        private int maxPage;
        public int MaxPage { get => maxPage; }

        public LibraryPanel() : base()
        {
            currentPage = 0;
            itemsPerPage = 10;
            maxPage = ItemManager.Items.Count / itemsPerPage;
            sortedPanels = new List<LibraryItemPanel>();

            itemPanels = new Dictionary<Item, LibraryItemPanel>();

            foreach (Item item in ItemManager.Items)
            {
                LibraryItemPanel itemPanel = new LibraryItemPanel(item);
                itemPanel.Size = new Size(750, 32);
                itemPanel.Scale(new SizeF(1, 1));
                itemPanels.Add(item, itemPanel);
            }

            SortById();
            Display();
        }

        public void Sort(SortType type)
        {
            switch (type)
            {
                case SortType.Id:
                    SortById();
                    break;
                case SortType.Quality:
                    SortByQuality();
                    break;
                case SortType.Name:
                    SortByName();
                    break;
                default:
                    Console.WriteLine("Not implemented yet.");
                    break;
            }
        }

        public void ChangeItemsPerPage(int newNumber)
        {
            itemsPerPage = newNumber;
            currentPage = 0;
            maxPage = ItemManager.Items.Count / itemsPerPage;
            Display();
        }

        #region Sorting
        private void SortById()
        {
            sortedPanels.Clear();
            foreach (KeyValuePair<Item, LibraryItemPanel> pair in itemPanels)
            {
                sortedPanels.Add(pair.Value);
            }
        }

        private void SortByQuality()
        {
            sortedPanels.Clear();
            for (int quality = ItemManager.GetMaximumItemQuality();
                quality >= 0;
                --quality)
            {
                foreach (KeyValuePair<Item, LibraryItemPanel> itemPanel in itemPanels)
                {
                    if (itemPanel.Key.Quality == quality)
                    {
                        sortedPanels.Add(itemPanel.Value);
                    }
                }
            }
        }

        private void SortByName()
        {
            sortedPanels.Clear();

            List<Item> itemList = itemPanels.Keys.ToList();

            itemList.Sort(
                delegate (Item item1, Item item2)
                {
                    return item1.Name.CompareTo(item2.Name);
                }
            );

            foreach(Item item in itemList)
            {
                sortedPanels.Add(itemPanels[item]);
            }
        }
        #endregion

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

        private void Display()
        {
            try
            {
                foreach (LibraryItemPanel panel in sortedPanels)
                {
                    Controls.Remove(panel);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            int maxIndex = Math.Min(
                ItemManager.Items.Count,
                itemsPerPage * (currentPage + 1)
                );

            int location = 0;
            for (int i = currentPage * itemsPerPage; i < maxIndex; ++i)
            {
                LibraryItemPanel toAdd = sortedPanels[i];

                toAdd.Location = new Point(0, location);
                location += toAdd.Height * 3/2;
                Controls.Add(toAdd);
            }
        }
    }
}
