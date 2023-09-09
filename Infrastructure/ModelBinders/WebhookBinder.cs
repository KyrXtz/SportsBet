namespace SportsBet.Infrastructure.ModelBinders;

public class WebhookBinder : IModelBinder
{
    private readonly IMapper _mapper;
    
    public WebhookBinder(IMapper mapper)
    {
        _mapper = mapper;
    }

    public async Task BindModelAsync(ModelBindingContext bindingContext)
    {
        var contentType = ReadRawQueryParam(bindingContext.HttpContext.Request.Query, "contentType");//bindingContext.HttpContext.Request.ContentType;

        var rawData = await ReadRawBody(bindingContext.HttpContext.Request);
        if (contentType == Constants.ContentTypes.Xml)
        {
            rawData = rawData.Replace("rb_data=", string.Empty);
            rawData = HttpUtility.UrlDecode(rawData);
        }

        var actionName = GetActionEvent(rawData);

        if (string.IsNullOrWhiteSpace(actionName))
        {
            bindingContext.Result = ModelBindingResult.Success(null);
            return;
        }

        try
        {
            var webhook = CommandFactory(actionName, contentType, rawData);
            bindingContext.Result = ModelBindingResult.Success(webhook);
        }
        catch (Exception ex)
        {
            bindingContext.ModelState.AddModelError(bindingContext.ModelName, ex.Message);
        }
    }
    
    private async Task<string> ReadRawBody(HttpRequest request)
    {
        using var streamReader = new StreamReader(request.Body);
        var requestBody = await streamReader.ReadToEndAsync();
        return requestBody;
    }

    private string ReadRawQueryParam(IQueryCollection query, string queryParam)
    {
        return query.FirstOrDefault(kv => kv.Key == queryParam).Value.ToString();
    }

    private Webhook? CommandFactory(string actionName, string? contentType, string payload)
    {
        switch (actionName)
        {
            case Constants.Methods.KeepAliveEvent:
            {
                object? keepAliveReturnedObj = contentType switch
                {
                    Constants.ContentTypes.Json => payload.FromJson<KeepAliveJsonRequest>(),
                    Constants.ContentTypes.Xml => payload.FromXml<KeepAliveXmlRequest>(),
                    _ => null
                };

                if (keepAliveReturnedObj is null) break;
                
                var keepAlivePayload = _mapper.Map<KeepAlivePayload>(keepAliveReturnedObj);
                return new KeepAliveCommand(keepAlivePayload);
            }
            case Constants.Methods.GameListEvent:
                object? gameListReturnedObj = contentType switch
                {
                    Constants.ContentTypes.Json => payload.FromJson<GameListJsonRequest>(),
                    Constants.ContentTypes.Xml => payload.FromXml<GameListXmlRequest>(),
                    _ => null
                };

                if (gameListReturnedObj is null) break;
                
                var gameListPayload = _mapper.Map<GameListPayload>(gameListReturnedObj);
                return new GameListCommand(gameListPayload);
            case Constants.Methods.PlayerInformationEvent:
                object? playerListReturnedObj = contentType switch
                {
                    Constants.ContentTypes.Json => payload.FromJson<PlayerInformationListJsonRequest>(),
                    Constants.ContentTypes.Xml => payload.FromXml<PlayerInformationListXmlRequest>(),
                    _ => null
                };

                if (playerListReturnedObj is null) break;

                var playerListPayload = _mapper.Map<PlayerInformationPayload>(playerListReturnedObj);
                return new PlayerInformationCommand(playerListPayload);
            case Constants.Methods.MatchEvent:
                object? eventListReturnedObj = contentType switch
                {
                    Constants.ContentTypes.Json => payload.FromJson<MatchEventListJsonRequest>(),
                    Constants.ContentTypes.Xml => payload.FromXml<MatchEventListXmlRequest>(),
                    _ => null
                };

                if (eventListReturnedObj is null) break;

                var eventListPayload = _mapper.Map<MatchsEventsPayload>(eventListReturnedObj);
                return new MatchsEventsCommand(eventListPayload);
        }

        return null;
    }

    private string GetActionEvent(string request)
    {
        return request.Contains("keep_alive") ? Constants.Methods.KeepAliveEvent :
            request.Contains("match_list") ? Constants.Methods.GameListEvent :
            request.Contains("event_list") ? Constants.Methods.MatchEvent :
            request.Contains("player_list") ? Constants.Methods.PlayerInformationEvent : string.Empty;
    }
}