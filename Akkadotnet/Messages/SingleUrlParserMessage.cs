namespace Akkadotnet.Messages
{
    public class SingleUrlParserMessage
    {
        public string Url { get; private set; } 
        public int Id { get; private set; } 
        public SingleUrlParserMessage(string url, int id)
        {
            Url = url;
            Id = id;
        }
    }
}
