using System.Linq;
using Akka.Actor;
using Akkadotnet.Messages.Link;
using Akkadotnet.Utility;

namespace Akkadotnet.Actors.Link
{
    public class LinkFinder : ReceiveActor  
    {
        public LinkFinder()
        {
            Receive<FindLinks>(msg => FindLinks(msg.Contents));
        }

        private void FindLinks(string url)
        {
            var links = WebScraper.Scrape(url, "a").Select(node => node.GetAttributeValue("href", string.Empty));
            foreach (var link in links)
            {
                Context.ActorOf<LinkHandler>().Tell(new HandleLink(link));
            }
        }
    }
}
