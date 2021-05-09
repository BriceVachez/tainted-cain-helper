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
            String json = String.Empty;
            try
            {
                json = File.ReadAllText("../../../../data/items.json");
            } catch(Exception e)
            {
                Console.WriteLine("No item file.");
                return;
            }

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

        public static int GetTotalNumberOfItems()
        {
            String json = String.Empty;
            try
            {
                json = File.ReadAllText("../../../../data/items.json");
            }
            catch (Exception e)
            {
                Console.WriteLine("No item file.");
                return 0;
            }

            dynamic result = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
            int itemCount = 0;
            foreach(var item in result)
            {
                itemCount++;
            }
            return itemCount;
        }

        public static int GetCurrentNumberOfItems()
        {
            return items.Count;
        }
    }
}
