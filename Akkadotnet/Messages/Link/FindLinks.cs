using System;
using Akka.Actor;

namespace Akkadotnet.Messages.Link
{
    public class FindLinks : ActorMessage<String>
    {

        public FindLinks(string contents) 
            : base(contents)
        {
        }
    }
}
