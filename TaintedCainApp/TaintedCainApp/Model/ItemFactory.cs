using System;
using System.Collections.Generic;

namespace TaintedCainApp.Model
{
    public class ItemFactory
    {
        public static Item CreateItem(String _name, 
            int _itemId, 
            int _quality,
            bool _isActiveItem, 
            List<Recipe> _recipes)
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

            if(_quality < 0 || _quality > 4)
            {
                throw new ArgumentException(
                    "Parameter _quality must be between 0 and 4. Found " +
                    _quality.ToString()
                    );
            }

            foreach(Recipe recipe in _recipes) {
                if(!recipe.IsValid())
                {
                    throw new ArgumentException("One of the recîpe provided to item was not valid.\n\nRecipe :\n" +
                        recipe.ToString());
                }
            }
            #endregion

            return new Item(_name, _itemId, _quality, _isActiveItem, _recipes);
        }
    }
}
