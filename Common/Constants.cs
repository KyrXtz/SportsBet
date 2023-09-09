namespace SportsBet.Common;

public static class Constants
{
    public static class UnifiedProviderPrefixes
    {
        public const string SportPrefix = "sport";
        public const string CountryPrefix = "country";
        public const string LeaguePrefix = "league";
    }

    public static class Methods
    {
        public const string KeepAliveEvent = "KeepAliveEvent";
        public const string GameListEvent = "GameListEvent";
        public const string PlayerInformationEvent = "PlayerInformationEvent";
        public const string MatchEvent = "MatchEvent";
    }

    public static class ContentTypes
    {
        public const string Json = "json";
        public const string Xml = "xml";
    }
}