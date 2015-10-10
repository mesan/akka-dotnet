using System.Net.Configuration;
using Akka.Actor;
using Akkadotnet.Exceptions;
using Akkadotnet.Messages;
using Akkadotnet.Messages.Image;
using Akkadotnet.Utility;

namespace Akkadotnet.Actors.Image
{
    public class ImageUrlFinder : ReceiveActor
    {
        public ImageUrlFinder()
        {
            Receive<SingleUrlParserMessage>(msg => FindImages(msg.Url, msg.Id));
        }

        protected override SupervisorStrategy SupervisorStrategy()
        {
            return new OneForOneStrategy(
                exception =>
                {
                    if (exception is ImageTooSmallException)
                    {
                        return Directive.Stop;
                    }
                    return Directive.Escalate;
                });
        }

        private void FindImages(string url, int id)
        {
            var imageUrls = WebScraper.Scrape(url, "img");
            foreach (var imageUrl in imageUrls)
            {
                Context.ActorOf<ImageFetcher>().Tell(new ImageHtmlNode(imageUrl, id));
            }
        }
    }
}
