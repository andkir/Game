using Game.Domain.Model;

namespace Game.Infrastructure.Repositories;

public static class ChoicesStore
{
    public static IDictionary<ChoiceNameEnum, Choice> Choices => new Dictionary<ChoiceNameEnum, Choice>()
    {
        [ChoiceNameEnum.Paper] = new Choice((int)ChoiceNameEnum.Paper, ChoiceNameEnum.Paper.ToString()),
        [ChoiceNameEnum.Rock] = new Choice((int)ChoiceNameEnum.Rock, ChoiceNameEnum.Rock.ToString()),
        [ChoiceNameEnum.Scissors] = new Choice((int)ChoiceNameEnum.Scissors, ChoiceNameEnum.Scissors.ToString()),
        [ChoiceNameEnum.Lizard] = new Choice((int)ChoiceNameEnum.Lizard, ChoiceNameEnum.Lizard.ToString()),
        [ChoiceNameEnum.Spock] = new Choice((int)ChoiceNameEnum.Spock, ChoiceNameEnum.Spock.ToString())
    };
}
