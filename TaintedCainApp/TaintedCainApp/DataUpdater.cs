using System;
using System.Collections.Generic;
using Newtonsoft.Json;

using System.IO;

namespace TaintedCainApp
{
    public class DataUpdater
    {

        private static List<String> urls = new List<String>
        {
            "https://bindingofisaacrebirth.fandom.com/wiki/Bag_of_Crafting_(Recipes)_-_Passive_(1-399)",
            "https://bindingofisaacrebirth.fandom.com/wiki/Bag_of_Crafting_(Recipes)_-_Passive_(400-727)",
            "https://bindingofisaacrebirth.fandom.com/wiki/Bag_of_Crafting_(Recipes)_-_Active"
        };

        public static void GenerateItemsFromWiki()
        {
            List<Item> items = new List<Item>();
            Console.WriteLine("Coucou 1");
            foreach(String url in urls)
            {
                Console.WriteLine("Coucou 2.1");
                CainWikiScraper.GenerateItemsFromUrl(url, items);
                Console.WriteLine("Coucou 2.2");
            }
            Console.WriteLine("Coucou 3");
            GenerateItemFile(items);
            Console.WriteLine("Coucou 4");
        }

        private static void GenerateItemFile(List<Item> items)
        {
            String json = JsonConvert.SerializeObject(items, Formatting.Indented);
            File.WriteAllText("../../../../data/items.json", json);
        }
    }
}
