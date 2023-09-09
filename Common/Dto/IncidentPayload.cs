namespace SportsBet.Common.Dto
{
	public record IncidentPayload(string Phase, string SysName, decimal Minute, int TeamId, int? PlayerId, decimal? Statistic);
}