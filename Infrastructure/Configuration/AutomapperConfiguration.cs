using Match = SportsBet.Application.Commands.GameList.Match;
using SeriesList = SportsBet.Application.Commands.GameList.SeriesList;
using SeriesListMatch = SportsBet.Application.Commands.GameList.SeriesListMatch;

namespace SportsBet.Infrastructure.Configuration;

class GloblMappingConfiguration : Profile
{
    public GloblMappingConfiguration()
    {
        CreateMap<long, DateTime>().ConvertUsing(new UnixTimeToDateTimeTypeConverter());
        CreateMap<string, DateTime>().ConvertUsing(new ToDateTimeTypeConverter());
        CreateMap<string, string>().ConvertUsing(s => s ?? string.Empty);
    }
}

class KeepAliveRequestMapping : Profile
{
    public KeepAliveRequestMapping()
    {
        CreateMap<KeepAliveXmlRequest, KeepAlivePayload>()
            .ForPath(destination => destination.KeepAlive.DateGenerated,
                opts => opts.MapFrom(source => source.DateGenerated))
            .ForPath(destination => destination.KeepAlive.PusherId, opts => opts.MapFrom(source => source.PusherId));

        CreateMap<KeepAliveJsonRequest, KeepAlivePayload>();
        CreateMap<KeepAliveJson, KeepAlive>();
    }
}

class GameListRequestMapping : Profile
{
    public GameListRequestMapping()
    {
        #region XML
        CreateMap<GameListXmlRequest, GameListPayload>()
            .ForPath(destination => destination.MatchList.Matches,
                opts => opts.MapFrom(source => source.Matches))
            .ForPath(destination => destination.MatchList.DateGenerated,
                opts => opts.MapFrom(source => source.DateGenerated))
            .ForPath(destination => destination.MatchList.PusherId,
                opts => opts.MapFrom(source => source.PusherId));

        CreateMap<MatchXml, Match>();
        CreateMap<SeriesXml, SeriesList>();
        CreateMap<SeriesMatchXml, SeriesListMatch>();
        #endregion

        #region JSON
        CreateMap<GameListJsonRequest, GameListPayload>();
        CreateMap<MatchJson, Match>();
        CreateMap<MatchListJson, MatchList>();
        CreateMap<SeriesJson, SeriesList>();
        CreateMap<SeriesMatchJson, SeriesListMatch>();
        #endregion
    }
}
class PlayerInformationRequestMapping : Profile
{
    public PlayerInformationRequestMapping()
    {
        #region XML
        CreateMap<PlayerInformationListXmlRequest, PlayerInformationPayload>()
            .ForPath(destination => destination.PlayerList.Players,
                opts => opts.MapFrom(source => source.Players))
            .ForPath(destination => destination.PlayerList.DateGenerated,
                opts => opts.MapFrom(source => source.DateGenerated))
            .ForPath(destination => destination.PlayerList.PusherId,
                opts => opts.MapFrom(source => source.PusherId));

        CreateMap<PlayerInformationXml, PlayerInformation>();
        CreateMap<PlayerInformationLineupXml, PlayerInformationLineup>();
        #endregion

        #region JSON
        CreateMap<PlayerInformationListJsonRequest, PlayerInformationPayload>();
        CreateMap<PlayerInformationListJson, PlayerInformationList>();
        CreateMap<PlayerInformationJson, PlayerInformation>();
        CreateMap<PlayerInformationLineupJson, PlayerInformationLineup>();
        #endregion
    }
}
class MatchEventRequestMapping : Profile
{
    public MatchEventRequestMapping()
    {
        #region XML
        CreateMap<MatchEventListXmlRequest, MatchsEventsPayload>()
            .ForPath(destination => destination.EventList.Events,
                opts => opts.MapFrom(source => source.Events))
            .ForPath(destination => destination.EventList.DateGenerated,
                opts => opts.MapFrom(source => source.DateGenerated))
            .ForPath(destination => destination.EventList.PusherId,
                opts => opts.MapFrom(source => source.PusherId));

        CreateMap<MatchEventListItemXml, MatchEventListItem>()
            .ForMember(destination => destination.ScoreDict,
                opts => opts.ConvertUsing(new StringToDictionaryConverter<int>(), source => source.Score))
            .ForMember(destination => destination.StatisticsDict,
                opts => opts.ConvertUsing(new StringToDictionaryConverter<string>(), source => source.Statistics))
            .ForMember(destination => destination.ValueEventDataDict,
                opts => opts.ConvertUsing(new StringToDictionaryConverter<string>(), source => source.ValueEventData))
            .ForMember(destination => destination.RelatedEventsIds,
                opts => opts.ConvertUsing(new StringToListConverter<int>(), source => source.RelatedEventsIds))
            .ForMember(destination => destination.RelatedEventCodes,
                opts => opts.ConvertUsing(new StringToListConverter<string>(), source => source.RelatedEventCodes))
            .ForMember(destination => destination.ClearsEventsIds,
                opts => opts.ConvertUsing(new StringToListConverter<int>(), source => source.ClearsEventsIds))
            .ForMember(destination => destination.CancelEventCodeIds,
                opts => opts.ConvertUsing(new StringToListConverter<string>(), source => source.CancelEventCodeIds))
            .ForMember(destination => destination.CancelMinutes,
                opts => opts.ConvertUsing(new StringToListConverter<int>(), source => source.CancelMinutes))
            .ForMember(destination => destination.CancelGameTimes,
                opts => opts.ConvertUsing(new StringToListConverter<int>(), source => source.CancelGameTimes));

        CreateMap<MatchEventLineupXml, MatchEventLineupItem>();
        CreateMap<MatchEventLineupPlayerXml, MatchEventLineupPlayerItem>();
        #endregion

        #region JSON
        CreateMap<MatchEventListJsonRequest, MatchsEventsPayload>();
        CreateMap<MatchEventListJson, MatchsEventList>();
        CreateMap<MatchEventListItemJson, MatchEventListItem>()
            .ForMember(destination => destination.ScoreDict,
                opts => opts.ConvertUsing(new ListToDictionaryConverter<int>(), source => source.Score))            
            .ForMember(destination => destination.StatisticsDict,
                opts => opts.ConvertUsing(new ListToDictionaryConverter<string>(), source => source.Statistics))
            .ForMember(destination => destination.ValueEventDataDict,
                opts => opts.ConvertUsing(new StringToDictionaryConverter<string>(), source => source.ValueEventData));

        CreateMap<MatchEventLineupJson, MatchEventLineupItem>();
        CreateMap<MatchEventLineupPlayerJson, MatchEventLineupPlayerItem>();
        #endregion
    }
}

