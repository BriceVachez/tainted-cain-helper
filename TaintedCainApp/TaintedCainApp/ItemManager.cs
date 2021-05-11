using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace TaintedCainApp
{
    public class ItemManager
    {
        private static List<Item> items = new List<Item>();
        public static List<Item> Items { get => items; }

        public static void ReadItemsFromFile(String path = "../../../../data/items.json")
        {
            String json;
            try
            {
                json = File.ReadAllText(path);
            }
            catch (Exception e)
            {
                Console.WriteLine("No item file.");
                throw(e);
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

        public static void DisplayAllItems()
        {
            foreach (Item item in items)
            {
                Console.WriteLine(item.ToString());
            }
        }

        public static int GetTotalNumberOfItems(String path = "../../../../data/items.json")
        {
            String json;
            try
            {
                json = File.ReadAllText(path);
            }
            catch (Exception)
            {
                Console.WriteLine("No item file.");
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

        public static int RemoveItems()
        {
            int removed = items.Count;
            items.Clear();
            return removed;
        }

        public static int GetMaximumItemQuality()
        {
            int maxQuality = 0;
            foreach(Item item in items)
            {
                maxQuality = Math.Max(maxQuality, item.Quality);
            }
            return maxQuality;
        }
    }
}
