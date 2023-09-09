namespace SportsBet.Common.Settings;

public sealed class BusSettings
{
    public string Host { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string QueueNamePrefix { get; set; }
    public string HostName { get; set; }
    public string VirtualHost { get; set; }
    public bool AutoDelete { get; set; }
    public bool Durable { get; set; }
}