using System;
using Akka.Actor;
using Akkadotnet.Actors.Image;
using Akkadotnet.Actors.Link;
using Akkadotnet.Messages;
using Akkadotnet.Messages.Image;

namespace Akkadotnet.Actors
{
    public class SingleUrlParserMaster : ReceiveActor
    {
        private IActorRef _master;

        public SingleUrlParserMaster()
        {
            Receive<UrlStringMessage>(msg => ParseUrl(msg.Contents));
        }

        private void ParseUrl(string url)
        {
            Console.WriteLine("Parsing: {0}", url);
            //Links, image, summary
            Context.ActorOf<ImageUrlFinder>().Tell(new UrlStringMessage(url));
            Context.ActorOf<LinkFinder>().Tell(new UrlStringMessage(url));
        }
    }
}
