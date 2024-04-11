using Game.Domain.Model;

namespace Game.Domain.Tests;

public class TestData
{
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