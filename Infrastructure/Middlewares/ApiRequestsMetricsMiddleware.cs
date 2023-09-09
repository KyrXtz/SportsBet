namespace SportsBet.Infrastructure.Middlewares;

public sealed class ApiRequestsMetricsMiddleware
{
	private readonly IInfrastructureMetrics _metrics;
	private readonly IActionDescriptorCollectionProvider _actionDescriptorCollectionProvider;
	private readonly RequestDelegate _next;

	public ApiRequestsMetricsMiddleware(IInfrastructureMetrics metrics, RequestDelegate next, IActionDescriptorCollectionProvider actionDescriptorCollectionProvider)
	{
		_metrics = metrics;
		_next = next;
		_actionDescriptorCollectionProvider = actionDescriptorCollectionProvider;

	}
	public async Task InvokeAsync(HttpContext context)
	{
		Stopwatch sw = Stopwatch.StartNew();
		try
		{
			await _next(context);

			var route = GetRouteTemplate(context.Request.Path);
			_metrics.RecordApiRequest(context.Response.StatusCode, context.Request.Path, sw.ElapsedMilliseconds);
		}
		catch (Exception)
		{
			_metrics.RecordErroredApiRequest((int)HttpStatusCode.InternalServerError, context.Request.Path, sw.ElapsedMilliseconds);
			throw;
		}
	}
	private string GetRouteTemplate(PathString path)
	{
		foreach (var route in _actionDescriptorCollectionProvider.ActionDescriptors.Items)
		{
			if (route.AttributeRouteInfo?.Template == null)
				return "Unknown route";

			var template = TemplateParser.Parse(route.AttributeRouteInfo.Template);
			var routeValues = GetDefaults(template);
			var matcher = new TemplateMatcher(template, routeValues);

			if (matcher.TryMatch(path, routeValues))
				return route.AttributeRouteInfo.Template;
		}

		return path.ToString();
	}

	private RouteValueDictionary GetDefaults(RouteTemplate parsedTemplate)
	{
		var result = new RouteValueDictionary();
		foreach (var parameter in parsedTemplate.Parameters)
			if (parameter.DefaultValue != null)
				result.Add(parameter.Name ?? "unknown parameter", parameter.DefaultValue);

		return result;
	}
}