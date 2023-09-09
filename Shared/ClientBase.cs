namespace SportsBet.Shared;

public abstract class SportsBetClientBase
{
    public Func<Task<string>>? RetrieveAuthorizationToken { get; set; }
    protected async Task<HttpRequestMessage> CreateHttpRequestMessageAsync(CancellationToken cancellationToken)
    {
        var msg = new HttpRequestMessage();

        if (RetrieveAuthorizationToken != null)
        {
            var token = await RetrieveAuthorizationToken();
            msg.Headers.Authorization = new global::System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
        }
        return msg;
    }

    protected void UpdateJsonSerializerSettings(JsonSerializerSettings settings)
    {
        settings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        settings.DateTimeZoneHandling = DateTimeZoneHandling.Local;
        settings.TypeNameHandling = TypeNameHandling.Objects;
        settings.SerializationBinder = new DotNetCompatibleSerializationBinder();
    }
}
internal sealed class DotNetCompatibleSerializationBinder : DefaultSerializationBinder
{
    private const string CoreLibAssembly = "System.Private.CoreLib";
    private const string MscorlibAssembly = "mscorlib";

    public override Type BindToType(string assemblyName, string typeName)
    {
        if (assemblyName == CoreLibAssembly)
        {
            assemblyName = MscorlibAssembly;
            typeName = typeName.Replace(CoreLibAssembly, MscorlibAssembly);
        }

        return base.BindToType(assemblyName, typeName);
    }
}