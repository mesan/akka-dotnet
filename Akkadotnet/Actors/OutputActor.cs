using Akka.Actor;
using Akkadotnet.Messages;
using System;

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
            var oldColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\n {articleMessage.Header}\n{articleMessage.ImageUrl}\n{articleMessage.Summary}\n{articleMessage.WikipediaUrl}");
            Console.ForegroundColor = oldColor;
        }
    }
}
