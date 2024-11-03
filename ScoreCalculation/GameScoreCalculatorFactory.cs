using System;

public static class GameScoreCalculatorFactory
{
    public static GameScoreCalculator CreateCalculator(string sport)
    {
        return sport.ToLower() switch
        {
            "basketball" => new BasketballScoreCalculator(),
            "football" => new FootballScoreCalculator(),
            "soccer" => new SoccerScoreCalculator(),
            _ => throw new ArgumentException($"Sport type '{sport}' is not supported.")
        };
    }
} 