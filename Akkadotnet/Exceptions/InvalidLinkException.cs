using System;

namespace Akkadotnet.Exceptions
{
    public class InvalidLinkException : Exception
    {
        public InvalidLinkException()
        {
        }

        public InvalidLinkException(string message)
            : base(message) 
        {
            
        }
    }
}
