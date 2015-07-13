using System.Linq;
using Akka.Actor;
using Akkadotnet.Messages.Image;
using Akkadotnet.Utility;

namespace Akkadotnet.Actors.Image
{
    public class ImageUrlFinder : ReceiveActor
    {
        public ImageUrlFinder()
        {
            Receive<FindImageUrls>(msg => FindImages(msg.Contents));
        }

        private void FindImages(string url)
        {
            var imageUrls = WebScraper.Scrape(url, "img").Select(node => node.GetAttributeValue("src", string.Empty));
            foreach (var imageUrl in imageUrls)
            {
                Context.ActorOf<ImageFetcher>().Tell(new ImageUrl(imageUrl));
            }
        }
    }
}
