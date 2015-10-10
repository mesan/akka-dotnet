using System;
using Akka.Actor;
using Akkadotnet.Exceptions;
using Akkadotnet.Messages;
using Akkadotnet.Messages.Image;
using HtmlAgilityPack;

namespace Akkadotnet.Actors.Image
{
    public class ImageFetcher : ReceiveActor
    {
        private const int MinPictureHeigth = 100;
        private const int MinPictureWidth = 100;
        private const int DefaultAttributeValue = 0;

        public ImageFetcher()
        {
            Receive<ImageHtmlNode>(msg => FetchImage(msg.Contents, msg.Id));
        }

        private void FetchImage(HtmlNode htmlNode, int id)
        {
            var picHeigth = htmlNode.GetAttributeValue("height", DefaultAttributeValue);
            var picWidth = htmlNode.GetAttributeValue("width", DefaultAttributeValue);
            var src = htmlNode.GetAttributeValue("src", string.Empty);
            if (IsBigEnough(picHeigth, picWidth))
            {
                var actorRef = Context.ActorSelection($"/user/Master/SingleUrlParserMaster{id}");
                actorRef.Tell(new UrlStringMessage(src));
            }
            else
            {
                throw new ImageTooSmallException();
            }
        }

        private bool IsBigEnough(int pictureHeigth, int picturewidth)
        {
            return pictureHeigth >= MinPictureHeigth && picturewidth > MinPictureWidth;
        }
    }
}
