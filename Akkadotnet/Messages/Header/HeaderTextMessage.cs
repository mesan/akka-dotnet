namespace Akkadotnet.Messages.Header
{
    public class HeaderTextMessage : ActorMessage<string>
    {
        public HeaderTextMessage(string contents) 
            : base(contents)
        {
        }
    }
}
