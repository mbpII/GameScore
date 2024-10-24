using System;
public class Program
{
    public static void Main(string[] args)
    {
        GameScoreCalculator gameScoreCalc = new GameScoreCalculator();

        var(pointSpread, overUnder) = gameScoreCalc.GetData();

        double gameScore = gameScoreCalc.GameScore(pointSpread, overUnder);
        Console.WriteLine($"Game Quality Score is: {gameScore:F2}");
    }
}

