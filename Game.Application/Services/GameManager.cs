using Game.Application.Repositories;
using Game.Domain.Model;

namespace Game.Application.Services;

public class GameManager(IChoiceRepository _choiceRepository, IGameRuleRepository _gameRuleRepository,
    IChoiceRandomizer _choiceRandomizer) : IGameManager
{
    public IReadOnlyCollection<Choice> GetChoices()
    {
        return _choiceRepository.GetChoices();
    }

    public Task<Choice> GetRandomChoiceAsync(CancellationToken cancellationToken)
    {
        return _choiceRandomizer.GetRandomChoiceAsync(cancellationToken);
    }

    public async Task<GameResult> PlayWithBotAsync(int playerChoiceId, CancellationToken cancellationToken)
    {
        var playerChoice = _choiceRepository.GetChoiceById(playerChoiceId);
        var botChoice = await _choiceRandomizer.GetRandomChoiceAsync(cancellationToken);
        var gameRules = _gameRuleRepository.GetGameRules();

        var gameResult = new Domain.Model.Game(gameRules).PlayRound(playerChoice, botChoice);

        return new GameResult(gameResult.Value, playerChoice.Id, botChoice.Id);
    }
}
