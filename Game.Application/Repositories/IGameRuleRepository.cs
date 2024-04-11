using Game.Domain.Model;

namespace Game.Application.Repositories;

public interface IGameRuleRepository
{
    IReadOnlyCollection<GameRule> GetGameRules();
}
