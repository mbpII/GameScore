namespace GameScore.Models;

public class GameScoreResponse
{
    public double GameQualityScore { get; set; }
    public string Sport { get; set; } = string.Empty;
    public double PointSpread { get; set; }
    public double OverUnder { get; set; }
    public DateTime CalculatedAt { get; set; } = DateTime.UtcNow;
} 