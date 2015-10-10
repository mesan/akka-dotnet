using Akka.Actor;
using Akkadotnet.Actors.Image;
using Akkadotnet.Actors.Link;
using Akkadotnet.Actors.Summary;
using Akkadotnet.Messages;

namespace Akkadotnet.Actors
{
    public class SingleUrlParserMaster : ReceiveActor
    {
        public string ImageUrl { get; private set; }
        public string SummaryText { get; private set; }

        public SingleUrlParserMaster()
        {
            Receive<UrlStringWithIdMessage>(msg => ParseUrl(msg.Url, msg.Id));
        }

        private void ParseUrl(string url, int id)
        {
            Context.ActorOf<ImageUrlFinder>().Tell(new UrlStringWithIdMessage(url, id));
            Context.ActorOf<LinkFinder>().Tell(new UrlStringMessage(url));
            //Context.ActorOf<SummaryFinder>().Tell(new UrlStringMessage(url));
            Become(Collecting);
        }

        private void Collecting()
        {
            Receive<UrlStringMessage>(msg => SetImageUrl(msg.Contents));
            Receive<SummaryTextMessage>(msg => SetSummaryText(msg.Contents));
        }

        private void SetSummaryText(string summaryText)
        {
            if (string.IsNullOrEmpty(SummaryText))
            {
                SummaryText = summaryText;
                Console.WriteLine();
                Console.WriteLine(SummaryText);
                Console.WriteLine();
            }
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
