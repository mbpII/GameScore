public abstract class GameScoreCalculator
{
    protected double team1Avg;
    protected double team2Avg;
    protected double teamAvg;
    protected double leagueAvg;
    protected double alpha;
    protected double beta;

    protected GameScoreCalculator(
        double team1Average,
        double team2Average,
        double leagueAverage,
        double scoringWeight = 0.3,
        double competitivenessWeight = 0.7)
    {
        team1Avg = team1Average;
        team2Avg = team2Average;
        teamAvg = team1Avg + team2Avg;
        leagueAvg = leagueAverage;
        alpha = scoringWeight;
        beta = competitivenessWeight;
    }

    private double CompScore(double pointSpread)
    {
        return 1 / (Math.Abs(pointSpread) + 1);
    }

    private double NormPS(double overUnder, double teamAvg, double leagueAvg)
    {
        double normalizedScore = teamAvg / 2 /leagueAvg * (overUnder/leagueAvg*2);
        return Math.Max(0, Math.Min(100, normalizedScore));
    }

    public double GameScore(double pointSpread, double overUnder)
    {
        double compScore = CompScore(pointSpread);
        double normPS = NormPS(overUnder, teamAvg, leagueAvg);
        return (alpha * compScore) + (beta * normPS);
    }

    public (double, double) GetData()
    {
        Console.WriteLine("Enter Point Spread");
        double pointSpread = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Enter Over/Under:");
        double overUnder = Convert.ToDouble(Console.ReadLine());
        return (pointSpread, overUnder);
    }
} 
