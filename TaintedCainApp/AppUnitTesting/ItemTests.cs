using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

using TaintedCainApp;

namespace AppUnitTesting
{
    [TestClass]
    public class ItemTests
    {
        #region AddRecipe()
        [TestMethod]
        public void T_AddRecipe()
        {
            Item item = ItemFactory.CreateItem("Sad Onion", 1, 2, false, new List<Recipe>());

            Dictionary<PickUp, int> components = new Dictionary<PickUp, int>();
            components.Add(PickUp.RedHeart, 4);
            components.Add(PickUp.SoulHeart, 1);
            components.Add(PickUp.Penny, 2);
            components.Add(PickUp.Bomb, 1);
            Recipe recipe = new Recipe(components);

            item.AddRecipe(recipe);

            List<Recipe> expectedRecipes = new List<Recipe> { recipe };

            CollectionAssert.AreEqual(expectedRecipes, item.Recipes);
        }
        #endregion

        #region ToString()
        [TestMethod]
        public void T_ToString_NoRecipe()
        {
            Item item = ItemFactory.CreateItem(
                "Cricket's Head",
                4,
                4,
                false,
                new List<Recipe>());

            String expectedString = "Name : Cricket's Head\n" +
                "Id : 4\n" +
                "Quality : 4\n" +
                "IsActive : False\n" +
                "Recipes :\n{\n}";

            Assert.AreEqual(expectedString, item.ToString());
        }

        [TestMethod]
        public void T_ToString_Recipes()
        {
            Dictionary<PickUp, int> components1 = new Dictionary<PickUp, int>();
            components1.Add(PickUp.Bomb, 6);
            components1.Add(PickUp.Penny, 2);

            Dictionary<PickUp, int> components2 = new Dictionary<PickUp, int>();
            components2.Add(PickUp.Nickel, 4);
            components2.Add(PickUp.RedHeart, 2);
            components2.Add(PickUp.SoulHeart, 2);

            Item item = ItemFactory.CreateItem(
                "Mr. Boom",
                612,
                1,
                true,
                new List<Recipe>
                {
                    new Recipe(components1),
                    new Recipe(components2)
                });

            String expectedString = "Name : Mr. Boom\n" +
                "Id : 612\n" +
                "Quality : 1\n" +
                "IsActive : True\n" +
                "Recipes :\n{\n" +
                "Bomb : 6\n" +
                "Penny : 2\n" +
                " ----\n" +
                "Nickel : 4\n" +
                "RedHeart : 2\n" +
                "SoulHeart : 2\n" +
                " ----\n" +
                "}";

            Assert.AreEqual(expectedString, item.ToString());
        }
        #endregion

        #region Attributes

        #region Attribute name
        [TestMethod]
        public void T_AttributeName_Getter()
        {
            Item item = ItemFactory.CreateItem("Sad Onion", 1, 3, false, new List<Recipe>());

            String expectedName = "Sad Onion";

            Assert.AreEqual(expectedName, item.Name);
        }
        [TestMethod]
        public void T_AttributeName_Setter()
        {
            Item item = ItemFactory.CreateItem("Sad Onion", 1, 4, false, new List<Recipe>());
            item.Name = "Dr. Fetus";

            String expectedName = "Dr. Fetus";

            Assert.AreEqual(expectedName, item.Name);
        }
        #endregion

        #region Attribute Id
        [TestMethod]
        public void T_AttributeId_Getter()
        {
            Item item = ItemFactory.CreateItem("Sad Onion", 1, 3, false, new List<Recipe>());

            int expectedId = 1;

            Assert.AreEqual(expectedId, item.ItemId);
        }
        #endregion

        #region Attribute Quality
        [TestMethod]
        public void T_AttributeQuality_Getter()
        {
            Item item = ItemFactory.CreateItem("Sad Onion", 1, 3, false, new List<Recipe>());

            int expectedQuality = 3;

            Assert.AreEqual(expectedQuality, item.Quality);
        }
        #endregion

        #region Attribute IsActiveItem
        [TestMethod]
        public void T_AttributeIsActiveItem_Getter()
        {
            Item item = ItemFactory.CreateItem("Mr. Boom", 612, 1, true, new List<Recipe>());

            bool expectedActive = true;

            Assert.AreEqual(expectedActive, item.IsActiveItem);
        }
        #endregion

        #endregion
    }
}
