namespace Akkadotnet.Messages.Image
{
    public class FindImageUrls : ActorMessage<string>
    {
        public FindImageUrls(string url) 
            : base(url)
        {
        }
    }
}
