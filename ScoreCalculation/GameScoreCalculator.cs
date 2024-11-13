public abstract class GameScoreCalculator
{
    protected double pointSpread;
    protected double overUnder;
    protected double alpha;
    protected double beta;
    protected double leagueAvg;
    protected double teamAvg;
    protected double team1Avg;
    protected double team2Avg;

    protected GameScoreCalculator(
        double team1Average,
        double team2Average,
        double leagueAverage,
        double scoringWeight,
        double competitivenessWeight)
    {
        team1Avg = team1Average;
        team2Avg = team2Average;
        teamAvg = team1Avg + team2Avg;
        leagueAvg = leagueAverage;
        alpha = scoringWeight;
        beta = competitivenessWeight;
    }

    protected virtual double CompScore(double pointSpread)
    {
        return 1 / (Math.Abs(pointSpread) + 1);
    }

    protected virtual double NormPS(double overUnder, double teamAvg, double leagueAvg)
    {
        double normalizedScore = teamAvg / 2 / leagueAvg * (overUnder/leagueAvg*2);
        return Math.Max(0, Math.Min(100, normalizedScore));
    }

    public virtual double GameScore(double pointSpread, double overUnder)
    {
        double compScore = CompScore(pointSpread);
        double normPS = NormPS(overUnder, teamAvg, leagueAvg);
        return (alpha * compScore) + (beta * normPS);
    }
} 
