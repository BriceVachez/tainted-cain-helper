using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

using TaintedCainApp;

namespace AppUnitTesting
{
    [TestClass]
    public class ItemManagerTests
    {
        #region ReadItemFromFile()
        [TestMethod]
        [ExpectedException(typeof(DirectoryNotFoundException))]
        public void T_ReadItemFromFile_NoDirectory()
        {
            ItemManager.ReadItemsFromFile("test/items.json");
        }

        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void T_ReadItemFromFile_NoFile()
        {
            ItemManager.ReadItemsFromFile("../../../../../data/test/item.json");
        }

        [TestMethod]
        public void T_ReadItemFromFile_File()
        {
            ItemManager.ReadItemsFromFile("../../../../../data/test/items.json");
        }
        #endregion

        #region DisplayAllItems()
        [TestMethod]
        public void T_DisplayAllItems()
        {
            ItemManager.RemoveItems();
            ItemManager.ReadItemsFromFile("../../../../../data/test/items.json");
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                ItemManager.DisplayAllItems();

                string expected = "Name : The Sad Onion\n" +
                    "Id : 1\n" +
                    "Quality : 3\n" +
                    "IsActive : False\n" +
                    "Recipes :\n" +
                    "{\n" +
                    "RedHeart : 1\n" +
                    "Key : 1\n" +
                    "Bomb : 2\n" +
                    "SoulHeart : 1\n" +
                    "Nickel : 2\n" +
                    "Card : 1\n" +
                    " ----\n" +
                    "}\r\n" +
                    "Name : The Inner Eye\n" +
                    "Id : 2\n" +
                    "Quality : 2\n" +
                    "IsActive : False\n" +
                    "Recipes :\n" +
                    "{\n" +
                    "Penny : 2\n" +
                    "RedHeart : 1\n" +
                    "Key : 2\n" +
                    "Bomb : 1\n" +
                    "Pill : 2\n" +
                    " ----\n" +
                    "}\r\n"; ;
                Assert.AreEqual(expected, sw.ToString());
            }
        }
        #endregion

        #region GetCurrentNumberOfItems()
        [TestMethod]
        public void T_GetCurrentNumberOfItems()
        {
            ItemManager.RemoveItems();
            int expected = 0;
            Assert.AreEqual(expected, ItemManager.GetCurrentNumberOfItems());

            ItemManager.ReadItemsFromFile("../../../../../data/test/items.json");
            expected = 2;
            Assert.AreEqual(expected, ItemManager.GetCurrentNumberOfItems());
        }
        #endregion

        #region GetTotalNumberOfItems()
        [TestMethod]
        public void T_GetTotalNumberOfItems()
        {
            int expected = 2;
            Assert.AreEqual(
                expected, 
                ItemManager.GetTotalNumberOfItems( "../../../../../data/test/items.json")
                );
        }

        [TestMethod]
        public void T_GetTotalNumberOfItems_NoDirectory()
        {
            int expected = 0;
            Assert.AreEqual(
                expected,
                ItemManager.GetTotalNumberOfItems("test/items.json"));
        }

        [TestMethod]
        public void T_GetTotalNumberOfItems_NoFile()
        {
            int expected = 0;
            Assert.AreEqual(
                expected,
                ItemManager.GetTotalNumberOfItems("../../../../../data/test/item.json"));
        }
        #endregion
    }
}
