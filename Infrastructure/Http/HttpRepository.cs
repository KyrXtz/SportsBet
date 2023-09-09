namespace SportsBet.Infrastructure.Http
{
    internal class HttpRepository : IHttpRepository
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<HttpRepository> _logger;
        public HttpRepository(HttpClient httpClient,
            ILogger<HttpRepository> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }
        public async Task<T> GetAsync<T>(string endpoint, CancellationToken cancellationToken = default)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(endpoint))
                    throw new ArgumentException($"'{nameof(endpoint)}' cannot be null or empty.", nameof(endpoint));

                using HttpResponseMessage? response = await _httpClient.GetAsync(endpoint, HttpCompletionOption.ResponseHeadersRead, cancellationToken);

                response.EnsureSuccessStatusCode();

                var responseString = await response.Content.ReadAsStringAsync(cancellationToken);

                var returnList = JsonConvert.DeserializeObject<T>(responseString);

                _logger.LogInformation($"SportsBet http response: {responseString}");

                return returnList;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }
    }
}
