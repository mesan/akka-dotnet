using HtmlAgilityPack;
using System.Net;

namespace Akkadotnet.Utility
{
    public static class WebScraper
    {
        public static HtmlNodeCollection Scrape(string pageUrl, string xPath)
        {
            using (var webClient = new WebClient())
            {
                webClient.Proxy = null;
                var doc = new HtmlDocument();
                doc.LoadHtml(webClient.DownloadString(pageUrl));
                return doc.DocumentNode.SelectNodes("//" + xPath);
            }
        }
    }
}
