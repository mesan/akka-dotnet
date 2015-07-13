using System;

namespace Akkadotnet.Messages.Link
{
    class HandleLink : ActorMessage<String>
    {
        public HandleLink(string contents) 
            : base(contents)
        {
        }
    }
}
