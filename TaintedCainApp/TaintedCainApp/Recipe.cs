using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaintedCainApp
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
        Nicked = 9,
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
        private const int PICKUPS_IN_RECIPE = 8;

        private Dictionary<PickUp, int> recipe;

        public Recipe()
        {
            recipe = new Dictionary<PickUp, int>();
        }

        public Recipe(Dictionary<PickUp, int> _recipe)
        {
            recipe = new Dictionary<PickUp, int>();
            foreach(PickUp pickUp in _recipe.Keys)
            {
                recipe.Add(pickUp, _recipe[pickUp]);
            }
        }

        public void AddPickUp(PickUp pickUp)
        {
            recipe.TryGetValue(pickUp, out var occurences);
            recipe[pickUp] = occurences;
        }

        public Recipe CopyRecipe()
        {
            return new Recipe(this.recipe);
        }

        public bool IsValid()
        {
            int numberOfPickUps = 0;
            foreach(KeyValuePair<PickUp, int> component in recipe)
            {
                numberOfPickUps += component.Value;
            }

            return numberOfPickUps == PICKUPS_IN_RECIPE;
        }

        public bool IsRecipeFeasible(Dictionary<PickUp, int> pickUps)
        {
            int occurencesInInput = 0;
            foreach (PickUp pickUp in recipe.Keys)
            {
                pickUps.TryGetValue(pickUp, out occurencesInInput);
                if (occurencesInInput < recipe[pickUp])
                {
                    return false;
                }
            }
            return true;
        }

        public override string ToString()
        {
            StringBuilder recipeString = new StringBuilder();
            foreach(KeyValuePair<PickUp, int> component in recipe)
            {
                recipeString.Append(Enum.GetName(typeof(PickUp), component.Key) + " : " + component.Value);
            }
            return recipeString.ToString();
        }
    }

}
