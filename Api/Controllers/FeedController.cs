namespace BlueBrown.SportsBet.Api.Controllers;

[ApiVersion("1.0")]
public class FeedController : BaseApiController<FeedController>
{
    public FeedController(IMediatorHandler mediatorHandler, ILogger<FeedController> logger) : base(mediatorHandler,
        logger)
    {
    }

    [HttpPost, Route("FeedHandler")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [OpenApiIgnore]
    public async Task<IActionResult> FeedHandler([FromBody][ModelBinder(typeof(WebhookBinder))] Webhook? webhook,
        [FromQuery] string contentType)
    {
        if (webhook == null) return BadRequest(ModelState);

        var res = await MediatorHandler.SendCommand<Unit>(webhook, default);
        return OkOrBadRequest(res);
    }
}