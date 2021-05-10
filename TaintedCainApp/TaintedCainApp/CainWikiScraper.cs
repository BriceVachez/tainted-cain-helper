using System;
using System.Collections.Generic;

using HtmlAgilityPack;
using ScrapySharp.Network;
using System.Net;
using System.Text.RegularExpressions;

using System.Threading.Tasks;

namespace TaintedCainApp
{
    public class CainWikiScraper
    {
        private static ScrapingBrowser _browser = new ScrapingBrowser();
        public static void GenerateItemsFromUrl(String url, List<Item> itemsList)
        {
            Console.WriteLine("Coucou html1");
            HtmlNode webPage = GetHtml(url);
            Console.WriteLine("Coucou html2");
            if (webPage == null)
            {
                throw new WebException("The requested URL : " + url + " is unreachable.");
            }
            Console.WriteLine("Coucou html3");

            HtmlNodeCollection itemsOnPage = webPage.SelectNodes(
                ".//table[contains(@class, 'sortable')]/tbody/tr[position()>1]"
                );
            Console.WriteLine("Retrieved : " + itemsOnPage.Count);

            foreach(HtmlNode item in itemsOnPage)
            {
                itemsList.Add(GenerateItem(item));
            }
        }

        private static HtmlNode GetHtml(String url)
        {
            try
            {
                HtmlWeb web = new HtmlWeb();
                HtmlDocument doc = web.Load(url);
                HtmlNode rootNode = doc.DocumentNode;
                return rootNode;
            }
            catch (AggregateException)
            {
                return null;
            }
        }

        private static Item GenerateItem(HtmlNode itemNode)
        {
            HtmlNodeCollection cells = itemNode.SelectNodes("td");
            // Get name
            String name = GetName(cells[0]);

            // Get recipes
            List<Recipe> recipes = GenerateRecipes(itemNode);
            // Generate item
            Item item = ItemFactory.CreateItem(name, recipes);
            // Return it
            return item;
        }

        private static String GetName(HtmlNode itemNode)
        {
            HtmlNode titleNode = itemNode.SelectSingleNode("span/a[2]");
            String name = titleNode.InnerText;
            return name;
        }

        private static List<Recipe> GenerateRecipes(HtmlNode itemNode)
        {
            HtmlNodeCollection recipeNodes = itemNode.SelectNodes("td[position()>2]");
            List<Recipe> recipes = new List<Recipe>();

            foreach(HtmlNode recipeNode in recipeNodes)
            {
                Recipe recipe = new Recipe();
                HtmlNodeCollection pickUpNodes = recipeNode.SelectNodes("descendant::td");
                foreach(HtmlNode pickUpNode in pickUpNodes)
                {
                    String pickUpId = Regex.Replace(pickUpNode.
                        SelectSingleNode("a").
                        GetAttributeValue("title", ""),
                        "^.*\\(",
                        String.Empty);

                    int pickUp = Int32.Parse(Regex.Replace(pickUpId, "\\)", String.Empty));

                    recipe.AddPickUp((PickUp)pickUp);
                }
                recipes.Add(recipe);
            }
            return recipes;
        }
    }
}
