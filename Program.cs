using System;
public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter sport (basketball/football/soccer):");
        string sport = Console.ReadLine() ?? "";
        
        try 
        {
            GameScoreCalculator calculator = GameScoreCalculatorFactory.CreateCalculator(sport);
            var (pointSpread, overUnder) = calculator.GetData();
            double gameScore = calculator.GameScore(pointSpread, overUnder);
            Console.WriteLine($"Game Quality Score is: {gameScore:F2}");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}

