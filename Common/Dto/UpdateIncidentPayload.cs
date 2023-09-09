namespace SportsBet.Common.Dto;

public record UpdateIncidentPayload(string Phase, string SysName, int PlayerId, int AchievementId, decimal? Statistic);