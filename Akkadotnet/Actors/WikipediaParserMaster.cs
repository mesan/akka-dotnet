using System.Collections.Generic;
using Akka.Actor;
using Akkadotnet.Messages;

namespace Akkadotnet.Actors
{
    public class WikipediaParserMaster : ReceiveActor
    {
        private readonly HashSet<string> _visitedUrls;
        public WikipediaParserMaster()
        {
            _visitedUrls = new HashSet<string>();
            Receive<WikipediaUrlParseRequest>(msg => ParseNewUrl(msg.Contents));
        }

        private void ParseNewUrl(string url)
        {
            if (!_visitedUrls.Contains(url))
            {
               _visitedUrls.Add(url);
               Context.ActorOf<SingleUrlParserMaster>().Tell(new WikipediaUrlParseRequest(url));
            }
        }
    }
}
