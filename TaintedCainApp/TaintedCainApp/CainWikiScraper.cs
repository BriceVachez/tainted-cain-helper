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
        #region Attributes
        private static ScrapingBrowser _browser = new ScrapingBrowser();
        private static WebClient _client = new WebClient();

        private static String itemsUrl = "https://bindingofisaacrebirth.fandom.com/wiki/Items";
        #endregion

        #region Public Methods
        public static void GenerateItemsFromUrl(String url, List<Item> itemsList)
        {
            HtmlNode recipeWebPage = GetHtml(url);
            if (recipeWebPage == null)
            {
                throw new WebException("The requested URL : " + url + " is unreachable.");
            }

            HtmlNode itemWebPage = GetHtml(itemsUrl);
            if (itemWebPage == null)
            {
                throw new WebException("The requested URL : " + itemWebPage + " is unreachable.");
            }

            HtmlNodeCollection itemsOnPage = recipeWebPage.SelectNodes(
                ".//table[contains(@class, 'sortable')]/tbody/tr[position()>1]"
                );
            Console.WriteLine("Retrieved : " + itemsOnPage.Count);

            foreach (HtmlNode item in itemsOnPage)
            {
                itemsList.Add(GenerateItem(
                    item,
                    itemWebPage,
                    url.Contains("Active")));
            }
        }

        public static void GeneratePickupImages(String url)
        {
            HtmlNode pickupsWebPage = GetHtml(url);
            if (pickupsWebPage == null)
            {
                throw new WebException("The requested URL : " + pickupsWebPage + " is unreachable.");
            }

            String xpath;
            foreach(int pickup in Enum.GetValues(typeof(PickUp)))
            {
                xpath = "//img[contains(@alt, '(" + pickup + "')]";
                String imageUrl = pickupsWebPage.
                    SelectSingleNode(xpath).
                    GetAttributeValue("src", String.Empty);

                try
                {
                    _client.DownloadFile(imageUrl,
                        "../../../../data/Images/Pickups/" +
                        pickup.ToString() +
                        ".png");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        #endregion

        #region Private Methods

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

        private static Item GenerateItem(
            HtmlNode itemNode, 
            HtmlNode itemPageRootNode, 
            bool isUrlActive)
        {
            HtmlNodeCollection cells = itemNode.SelectNodes("td");
            // Get name
            String name = GetName(cells[0]);
            // Get id
            int itemId = GetId(cells[1]);
            // Download image
            GetItemImage(itemPageRootNode, itemId);
            // Get quality
            int quality = GetQuality(itemPageRootNode, itemId);
            // Get recipes
            List<Recipe> recipes = GenerateRecipes(itemNode);
            // Generate item
            Item item = ItemFactory.CreateItem(
                name,
                itemId,
                quality,
                isUrlActive,
                recipes
                );
            // Return it
            return item;
        }

        private static String GetName(HtmlNode itemNode)
        {
            HtmlNode titleNode = itemNode.SelectSingleNode("span/a[2]");
            String name = titleNode.InnerText;
            return name;
        }

        private static int GetId(HtmlNode itemNode)
        {
            return Int32.Parse(itemNode.InnerText);
        }

        private static int GetQuality(HtmlNode itemPageRootNode, int id)
        {
            String xpath = "//tr[td[@data-sort-value='" + id + "']]/td[last()]";
            HtmlNode qualityNode = itemPageRootNode.SelectSingleNode(xpath);
            return Int32.Parse(qualityNode.InnerText);
        }

        private static List<Recipe> GenerateRecipes(HtmlNode itemNode)
        {
            HtmlNodeCollection recipeNodes = itemNode.SelectNodes("td[position()>2]");
            List<Recipe> recipes = new List<Recipe>();

            foreach (HtmlNode recipeNode in recipeNodes)
            {
                Recipe recipe = new Recipe();
                HtmlNodeCollection pickUpNodes = recipeNode.SelectNodes("descendant::td");
                foreach (HtmlNode pickUpNode in pickUpNodes)
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

        private static void GetItemImage(HtmlNode itemPageRootNode, int itemId)
        {
            String xpath = "//tr[td[@data-sort-value='" + itemId + "']]/td[3]//img";
            HtmlNode imageNode = itemPageRootNode.SelectSingleNode(xpath);

            String url = imageNode.GetAttributeValue("src", String.Empty);
            try
            {
                _client.DownloadFile(url,
                    "../../../../data/Images/Items/" +
                    itemId.ToString() +
                    ".png");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        #endregion
    }
}
