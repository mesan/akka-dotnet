using System;
using Akka.Actor;
using Akkadotnet.Messages;
using Akkadotnet.Messages.Link;

namespace Akkadotnet.Actors.Link
{
    public class LinkHandler : ReceiveActor
    {
        public LinkHandler()
        {
            Receive<HandleLink>(msg => HandleLink(msg.Contents));
        }

        private void HandleLink(string url)
        {
            //Hvis ikke relevant URL, la actoren feile? Eller sende melding til sin parent om irrelevant link og la parent stoppe denne?

            if (url.StartsWith("/wiki") && !url.Contains(":"))
            {
                Context.ActorSelection("/user/Master").Tell(new WikipediaUrlParseRequest("http://en.wikipedia.org" + url));
            }
        }
    }
}
