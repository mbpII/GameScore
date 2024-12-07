public class BasketballScoreCalculator : GameScoreCalculator
{
    private const double DEFAULT_TEAM1_AVG = 110.5;
    private const double DEFAULT_TEAM2_AVG = 108.2;
    private const double LEAGUE_AVG = DEFAULT_TEAM1_AVG + DEFAULT_TEAM2_AVG;

    public BasketballScoreCalculator() 
        : base( 
            DEFAULT_TEAM1_AVG,
            DEFAULT_TEAM2_AVG,
            LEAGUE_AVG,
            scoringWeight: 0.312,
            competitivenessWeight: 0.688)
    {
    }

} 
