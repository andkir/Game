using Game.API.DTO;
using Game.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Game.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GameController(IGameManager _gameManager) : ControllerBase
{

    [HttpGet]
    [Route("choices")]
    public IActionResult Choices()
    {
        var choices = _gameManager.GetChoices();

        return Ok(choices);
    }

    [HttpGet]
    [Route("choice")]
    public async Task<IActionResult> Choice(CancellationToken cancellationToken)
    {
        var choice = await _gameManager.GetRandomChoiceAsync(cancellationToken);

        return Ok(choice);
    }

    [HttpPost]
    [Route("play")]
    public async Task<IActionResult> PlayGameAsync(PlayerChoiceRequest request, CancellationToken cancellationToken)
    {
        var gameResult = await _gameManager.PlayWithBotAsync(request.Player, cancellationToken);

        return Ok(new GameRoundResponse(gameResult.Value.ToString(), gameResult.PlayerChoiceId, gameResult.BotChoiceId));
    }
}
