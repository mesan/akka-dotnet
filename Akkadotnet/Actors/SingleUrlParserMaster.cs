using Akka.Actor;
using Akkadotnet.Actors.Image;
using Akkadotnet.Actors.Link;
using Akkadotnet.Messages;

namespace Akkadotnet.Actors
{
    public class SingleUrlParserMaster : ReceiveActor
    {
        public string ImageUrl { get; private set; }
        private IActorRef _master;

        public SingleUrlParserMaster()
        {
            Receive<SingleUrlParserMessage>(msg => ParseUrl(msg.Url, msg.Id));
        }

        private void ParseUrl(string url, int id)
        {
            //Links, image, summary
            Context.ActorOf<ImageUrlFinder>().Tell(new SingleUrlParserMessage(url, id));
            Context.ActorOf<LinkFinder>().Tell(new UrlStringMessage(url));
            Become(Collecting);
        }

        private void Collecting()
        {
            Receive<UrlStringMessage>(msg => SetImageUrl(msg.Contents));
        }

        private void SetImageUrl(string imageUrl)
        {
            if (string.IsNullOrEmpty(ImageUrl))
            {
                ImageUrl = imageUrl;
            }
        }
    }
}
