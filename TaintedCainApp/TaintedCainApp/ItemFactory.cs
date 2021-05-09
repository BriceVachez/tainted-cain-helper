using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaintedCainApp
{
    public class ItemFactory
    {
        public static Item CreateItem(String _name, List<Recipe> _recipes)
        {
            #region Exceptions
            if (_name == null)
            {
                throw new ArgumentNullException("Parameter _name cannot be null.");
            }

            if(_name == String.Empty)
            {
                throw new ArgumentException("Parameter _name cannot be empty.");
            }

            if(_recipes == null)
            {
                throw new ArgumentNullException("Parameter _recipes cannot be null.");
            }

            foreach(Recipe recipe in _recipes) {
                if(!recipe.IsValid())
                {
                    throw new ArgumentException("One of the recîpe provided to item was not valid.\n\nRecipe :\n" +
                        recipe.ToString());
                }
            }
            #endregion

            return new Item(_name, _recipes);
        }
    }
}
