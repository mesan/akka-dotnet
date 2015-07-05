namespace Akkadotnet.Messages
{
    public class FindImageUrls : ActorMessage<string>
    {
        public FindImageUrls(string url) 
            : base(url)
        {
        }
    }
}
