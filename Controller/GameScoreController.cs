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
            // TODO: Make these dynamic based on sport
            var pointSpreadRange = (-50.0, 50.0); // Most sports rarely exceed this range
            var overUnderRange = (1.0, 300.0); // Wide range to accommodate different sports

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
                GameQualityScore = gameQualityScore,
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