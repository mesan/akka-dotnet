﻿using Akka.Actor;
using Akkadotnet.Messages;
using Akkadotnet.Messages.Header;
using Akkadotnet.Messages.Summary;
using Akkadotnet.Utility;

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
            Context.ActorOf(ActorProps.ImageUrlFinderProps).Tell(new UrlStringWithIdMessage(url, id));
            Context.ActorOf(ActorProps.LinkFinderProps).Tell(new UrlStringMessage(url));
            Context.ActorOf(ActorProps.SummaryFinderProps).Tell(new UrlStringMessage(url));
            Context.ActorOf(ActorProps.HeaderFinderProps).Tell(new UrlStringMessage(url));
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
