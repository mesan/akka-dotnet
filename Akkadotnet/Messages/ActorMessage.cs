namespace Akkadotnet.Messages
{
    abstract public class ActorMessage<T>
    {
        protected ActorMessage(T contents)
        {
            Contents = contents;
        }

        public T Contents { get; private set; }
    }
}
