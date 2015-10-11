using Akka.Actor;
using Akkadotnet.Messages;
using System.Collections.Generic;
using Akkadotnet.Utility;

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
            Context.ActorOf(ActorProps.OutputActorProps ,"Output");
        }

        private void ParseNewUrl(string url)
        {
            if (_visitedUrls.Count >= MaxSites)
            {
                Self.Tell(PoisonPill.Instance); //bye bye cruel world...
                return;
            }
            if (!_visitedUrls.Contains(url))
            {
               _visitedUrls.Add(url);
                var id = _visitedUrls.Count;
               Context.ActorOf(ActorProps.SingleUrlParserMasterProps ,$"SingleUrlParserMaster{id}").Tell(new UrlStringWithIdMessage(url, id));
            }
        }
    }
}
