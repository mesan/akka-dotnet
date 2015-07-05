namespace Akkadotnet.Messages
{
    public class WikipediaUrlParseRequest : ActorMessage<string>
    {
        public WikipediaUrlParseRequest(string url) 
            : base(url)
        {
        }
    }
}
