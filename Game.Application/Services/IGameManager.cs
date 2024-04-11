using Game.Domain.Model;

namespace Game.Application.Services;

public interface IGameManager
{
    Task<GameResult> PlayWithBotAsync(int playerChoiceId, CancellationToken cancellationToken);

    Task<Choice> GetRandomChoiceAsync(CancellationToken cancellationToken);

    IReadOnlyCollection<Choice> GetChoices();
}