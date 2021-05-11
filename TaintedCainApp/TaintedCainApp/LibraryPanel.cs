﻿using System;
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
        public enum SortType
        {
            Id,
            Quality
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
            itemsPerPage = 10;
            currentPage = 0;
            maxPage = ItemManager.Items.Count / itemsPerPage;
            sortedPanels = new List<LibraryItemPanel>();

            itemPanels = new Dictionary<Item, LibraryItemPanel>();
            foreach (Item item in ItemManager.Items)
            {
                LibraryItemPanel itemPanel = new LibraryItemPanel(item);
                itemPanel.AutoSize = true;
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
            for(int quality = ItemManager.GetMaximumItemQuality();
                quality >= 0;
                --quality)
            {
                foreach(KeyValuePair<Item, LibraryItemPanel> itemPanel in itemPanels)
                {
                    if(itemPanel.Key.Quality == quality)
                    {
                        sortedPanels.Add(itemPanel.Value);
                    }
                }
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

                location += toAdd.Height;
                Controls.Add(toAdd);
            }
        }
    }
}
