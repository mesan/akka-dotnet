namespace Akkadotnet.Messages.Summary
{
    public class SummaryTextMessage : ActorMessage<string>
    {
        public SummaryTextMessage(string contents) 
            : base(contents)
        {
        }
    }
}
