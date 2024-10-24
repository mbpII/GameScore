public class GameScoreCalculator
{
  private double pointSpread;
  private double overUnder;
  private double min = 190;  // Example default min
  private double max = 240;  // Example default max
  private double alpha = 0.4;  // Example default weight
  private double beta = 0.6;   // Example default weight


  private double CompScore(double pointSpread)
  {
    return 1 / (Math.Abs(pointSpread) + 1);
  }

  private double NormPS(double overUnder, double max, double min)
  {
    return (overUnder - min) / (max - min);
  }

  public double GameScore(double pointSpread, double overUnder)
  {
    double compScore = CompScore(pointSpread);
    double normPS = NormPS(overUnder, min, max);
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
