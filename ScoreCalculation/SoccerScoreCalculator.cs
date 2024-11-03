using System;

public class SoccerScoreCalculator : GameScoreCalculator
{
    private const double DEFAULT_TEAM1_AVG = 1.8;  // Example soccer team average
    private const double DEFAULT_TEAM2_AVG = 1.5;
    private const double LEAGUE_AVG = 2.7;

    public SoccerScoreCalculator() 
        : base(
            DEFAULT_TEAM1_AVG,
            DEFAULT_TEAM2_AVG,
            LEAGUE_AVG,
            scoringWeight: 0.3,
            competitivenessWeight: 0.7)
    {
    }
}

