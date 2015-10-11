using System.Linq;
using Akka.Actor;
using Akkadotnet.Messages;
using Akkadotnet.Messages.Header;
using Akkadotnet.Utility;

namespace Akkadotnet.Actors.Header
{
    public class HeaderFinder : ReceiveActor
    {
        public HeaderFinder()
        {
            Receive<UrlStringMessage>(message => FindHeader(message.Contents));
        }

        private void FindHeader(string url)
        {
            var header = WebScraper.Scrape(url, "h1[@id='firstHeading']").First();
            var headerText = header.InnerText;
            Sender.Tell(new HeaderTextMessage(headerText));
        }
    }
}
