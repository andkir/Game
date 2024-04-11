using Game.Domain.Model;

namespace Game.Application.Services;

public interface IChoiceRandomizer
{
    Task<Choice> GetRandomChoiceAsync(CancellationToken cancellationToken);
}
