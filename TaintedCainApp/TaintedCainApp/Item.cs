using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaintedCainApp
{
    public class Item
    {
        #region Attributes
        private String name;
        public String Name { get => name; set => name = value; }

        private List<Recipe> recipes;
        public List<Recipe> Recipes { get => recipes; }
        #endregion

        #region Constructors
        internal Item(String _name, List<Recipe> _recipes)
        {
            name = _name;
            recipes = _recipes;
        }
        #endregion

        #region Public Methods
        public void AddRecipe(Recipe _newRecipe)
        {
            recipes.Add(_newRecipe);
        }
        #endregion

        #region Override
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder("Name : " + name + "\nRecipes : {\n");
            foreach(Recipe recipe in recipes)
            {
                sb.Append(recipe.ToString() + " ----\n");
            }
            sb.Append("}");
            return sb.ToString();
        }
        #endregion
    }
}
