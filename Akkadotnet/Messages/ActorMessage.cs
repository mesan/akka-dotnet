namespace Akkadotnet.Messages
{
    public class ActorMessage<T>
    {
        public ActorMessage(T contents)
        {
            Contents = contents;
        }

        public T Contents { get; private set; }
    }
}
