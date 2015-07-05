namespace Akkadotnet.Messages
{
    public class ImageUrl : ActorMessage<string>
    {
        public ImageUrl(string contents) 
            : base(contents)
        {
        }
    }
}
