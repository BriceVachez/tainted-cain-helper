using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

using TaintedCainApp;

namespace AppUnitTesting
{
    [TestClass]
    public class RecipeTests
    {
        #region IsValid()
        [TestMethod]
        public void T_RecipeIsValid_True_OnePickUp()
        {
            Dictionary<PickUp, int> components = new Dictionary<PickUp, int>();
            components.Add(PickUp.RedHeart, 8);
            Recipe recipe = new Recipe(components);

            bool isValid = recipe.IsValid();

            Assert.IsTrue(isValid, "Recipe has been detected as invalid.\n" + recipe.ToString());
        }

        [TestMethod]
        public void T_RecipeIsValid_True_MultiplePickUps()
        {
            Dictionary<PickUp, int> components = new Dictionary<PickUp, int>();
            components.Add(PickUp.RedHeart, 2);
            components.Add(PickUp.LuckyPenny, 6);
            Recipe recipe = new Recipe(components);

            bool isValid = recipe.IsValid();

            Assert.IsTrue(isValid, "Recipe has been detected as invalid.\n" + recipe.ToString());
        }

        [TestMethod]
        public void T_RecipeIsValid_False_OnePickUp()
        {
            Dictionary<PickUp, int> components = new Dictionary<PickUp, int>();
            components.Add(PickUp.ChargedKey, 4);
            Recipe recipe = new Recipe(components);

            bool isValid = recipe.IsValid();

            Assert.IsFalse(isValid, "Recipe has been detected as valid.\n" + recipe.ToString());
        }

        [TestMethod]
        public void T_RecipeIsValid_False_MultiplePickUps()
        {
            Dictionary<PickUp, int> components = new Dictionary<PickUp, int>();
            components.Add(PickUp.LilBattery, 3);
            components.Add(PickUp.BlackHeart, 4);
            components.Add(PickUp.Rune, 2);
            Recipe recipe = new Recipe(components);

            bool isValid = recipe.IsValid();

            Assert.IsFalse(isValid, "Recipe has been detected as valid.\n" + recipe.ToString());
        }
        #endregion
    }
}
