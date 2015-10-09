using Akka.Actor;
using Akkadotnet.Exceptions;
using Akkadotnet.Messages;

namespace Akkadotnet.Actors.Link
{
    public class LinkHandler : ReceiveActor
    {
        public LinkHandler()
        {
            Receive<UrlStringMessage>(msg => HandleLink(msg.Contents));
        }

        private void HandleLink(string url)
        {
            if (IsValidWikipediaUrl(url))
            {
                Context.ActorSelection("/user/Master")
                    .Tell(new WikipediaUrlParseRequest("http://en.wikipedia.org" + url)); //prefix url ut i config
            }
            else
            {
                throw new InvalidLinkException($"Invalid url {url}");
            }
        }

        private bool IsValidWikipediaUrl(string url)
        {
            return url.StartsWith("/wiki") && !url.Contains(":");
        }
    }
}
