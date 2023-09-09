namespace SportsBet.Common.Settings;
public sealed class PartitionedQueueSettings
{
    public string QueueId { get; set; }
    public int MaxStreamLength { get; set; }
    public int PartitionCount { get; set; }

    private string leadershipPath;
    public string LeadershipPath
    {
        get
        {
            return string.Format(leadershipPath, Environment.GetEnvironmentVariable("CONSULVERSION"));
        }
        set
        {
            leadershipPath = value;
        }
    }
}