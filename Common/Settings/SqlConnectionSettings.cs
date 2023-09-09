namespace SportsBet.Common.Settings;
public sealed class SqlConnectionSettings
{
    public string Username { get; set; }
    public string Password { get; set; }
    public string DataSource { get; set; }
    public string InitialCatalog { get; set; }
    public string ConnectionString { get; set; }
}