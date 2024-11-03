public class FootballScoreCalculator : GameScoreCalculator
{
    private const double DEFAULT_TEAM1_AVG = 24.5;  // Example NFL team average
    private const double DEFAULT_TEAM2_AVG = 21.8;
    private const double LEAGUE_AVG = 44.0;

    public FootballScoreCalculator() 
        : base(
            DEFAULT_TEAM1_AVG,
            DEFAULT_TEAM2_AVG,
            LEAGUE_AVG,
            scoringWeight: 0.4,
            competitivenessWeight: 0.6)
    {
    }
} 