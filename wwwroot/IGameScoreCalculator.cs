public interface IGameScoreCalculator
{
    double GameScore(double pointSpread, double overUnder);

    (double Min, double Max) GetPointSpreadRange();
    (double Min, double Max) GetOverUnderRange();
} 
