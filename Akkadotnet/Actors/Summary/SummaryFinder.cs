using System.Linq;
using Akka.Actor;
using Akkadotnet.Messages;
using Akkadotnet.Messages.Summary;
using Akkadotnet.Utility;

namespace Akkadotnet.Actors.Summary
{
    public class SummaryFinder : ReceiveActor
    {
        public SummaryFinder()
        {
            Receive<UrlStringMessage>(msg => FindSummary(msg.Contents));
        }

        private void FindSummary(string url)
        {
            var firstParagraph = WebScraper.Scrape(url, "div[@id='mw-content-text']/p").First();
            var paragraphText = firstParagraph.InnerText;
            Sender.Tell(new SummaryTextMessage(paragraphText));
        }
    }
}
