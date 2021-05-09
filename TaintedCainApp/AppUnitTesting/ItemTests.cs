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
            Item item = ItemFactory.CreateItem("Sad Onion", new List<Recipe>());

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

        #region Attribute name
        [TestMethod]
        public void T_AttributeName_Getter()
        {
            Item item = ItemFactory.CreateItem("Sad Onion", new List<Recipe>());

            String expectedName = "Sad Onion";

            Assert.AreEqual(expectedName, item.Name);
        }
        [TestMethod]
        public void T_AttributeName_Setter()
        {
            Item item = ItemFactory.CreateItem("Sad Onion", new List<Recipe>());
            item.Name = "Dr. Fetus";

            String expectedName = "Dr. Fetus";

            Assert.AreEqual(expectedName, item.Name);
        }
        #endregion
    }
}
