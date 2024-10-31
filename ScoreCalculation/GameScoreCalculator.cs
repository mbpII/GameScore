public class GameScoreCalculator
{
  protected double pointSpread;
  protected double overUnder;


    private static int team1Avg = 124; //hardcoded test value for team averages

    private static int team2Avg = 116; //hardcoded test value for team averages
  protected double teamAvg = team1Avg + team2Avg;  // Example default max
  private double leagueAvg = 240;  // Example default max

  private double alpha = 0.3;  // Scoring weight
  private double beta = 0.7;   // Competetativeness weight


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
