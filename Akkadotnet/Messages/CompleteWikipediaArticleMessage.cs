namespace Akkadotnet.Messages
{
    public class CompleteWikipediaArticleMessage
    {
        public string Header { get; private set; }
        public string Summary { get; private set; }
        public string ImageUrl { get; private set; }
        public string WikipediaUrl { get; private set; }
        public CompleteWikipediaArticleMessage(string header, string summary, string imageUrl, string wikipediaUrl)
        {
            Header = header;
            Summary = summary;
            ImageUrl = imageUrl;
            WikipediaUrl = wikipediaUrl;
        }
    }
}