class UnixTimeToDateTimeTypeConverter : ITypeConverter<long, DateTime>
{
    public DateTime Convert(long source, DateTime destination, ResolutionContext context)
    {
        var dateTimeOffset = DateTimeOffset.FromUnixTimeMilliseconds(source);
        return dateTimeOffset.UtcDateTime;
    }
}

class ToDateTimeTypeConverter : ITypeConverter<string, DateTime>
{
    public DateTime Convert(string source, DateTime destination, ResolutionContext context)
    {
        if (string.IsNullOrWhiteSpace(source)) return DateTime.UtcNow;

        return DateTimeOffset.Parse(source).UtcDateTime;
    }
}
class ListToDictionaryConverter<TValue> : IValueConverter<List<string>, Dictionary<int, TValue>>
{
    public Dictionary<int, TValue> Convert(List<string> sourceMember, ResolutionContext context)
    {
        var dict = new Dictionary<int, TValue>();

        foreach (var item in sourceMember)
        {
            var keyValue = item.Split(new[] { '=' }, 2);
            if (keyValue.Length == 2 && int.TryParse(keyValue[0], out int key))
            {
                var converter = TypeDescriptor.GetConverter(typeof(TValue));
                if (converter != null && converter.IsValid(keyValue[1]))
                {
                    TValue value = (TValue)converter.ConvertFromString(keyValue[1]);
                    dict.Add(key, value);
                }
            }
        }

        return dict;
    }
}

class StringToDictionaryConverter<TValue> : IValueConverter<string, Dictionary<int, TValue>>
{
    public Dictionary<int, TValue> Convert(string sourceMember, ResolutionContext context)
    {
        var dict = new Dictionary<int, TValue>();

        if (sourceMember is not null)
        {
            var keyValues = sourceMember?.Split(new[] { ' ' });
            foreach (var item in keyValues)
            {
                var keyValue = item.Split(new[] { '=' }, 2);
                if (keyValue.Length == 2 && int.TryParse(keyValue[0], out int key))
                {
                    var converter = TypeDescriptor.GetConverter(typeof(TValue));
                    if (converter != null && converter.IsValid(keyValue[1]))
                    {
                        TValue value = (TValue)converter.ConvertFromString(keyValue[1]);
                        dict.Add(key, value);
                    }
                }
            }
        }

        return dict;
    }
}

class StringToListConverter<TValue> : IValueConverter<string, List<TValue>>
{
    public List<TValue> Convert(string sourceMember, ResolutionContext context)
    {
        var list = new List<TValue>();

        if (sourceMember is not null)
        {
            var listItems = sourceMember?.Split(new[] { ' ' });
            foreach (var item in listItems)
            {
                var converter = TypeDescriptor.GetConverter(typeof(TValue));
                if (converter != null && converter.IsValid(item))
                {
                    TValue value = (TValue)converter.ConvertFromString(item);
                    list.Add(value);
                }
            }
        }

        return list;
    }
}