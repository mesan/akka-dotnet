using System;
using Akka.Actor;
using Akkadotnet.Messages;
using Akkadotnet.Messages.Image;

namespace Akkadotnet.Actors.Image
{
    public class ImageFetcher : ReceiveActor
    {
        public ImageFetcher()
        {
        }

        private void FetchImage(string url)
        {
            Console.WriteLine("I am going to fetch image with url {0}", url);
        }
    }
}
