using Akka.Actor;
using Akkadotnet.Exceptions;
using Akkadotnet.Messages;
using Akkadotnet.Utility;
using System.Linq;

namespace Akkadotnet.Actors.Link
{
    public class LinkFinder : ReceiveActor  
    {
        public LinkFinder()
        {
            Receive<UrlStringMessage>(msg => FindLinks(msg.Contents));
        }

        protected override SupervisorStrategy SupervisorStrategy()
        {
            return new OneForOneStrategy(
                exception =>
                {
                    if (exception is InvalidLinkException)
                    {
                        return Directive.Stop;
                    }
                    return Directive.Escalate;
                });
        }

        private void FindLinks(string url)
        {
            var links = WebScraper.Scrape(url, "a").Select(node => node.GetAttributeValue("href", string.Empty));
            foreach (var link in links)
            {
                Context.ActorOf(ActorProps.LinkHandlerProps).Tell(new UrlStringMessage(link));
            }
        }
    }
}
