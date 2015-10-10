namespace Akkadotnet.Messages
{
    public class SummaryTextMessage : ActorMessage<string>
    {
        public SummaryTextMessage(string contents) 
            : base(contents)
        {
        }
    }
}
