using Akka.Actor;
using Akkadotnet.Actors;
using Akkadotnet.Actors.Header;
using Akkadotnet.Actors.Image;
using Akkadotnet.Actors.Link;
using Akkadotnet.Actors.Summary;

namespace Akkadotnet.Utility
{
    public static class ActorProps
    {
        public static Props HeaderFinderProps => Props.Create<HeaderFinder>();
        public static Props ImageFetcherProps => Props.Create<ImageFetcher>();
        public static Props ImageUrlFinderProps => Props.Create<ImageUrlFinder>();
        public static Props LinkFinderProps => Props.Create<LinkFinder>();
        public static Props LinkHandlerProps => Props.Create<LinkHandler>();
        public static Props SummaryFinderProps => Props.Create<SummaryFinder>();
        public static Props OutputActorProps => Props.Create<OutputActor>();
        public static Props SingleUrlParserMasterProps => Props.Create<SingleUrlParserMaster>();
        public static Props WikipediaParserMasterProps => Props.Create<WikipediaParserMaster>();
    }
}
