using System;
using Akka.Actor;
using Akkadotnet.Actors.Image;
using Akkadotnet.Actors.Link;
using Akkadotnet.Messages;
using Akkadotnet.Messages.Image;
using Akkadotnet.Messages.Link;

namespace Akkadotnet.Actors
{
    public class SingleUrlParserMaster : ReceiveActor
    {
        private IActorRef _master;

        public SingleUrlParserMaster()
        {
            Receive<WikipediaUrlParseRequest>(msg => ParseUrl(msg.Contents));
        }

        private void ParseUrl(string url)
        {
            Console.WriteLine("Parsing: {0}", url);
            //Links, image, summary
            //Context.ActorOf<ImageUrlFinder>().Tell(new FindImageUrls(url));
            Context.ActorOf<LinkFinder>().Tell(new FindLinks(url));
        }
    }
}
