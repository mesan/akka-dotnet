namespace Akkadotnet.Messages.Image
{
    public class ImageUrl : ActorMessage<string>
    {
        public ImageUrl(string contents) 
            : base(contents)
        {
        }
    }
}
