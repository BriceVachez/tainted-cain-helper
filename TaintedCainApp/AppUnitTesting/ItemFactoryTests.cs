using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

using TaintedCainApp;
namespace AppUnitTesting
{
    [TestClass]

    public class ItemFactoryTests
    {
        #region CreateItem()
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException),
            "Parameter _name cannot be null.")]
        public void T_CreateItem_NameIsNull()
        {
            ItemFactory.CreateItem(null, new List<Recipe>());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException),
            "Parameter _recipes cannot be null.")]
        public void T_CreateItem_ListIsNull()
        {
            ItemFactory.CreateItem("foo", null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException),
            "Parameter _name cannot be null.")]
        public void T_CreateItem_BothNull()
        {
            ItemFactory.CreateItem(null, null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
            "Parameter _name cannot be empty.")]
        public void T_CreateItem_NameEmpty()
        {
            ItemFactory.CreateItem(String.Empty, new List<Recipe>());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
            "Parameter _name cannot be empty.")]
        public void T_CreateItem_NameEmptyListNull()
        {
            ItemFactory.CreateItem("", null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
            "One of the recîpe provided to item was not valid.\n\nRecipe :\n" +
                        "BoneHeart : 2\n" +
                        "RedHeart : 2\n" +
                        "SoulHeart : 2\n")]
        public void T_CreateItem_InvalidRecipe()
        {
            Dictionary<PickUp, int> components = new Dictionary<PickUp, int>();
            components.Add(PickUp.BoneHeart, 2);
            components.Add(PickUp.RedHeart, 2);
            components.Add(PickUp.SoulHeart, 2);
            Recipe recipe = new Recipe(components);

            List<Recipe> recipes = new List<Recipe> { recipe };

            ItemFactory.CreateItem("foo", recipes);
        }

        [TestMethod]
        public void T_CreateItem_Valid()
        {
            Dictionary<PickUp, int> components = new Dictionary<PickUp, int>();
            components.Add(PickUp.GoldenBomb, 1);
            components.Add(PickUp.EternalHeart, 2);
            components.Add(PickUp.SoulHeart, 5);
            Recipe recipe = new Recipe(components);

            List<Recipe> recipes = new List<Recipe> { recipe };

            ItemFactory.CreateItem("foo", recipes);
        }
        #endregion
    }
}
