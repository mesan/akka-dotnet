using System;
using Akka.Actor;
using Akkadotnet.Actors;
using Akkadotnet.Messages;
using Akkadotnet.Utility;

namespace Akkadotnet
{
    public class WikipediaParser
    {
        public static void Main(string[] args)
        {
            var actorSystem = ActorSystem.Create("WikipediaParserActorSystem");
            var wikipediaParserMaster = actorSystem.ActorOf(ActorProps.WikipediaParserMasterProps ,"Master");
            wikipediaParserMaster.Tell(new UrlStringMessage("https://en.wikipedia.org/wiki/horse"));
            Console.ReadKey();

            actorSystem.Shutdown();
            actorSystem.AwaitTermination();
            Console.WriteLine("Actor system shutdown");
            Console.ReadLine();
            Environment.Exit(1);
        }
    }
}
