namespace Akkadotnet.Messages
{
    public class UrlStringMessage : ActorMessage<string>
    {
        public UrlStringMessage(string contents) 
            : base(contents)
        {
        }
    }
}
