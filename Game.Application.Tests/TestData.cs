using Game.Domain.Model;

namespace Game.Application.Tests;

public class TestData
{
    public static IDictionary<ChoiceNameEnum, Choice> Choices => new Dictionary<ChoiceNameEnum, Choice>()
    {
        [ChoiceNameEnum.Paper] = new Choice((int)ChoiceNameEnum.Paper, ChoiceNameEnum.Paper.ToString()),
        [ChoiceNameEnum.Rock] = new Choice((int)ChoiceNameEnum.Rock, ChoiceNameEnum.Rock.ToString()),
        [ChoiceNameEnum.Scissors] = new Choice((int)ChoiceNameEnum.Scissors, ChoiceNameEnum.Scissors.ToString()),
        [ChoiceNameEnum.Lizard] = new Choice((int)ChoiceNameEnum.Lizard, ChoiceNameEnum.Lizard.ToString()),
        [ChoiceNameEnum.Spock] = new Choice((int)ChoiceNameEnum.Spock, ChoiceNameEnum.Spock.ToString())
    };
    
    public static IReadOnlyCollection<GameRule> Rules =
    [
        new GameRule(Choice.CreateFrom(ChoiceNameEnum.Paper), Choice.CreateFrom(ChoiceNameEnum.Rock)),
        new GameRule(Choice.CreateFrom(ChoiceNameEnum.Paper), Choice.CreateFrom(ChoiceNameEnum.Spock)),
        new GameRule(Choice.CreateFrom(ChoiceNameEnum.Rock), Choice.CreateFrom(ChoiceNameEnum.Scissors)),
        new GameRule(Choice.CreateFrom(ChoiceNameEnum.Rock), Choice.CreateFrom(ChoiceNameEnum.Lizard)),
        new GameRule(Choice.CreateFrom(ChoiceNameEnum.Scissors), Choice.CreateFrom(ChoiceNameEnum.Paper)),
        new GameRule(Choice.CreateFrom(ChoiceNameEnum.Scissors), Choice.CreateFrom(ChoiceNameEnum.Lizard)),
        new GameRule(Choice.CreateFrom(ChoiceNameEnum.Lizard), Choice.CreateFrom(ChoiceNameEnum.Spock)),
        new GameRule(Choice.CreateFrom(ChoiceNameEnum.Lizard), Choice.CreateFrom(ChoiceNameEnum.Paper)),
        new GameRule(Choice.CreateFrom(ChoiceNameEnum.Spock), Choice.CreateFrom(ChoiceNameEnum.Scissors)),
        new GameRule(Choice.CreateFrom(ChoiceNameEnum.Spock), Choice.CreateFrom(ChoiceNameEnum.Rock))
    ];
}