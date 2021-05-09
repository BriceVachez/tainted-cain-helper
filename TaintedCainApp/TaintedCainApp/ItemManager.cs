using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace TaintedCainApp
{
    public class ItemManager
    {
        private static List<Item> items = new List<Item>();

        public static void ReadItemsFromFile()
        {
            String json = File.ReadAllText("../../../../data/items.json");

            dynamic result = Newtonsoft.Json.JsonConvert.DeserializeObject(json);

            foreach (var item in result)
            {
                String name = item.Name;
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
                items.Add(ItemFactory.CreateItem(name, recipes));
            }
        }

        public static void DisplayAllItems()
        {
            foreach (Item item in items)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}
