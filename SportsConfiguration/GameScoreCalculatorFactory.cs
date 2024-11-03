using System;

public static class GameScoreCalculatorFactor
{    public static GameScoreCalculator CreateCalculator(string sport)
    {
        return sport.ToLower() switch
        {
            "basketball" => new BasketballScoreCalculator(),
            "football" => new FootballScoreCalculator(),
            "soccer" => new SoccerScoreCalculator(),
            _ => throw new ArgumentException($"Unsupported sport: {sport}")
        };
    }
} 