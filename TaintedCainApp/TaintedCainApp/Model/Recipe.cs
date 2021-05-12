using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaintedCainApp.Model
{
    public enum PickUp
    {
        RedHeart = 1,
        SoulHeart = 2,
        BlackHeart = 3,
        EternalHeart = 4,
        GoldenHeart = 5,
        BoneHeart = 6,
        RottenHeart = 7,
        Penny = 8,
        Nickel = 9,
        Dime = 10,
        LuckyPenny = 11,
        Key = 12,
        GoldenKey = 13,
        ChargedKey = 14,
        Bomb = 15,
        GoldenBomb = 16,
        MicroBattery = 18,
        LilBattery = 19,
        Card = 21,
        Pill = 22,
        Rune = 23
    }

    public class Recipe
    {
        #region Constants
        private const int PICKUPS_IN_RECIPE = 8;
        #endregion

        #region Attributes
        private Dictionary<PickUp, int> components;
        public Dictionary<PickUp, int> Components { get => components; }
        #endregion

        #region Constructors
        public Recipe()
        {
            components = new Dictionary<PickUp, int>();
        }

        public Recipe(Dictionary<PickUp, int> _recipe)
        {
            components = new Dictionary<PickUp, int>();
            foreach(PickUp pickUp in _recipe.Keys)
            {
                components.Add(pickUp, _recipe[pickUp]);
            }
        }
        #endregion

        #region Public methods

        public void AddPickUp(PickUp pickUp)
        {
            components.TryGetValue(pickUp, out var occurences);
            components[pickUp] = occurences + 1;
        }

        public Recipe CopyRecipe()
        {
            return new Recipe(this.components);
        }

        public bool IsValid()
        {
            int numberOfPickUps = 0;
            foreach(KeyValuePair<PickUp, int> component in components)
            {
                numberOfPickUps += component.Value;
            }
            return numberOfPickUps == PICKUPS_IN_RECIPE;
        }

        public bool IsRecipeFeasible(Dictionary<PickUp, int> pickUps)
        {
            if(pickUps == null)
            {
                return false;
            }
            foreach (PickUp pickUp in components.Keys)
            {
                pickUps.TryGetValue(pickUp, out int occurencesInInput);
                if (occurencesInInput < components[pickUp])
                {
                    return false;
                }
            }
            return true;
        }

        #endregion

        #region Override
        public override string ToString()
        {
            StringBuilder recipeString = new StringBuilder();
            foreach(KeyValuePair<PickUp, int> component in components)
            {
                recipeString.Append(Enum.GetName(typeof(PickUp), component.Key) +
                    " : " +
                    component.Value.ToString() +
                    "\n");
            }
            return recipeString.ToString();
        }
        #endregion
    }

}
