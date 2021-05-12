using System;
using System.Collections.Generic;
using Newtonsoft.Json;

using System.IO;

using TaintedCainApp.Model;

namespace TaintedCainApp.Util
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
            foreach(String url in urls)
            {
                CainWikiScraper.GenerateItemsFromUrl(url, items);
            }
            GenerateItemFile(items);
        }

        public static void GeneratePickupImages()
        {
            CainWikiScraper.GeneratePickupImages(urls[0]);
        }

        private static void GenerateItemFile(
            List<Item> items, 
            String path = "../data/items.json")
        {
            String json = JsonConvert.SerializeObject(items, Formatting.Indented);
            File.WriteAllText(path, json);
        }
    }
}
