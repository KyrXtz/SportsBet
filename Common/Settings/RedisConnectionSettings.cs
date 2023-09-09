namespace SportsBet.Common.Settings;
public sealed class RedisConnectionSettings
{
    public string DataSource { get; set; }
    public string DefaultDatabase { get; set; }
    public string Password { get; set; }
    public string ServiceName { get; set; }
    public string AllowAdmin { get; set; }

    private string connectionString;
    public string ConnectionString
    {
        get
        {
            return string.Format(connectionString, DataSource, DefaultDatabase, Password, ServiceName, AllowAdmin);
        }
        set
        {
            connectionString = value;
        }
    }
}
