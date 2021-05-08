using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;
using System.Text;

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

        #region IsRecipeFeasible()
        [TestMethod]
        public void T_IsRecipeFeasible_True_ExactRecipe()
        {
            Dictionary<PickUp, int> components = new Dictionary<PickUp, int>();
            components.Add(PickUp.RedHeart, 8);
            Recipe recipe = new Recipe(components);

            Dictionary<PickUp, int> input = new Dictionary<PickUp, int>();
            input.Add(PickUp.RedHeart, 8);

            bool isValid = recipe.IsRecipeFeasible(input);

            Assert.IsTrue(isValid, "Recipe has been deemed non feasible. \nRecipe :\n" +
                recipe.ToString() +
                "\n\nInput :" +
                InputString(input));
        }

        [TestMethod]
        public void T_IsRecipeFeasible_True_MoreComponents()
        {
            Dictionary<PickUp, int> components = new Dictionary<PickUp, int>();
            components.Add(PickUp.BlackHeart, 4);
            components.Add(PickUp.Penny, 2);
            components.Add(PickUp.RottenHeart, 1);
            components.Add(PickUp.GoldenBomb, 1);
            Recipe recipe = new Recipe(components);

            Dictionary<PickUp, int> input = new Dictionary<PickUp, int>();
            input.Add(PickUp.BlackHeart, 4);
            input.Add(PickUp.Penny, 9);
            input.Add(PickUp.RottenHeart, 3);
            input.Add(PickUp.GoldenBomb, 1);
            input.Add(PickUp.SoulHeart, 3);

            bool isValid = recipe.IsRecipeFeasible(input);

            Assert.IsTrue(isValid, "Recipe has been deemed non feasible. \nRecipe :\n" +
                recipe.ToString() +
                "\n\nInput :" +
                InputString(input));
        }

        [TestMethod]
        public void T_IsRecipeFeasible_False_EmptyInput()
        {
            Dictionary<PickUp, int> components = new Dictionary<PickUp, int>();
            components.Add(PickUp.Nickel, 1);
            components.Add(PickUp.Penny, 3);
            components.Add(PickUp.Dime, 1);
            components.Add(PickUp.GoldenBomb, 1);
            components.Add(PickUp.GoldenKey, 1);
            components.Add(PickUp.GoldenHeart, 1);
            Recipe recipe = new Recipe(components);

            Dictionary<PickUp, int> input = new Dictionary<PickUp, int>();

            bool isValid = recipe.IsRecipeFeasible(input);

            Assert.IsFalse(isValid, "Recipe has been deemed feasible. \n\nRecipe :\n" +
                recipe.ToString() +
                "\n\nInput :" +
                InputString(input));
        }

        [TestMethod]
        public void T_IsRecipeFeasible_False_NullInput()
        {
            Dictionary<PickUp, int> components = new Dictionary<PickUp, int>();
            components.Add(PickUp.Penny, 8);
            Recipe recipe = new Recipe(components);

            Dictionary<PickUp, int> input = null;

            bool isValid = recipe.IsRecipeFeasible(input);

            Assert.IsFalse(isValid, "Recipe has been deemed feasible. \n\nRecipe :\n" +
                recipe.ToString() +
                "\n\nInput :" +
                InputString(input));
        }

        [TestMethod]
        public void T_IsRecipeFeasible_False_IncompleteInputButAllPickUps()
        {
            Dictionary<PickUp, int> components = new Dictionary<PickUp, int>();
            components.Add(PickUp.Dime, 1);
            components.Add(PickUp.Pill, 2);
            components.Add(PickUp.Card, 3);
            components.Add(PickUp.Rune, 2);
            Recipe recipe = new Recipe(components);

            Dictionary<PickUp, int> input = new Dictionary<PickUp, int>();
            input.Add(PickUp.Dime, 1);
            input.Add(PickUp.Pill, 3);
            input.Add(PickUp.Card, 5);
            input.Add(PickUp.Rune, 1);

            bool isValid = recipe.IsRecipeFeasible(input);

            Assert.IsFalse(isValid, "Recipe has been deemed feasible. \n\nRecipe :\n" +
                recipe.ToString() +
                "\n\nInput :" +
                InputString(input));
        }

        [TestMethod]
        public void T_IsRecipeFeasible_False_IncompleteInputAndMissingPickUps()
        {
            Dictionary<PickUp, int> components = new Dictionary<PickUp, int>();
            components.Add(PickUp.Penny, 1);
            components.Add(PickUp.RedHeart, 4);
            components.Add(PickUp.BoneHeart, 1);
            components.Add(PickUp.GoldenKey, 1);
            components.Add(PickUp.Bomb, 1);
            Recipe recipe = new Recipe(components);

            Dictionary<PickUp, int> input = new Dictionary<PickUp, int>();
            input.Add(PickUp.RedHeart, 3);
            input.Add(PickUp.Penny, 9);
            input.Add(PickUp.Rune, 1);
            input.Add(PickUp.Bomb, 7);

            bool isValid = recipe.IsRecipeFeasible(input);

            Assert.IsFalse(isValid, "Recipe has been deemed feasible. \n\nRecipe :\n" +
                recipe.ToString() +
                "\n\nInput :" +
                InputString(input));
        }
        #endregion

        #region AddPickUp()
        [TestMethod]
        public void T_AddPickUp_NewPickUp()
        {
            Dictionary<PickUp, int> components = new Dictionary<PickUp, int>();
            components.Add(PickUp.RedHeart, 4);
            Recipe recipe = new Recipe(components);

            recipe.AddPickUp(PickUp.BlackHeart);

            Dictionary<PickUp, int> expectedComponents = new Dictionary<PickUp, int>();
            expectedComponents.Add(PickUp.RedHeart, 4);
            expectedComponents.Add(PickUp.BlackHeart, 1);

            CollectionAssert.AreEquivalent(expectedComponents, recipe.Components);
        }

        [TestMethod]
        public void T_AddPickUp_ExistingPickUp()
        {
            Dictionary<PickUp, int> components = new Dictionary<PickUp, int>();
            components.Add(PickUp.Penny, 2);
            components.Add(PickUp.Nickel, 3);
            Recipe recipe = new Recipe(components);

            recipe.AddPickUp(PickUp.Nickel);

            Dictionary<PickUp, int> expectedComponents = new Dictionary<PickUp, int>();
            expectedComponents.Add(PickUp.Penny, 2);
            expectedComponents.Add(PickUp.Nickel, 4);

            CollectionAssert.AreEquivalent(expectedComponents, recipe.Components);
        }

        [TestMethod]
        public void T_AddPickUp_PreviouslyEmpty()
        {
            Recipe recipe = new Recipe();

            recipe.AddPickUp(PickUp.GoldenKey);

            Dictionary<PickUp, int> expectedComponents = new Dictionary<PickUp, int>();
            expectedComponents.Add(PickUp.GoldenKey, 1);

            CollectionAssert.AreEquivalent(expectedComponents, recipe.Components);
        }
        #endregion

        #region CopyRecipe()
        [TestMethod]
        public void T_CopyRecipe()
        {
            Dictionary<PickUp, int> components = new Dictionary<PickUp, int>();
            components.Add(PickUp.Penny, 4);
            components.Add(PickUp.Bomb, 3);
            components.Add(PickUp.Key, 1);
            Recipe recipe = new Recipe(components);

            Recipe copiedRecipe = recipe.CopyRecipe();
            CollectionAssert.AreEquivalent(recipe.Components, copiedRecipe.Components);

            recipe.AddPickUp(PickUp.Pill);
            Dictionary<PickUp, int> expectedOriginalComponents = new Dictionary<PickUp, int>();
            expectedOriginalComponents.Add(PickUp.Penny, 4);
            expectedOriginalComponents.Add(PickUp.Bomb, 3);
            expectedOriginalComponents.Add(PickUp.Key, 1);
            expectedOriginalComponents.Add(PickUp.Pill, 1);
            CollectionAssert.AreEquivalent(expectedOriginalComponents, recipe.Components);

            Dictionary<PickUp, int> expectedCopyComponents = new Dictionary<PickUp, int>();
            expectedCopyComponents.Add(PickUp.Penny, 4);
            expectedCopyComponents.Add(PickUp.Bomb, 3);
            expectedCopyComponents.Add(PickUp.Key, 1);
            CollectionAssert.AreEquivalent(expectedCopyComponents, copiedRecipe.Components);
        }
        #endregion

        #region Non-test methods
        private String InputString(Dictionary<PickUp, int> input)
        {
            if(input == null)
            {
                return String.Empty;
            }
            StringBuilder inputString = new StringBuilder();
            foreach(KeyValuePair<PickUp, int> pickUp in input)
            {
                inputString.Append(Enum.GetName(typeof(PickUp), pickUp.Key) +
                    " : " +
                    pickUp.Value.ToString());
            }
            return inputString.ToString();
        }
        #endregion
    }
}
