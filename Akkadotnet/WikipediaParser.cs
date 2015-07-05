using System;
using Akka.Actor;
using Akkadotnet.Actors;
using Akkadotnet.Messages;

namespace Akkadotnet
{
    public class WikipediaParser
    {
        public static void Main(string[] args)
        {
            var actorSystem = ActorSystem.Create("WikipediaParserActorSystem");
            var wikipediaParserMaster = actorSystem.ActorOf<WikipediaParserMaster>("Master");
            wikipediaParserMaster.Tell(new WikipediaUrlParseRequest("https://en.wikipedia.org/wiki/Actor_model"));
            Console.ReadKey();
        }
    }
}
