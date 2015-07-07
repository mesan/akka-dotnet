using System;
using Akka.Actor;
using Akkadotnet.Messages;

namespace Akkadotnet.Actors
{
    public class ImageFetcher : ReceiveActor
    {
        public ImageFetcher()
        {
            Receive<ImageUrl>(msg => FetchImage(msg.Contents));
        }

        private void FetchImage(string url)
        {
            Console.WriteLine("I am going to fetch image with url {0}", url);
        }
    }
}
