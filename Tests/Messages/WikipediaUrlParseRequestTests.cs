using Akkadotnet.Messages;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Messages
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TheMessageShouldKeepItsContent()
        {
            const string url = "http://www.wikipedia.com";
            var message = new UrlStringMessage(url);
            Assert.AreEqual(message.Contents, url);
        }
    }
}
