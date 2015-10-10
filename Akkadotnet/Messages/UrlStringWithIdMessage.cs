namespace Akkadotnet.Messages
{
    public class UrlStringWithIdMessage
    {
        public string Url { get; private set; } 
        public int Id { get; private set; } 
        public UrlStringWithIdMessage(string url, int id)
        {
            Url = url;
            Id = id;
        }
    }
}
