using System;
using System.Collections.Generic;
using System.Text;

namespace TaintedCainApp.Model
{
    public class Item
    {
        #region Attributes
        private String name;
        public String Name { get => name; set => name = value; }

        private int itemId;
        public int ItemId { get => itemId; }

        private bool isActiveItem;
        public bool IsActiveItem { get => isActiveItem; }

        private int quality;
        public int Quality { get => quality; }

        private List<Recipe> recipes;
        public List<Recipe> Recipes { get => recipes; }

        private bool isMarked;
        public bool IsMarked { get => isMarked; set => isMarked = value; }
        #endregion

        #region Constructors
        internal Item(String _name, 
            int _itemId, 
            int _quality,
            bool _isActiveItem,
            List<Recipe> _recipes)
        {
            name = _name;
            itemId = _itemId;
            quality = _quality;
            isActiveItem = _isActiveItem;
            recipes = _recipes;
            isMarked = false;
        }
        #endregion

        #region Public Methods
        #endregion

        #region Override
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder("Name : " + name + "\n");
            sb.Append("Id : " + itemId.ToString() + "\n");
            sb.Append("Quality : " + quality.ToString() + "\n");
            sb.Append("IsActive : " + isActiveItem.ToString() + "\n");
            sb.Append("Recipes :\n{");
            foreach (Recipe recipe in recipes)
            {
                sb.Append("\n" + recipe.ToString() + " ----");
            }
            sb.Append("\n}");
            return sb.ToString();
        }
        #endregion
    }
}
