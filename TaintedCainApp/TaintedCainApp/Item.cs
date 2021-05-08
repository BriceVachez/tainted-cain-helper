using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaintedCainApp
{
    public class Item
    {
        private String name;
        public String Name { get => name; set => name = value; }

        private List<Recipe> recipes;

        public Item(String _name, List<Recipe> _recipes)
        {
            name = _name;
            recipes = _recipes;
        }

        public Item(String _name)
        {
            name = _name;
            recipes = new List<Recipe>();
        }

        public void AddRecipe(Recipe _newRecipe)
        {
            recipes.Add(_newRecipe);
        }
    }
}
