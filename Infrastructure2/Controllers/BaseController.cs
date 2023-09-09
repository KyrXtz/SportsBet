namespace SportsBet.Infrastructure.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public abstract class BaseApiController<T> : ControllerBase
    {
        protected IActionResult OkOrBadRequest<U>(Result<U> businessResult) => !businessResult.Succeeded ? BadRequestSerialized(businessResult)
            : Ok(businessResult.Data);
        private IActionResult BadRequestSerialized(Result businessResult) => BadRequest(businessResult.Messages);

        protected IMediatorHandler MediatorHandler;
        protected readonly ILogger<T> Logger;

        public BaseApiController(IMediatorHandler mediatorHandler, ILogger<T> logger)
        {
            MediatorHandler = mediatorHandler;
            Logger = logger;
        }
    }

}