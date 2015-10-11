using System;
using Akka.Actor;
using Akkadotnet.Messages;

namespace Akkadotnet.Actors
{
    public class OutputActor : ReceiveActor
    {
        public OutputActor()
        {
            Receive<CompleteWikipediaArticleMessage>(msg => OutputWikipediaArticle(msg));
        }
        private void OutputWikipediaArticle(CompleteWikipediaArticleMessage articleMessage)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\n {articleMessage.Header}\n{articleMessage.ImageUrl}\n{articleMessage.Summary}\n{articleMessage.WikipediaUrl}");
        }
    }
}
