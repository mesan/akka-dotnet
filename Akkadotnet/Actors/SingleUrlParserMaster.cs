using Akka.Actor;
using Akkadotnet.Actors.Image;
using Akkadotnet.Messages;

namespace Akkadotnet.Actors
{
    public class SingleUrlParserMaster : ReceiveActor
    {
        public SingleUrlParserMaster()
        {
            Receive<WikipediaUrlParseRequest>(msg => ParseUrl(msg.Contents));
        }

        private void ParseUrl(string url)
        {
            //Links, image, summary
            Context.ActorOf<ImageUrlFinder>().Tell(new FindImageUrls(url));
        }
    }
}
