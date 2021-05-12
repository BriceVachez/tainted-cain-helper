using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

using TaintedCainApp.Model;

namespace TaintedCainApp.Util
{
    public class ItemManager
    {
        private static List<Item> items = new List<Item>();
        public static List<Item> Items { get => items; }

        public static void ReadItemsFromFile(String path = "../data/items.json")
        {
            String json;
            try
            {
                json = File.ReadAllText(path);
            }
            catch (Exception e)
            {

                throw (e);
            }

            dynamic result = JsonConvert.DeserializeObject(json);

            foreach (var item in result)
            {
                String name = item.Name;
                int id = item.ItemId;
                int quality = item.Quality;
                bool active = item.IsActiveItem;
                List<Recipe> recipes = new List<Recipe>();
                foreach (var recipe in item.Recipes)
                {
                    Dictionary<string, int> jsonComponents =
                        JsonConvert.DeserializeObject<Dictionary<string, int>>(recipe.Components.ToString());
                    Dictionary<PickUp, int> components = new Dictionary<PickUp, int>();
                    foreach (KeyValuePair<string, int> component in jsonComponents)
                    {
                        components.Add(
                            (PickUp)Enum.Parse(typeof(PickUp), component.Key),
                            component.Value
                        );
                    }
                    recipes.Add(new Recipe(components));
                }
                items.Add(ItemFactory.CreateItem(name, id, quality, active, recipes));
            }
        }

        public static int GetTotalNumberOfItems(String path = "../data/items.json")
        {
            String json;
            try
            {
                json = File.ReadAllText(path);
            }
            catch (Exception)
            {
                return 0;
            }

            dynamic result = JsonConvert.DeserializeObject(json);
            int itemCount = 0;
            foreach (var item in result)
            {
                itemCount++;
            }
            return itemCount;
        }

        public static int GetCurrentNumberOfItems()
        {
            return items.Count;
        }

        public static int GetMaximumItemQuality()
        {
            int maxQuality = 0;
            foreach (Item item in items)
            {
                maxQuality = Math.Max(maxQuality, item.Quality);
            }
            return maxQuality;
        }

        public static ItemNode GenerateAllRecipes(
            List<Item> availableItems,
            Dictionary<PickUp, int> pickUps,
            bool includeDuplicate=false)
        {
            UnmarkAllItems();
            ItemNode root = new ItemNode(null, 0, null);
            GenerateTree(availableItems, pickUps, root, true, includeDuplicate);
            return root;
        }

        private static void GenerateTree(List<Item> availableItems,
            Dictionary<PickUp, int> pickUps,
            ItemNode currentParent,
            bool isFirstLayer,
            bool includeDuplicate)
        {
            foreach (Item item in availableItems)
            {
                if(!includeDuplicate && item.IsMarked)
                {
                    continue;
                }

                foreach (Recipe recipe in item.Recipes)
                {
                    if (recipe.IsRecipeFeasible(pickUps))
                    {
                        ItemNode child = new ItemNode(
                            currentParent,
                            item.ItemId,
                            recipe);

                        RemovePickUpsFromRecipe(pickUps, recipe);

                        item.IsMarked = true;
                        GenerateTree(availableItems, pickUps, child, false, includeDuplicate);
                        item.IsMarked = false;

                        AddPickUpsFromRecipe(pickUps, recipe);
                        currentParent.AddChild(child);
                    }
                }

                if(isFirstLayer)
                {
                    item.IsMarked = true;
                }
            }
        }

        private static void RemovePickUpsFromRecipe(
            Dictionary<PickUp, int> pickUps,
            Recipe recipe)
        {
            foreach(KeyValuePair<PickUp, int> component in recipe.Components)
            {
                pickUps[component.Key] -= component.Value;
            }
        }

        private static void AddPickUpsFromRecipe(
            Dictionary<PickUp, int> pickUps,
            Recipe recipe)
        {
            foreach (KeyValuePair<PickUp, int> component in recipe.Components)
            {
                pickUps[component.Key] += component.Value;
            }

        }

        private static void UnmarkAllItems()
        {
            foreach(Item item in items)
            {
                item.IsMarked = false;
            }
        }
    }
}
