using System;
using Akka.Actor;
using Akkadotnet.Actors.Header;
using Akkadotnet.Actors.Image;
using Akkadotnet.Actors.Link;
using Akkadotnet.Actors.Summary;
using Akkadotnet.Messages;
using Akkadotnet.Messages.Header;
using Akkadotnet.Messages.Summary;

namespace Akkadotnet.Actors
{
    public class SingleUrlParserMaster : ReceiveActor
    {
        public string ImageUrl { get; private set; }
        public string SummaryText { get; private set; }
        public string HeaderText { get; private set; }
        public string WikipediaUrl { get; private set; }

        private ActorSelection _outputActor;
        public SingleUrlParserMaster()
        {
            Receive<UrlStringWithIdMessage>(msg => ParseUrl(msg.Url, msg.Id));
        }

        private void ParseUrl(string url, int id)
        {
            _outputActor = Context.ActorSelection("/user/Master/Output");
            WikipediaUrl = url;
            Context.ActorOf<ImageUrlFinder>().Tell(new UrlStringWithIdMessage(url, id));
            Context.ActorOf<LinkFinder>().Tell(new UrlStringMessage(url));
            Context.ActorOf<SummaryFinder>().Tell(new UrlStringMessage(url));
            Context.ActorOf<HeaderFinder>().Tell(new UrlStringMessage(url));
            Become(Collecting);
        }

        private void Collecting()
        {
            Receive<UrlStringMessage>(msg => SetImageUrl(msg.Contents));
            Receive<SummaryTextMessage>(msg => SetSummaryText(msg.Contents));
            Receive<HeaderTextMessage>(msg => SetHeaderText(msg.Contents));
        }

        private void SetHeaderText(string headerText)
        {
            if (string.IsNullOrEmpty(HeaderText))
            {
                HeaderText = headerText;
                Completed();
            }
        }

        private void SetSummaryText(string summaryText)
        {
            if (string.IsNullOrEmpty(SummaryText))
            {
                SummaryText = summaryText;
                Completed();
            }
        }

        private void SetImageUrl(string imageUrl)
        {
            if (string.IsNullOrEmpty(ImageUrl))
            {
                ImageUrl = imageUrl;
                Completed();
            }
        }

        private void Completed()
        {
            if (!string.IsNullOrEmpty(ImageUrl) 
                && !string.IsNullOrEmpty(SummaryText) 
                && !string.IsNullOrEmpty(HeaderText))
            {
                _outputActor.Tell(new CompleteWikipediaArticleMessage(HeaderText, SummaryText, ImageUrl, WikipediaUrl));
                Self.Tell(PoisonPill.Instance);
            }
        }
    }
}
