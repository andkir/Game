using Game.Application.Repositories;
using Game.Domain.Model;

namespace Game.Infrastructure.Repositories;

internal class GameRuleRepository : IGameRuleRepository
{
    private readonly IDictionary<ChoiceNameEnum, Choice> _choices = ChoicesStore.Choices;

    public IReadOnlyCollection<GameRule> GetGameRules()
    {
        return [
                    new GameRule(_choices[ChoiceNameEnum.Paper], _choices[ChoiceNameEnum.Rock]),
            new GameRule(_choices[ChoiceNameEnum.Paper], _choices[ChoiceNameEnum.Spock]),
            new GameRule(_choices[ChoiceNameEnum.Rock], _choices[ChoiceNameEnum.Scissors]),
            new GameRule(_choices[ChoiceNameEnum.Rock], _choices[ChoiceNameEnum.Lizard]),
            new GameRule(_choices[ChoiceNameEnum.Scissors], _choices[ChoiceNameEnum.Paper]),
            new GameRule(_choices[ChoiceNameEnum.Scissors], _choices[ChoiceNameEnum.Lizard]),
            new GameRule(_choices[ChoiceNameEnum.Lizard], _choices[ChoiceNameEnum.Paper]),
            new GameRule(_choices[ChoiceNameEnum.Lizard], _choices[ChoiceNameEnum.Spock]),
            new GameRule(_choices[ChoiceNameEnum.Spock], _choices[ChoiceNameEnum.Rock]),
            new GameRule(_choices[ChoiceNameEnum.Spock], _choices[ChoiceNameEnum.Scissors])
                ];
    }
}
