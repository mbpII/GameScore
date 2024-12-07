using Microsoft.AspNetCore.Mvc;
using GameScore.Models; 

[ApiController]
[Route("api/[controller]")]
public class GameScoreController : ControllerBase
{
    [HttpPost("calculate")]
    public ActionResult<GameScoreResponse> CalculateGameScore([FromBody] GameScoreRequest request)
    {
        try
        {
            var calculator = GameScoreCalculatorFactory.CreateCalculator(request.Sport);
            
            // Default ranges for point spread and over/under
            (double min, double max) pointSpreadRange = request.Sport.ToLower() switch
            {
                "basketball" => (-50.0, 50.0),
                "football" => (-35.0, 35.0), 
                "soccer" => (-10.0, 10.0),
                _ => (-50.0, 50.0) // Default fallback
            };

            (double min, double max) overUnderRange = request.Sport.ToLower() switch
            {
                "basketball" => (160.0, 280.0),
                "football" => (30.0, 80.0),
                "soccer" => (0.5, 10.0), 
                _ => (1.0, 300.0) // Default fallback
            };

            if (request.PointSpread < pointSpreadRange.Item1 || request.PointSpread > pointSpreadRange.Item2) {
                return BadRequest($"Point spread must be between {pointSpreadRange.Item1} and {pointSpreadRange.Item2} for {request.Sport}.");
            }

            if (request.OverUnder < overUnderRange.Item1 || request.OverUnder > overUnderRange.Item2) {
                return BadRequest($"Over/Under must be between {overUnderRange.Item1} and {overUnderRange.Item2} for {request.Sport}.");
            }

            var gameQualityScore = calculator.GameScore(
                pointSpread: request.PointSpread,
                overUnder: request.OverUnder
            );

            return Ok(new GameScoreResponse
            {
                GameQualityScore = Math.Round(gameQualityScore, 2),
                Sport = request.Sport,
                PointSpread = request.PointSpread,
                OverUnder = request.OverUnder
            });
        }
        catch (ArgumentException ex)
        {
            return BadRequest($"Invalid sport: {ex.Message}");
        }
        catch (Exception ex)
        {
            return BadRequest($"Error calculating game score: {ex.Message}");
        }
    }
}