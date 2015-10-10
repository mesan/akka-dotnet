using System;
using System.Collections.Generic;
using System.Net;
using Akka.Actor;
using Akkadotnet.Messages;

namespace Akkadotnet.Actors
{
    public class WikipediaParserMaster : ReceiveActor
    {
        private readonly HashSet<string> _visitedUrls;
        private const int MaxSites = 100;

        public WikipediaParserMaster()
        {
            _visitedUrls = new HashSet<string>();
            Receive<UrlStringMessage>(msg => ParseNewUrl(msg.Contents));
        }

        private void ParseNewUrl(string url)
        {
            if (_visitedUrls.Count >= MaxSites)
            {
                //noe spennende som skal skje her? Drepe actoren?
                return;
            }
            if (!_visitedUrls.Contains(url))
            {
               _visitedUrls.Add(url);
                var id = _visitedUrls.Count;
               Context.ActorOf<SingleUrlParserMaster>($"SingleUrlParserMaster{id}").Tell(new UrlStringWithIdMessage(url, id));
            }
        }
    }
}
