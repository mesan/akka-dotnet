using HtmlAgilityPack;

namespace Akkadotnet.Messages.Image
{
    public class ImageHtmlNode : ActorMessage<HtmlNode>
    {
        public int Id { get; private set; }
        public ImageHtmlNode(HtmlNode contents, int id) 
            : base(contents)
        {
            Id = id;
        }
    }
}
