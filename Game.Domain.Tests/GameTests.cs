using Game.Domain.Exceptions;
using Game.Domain.Model;

namespace Game.Domain.Tests;

public class GameTests
{
    [Theory]
    [InlineData(ChoiceNameEnum.Paper, ChoiceNameEnum.Paper)]
    [InlineData(ChoiceNameEnum.Rock, ChoiceNameEnum.Rock)]
    [InlineData(ChoiceNameEnum.Scissors, ChoiceNameEnum.Scissors)]
    [InlineData(ChoiceNameEnum.Lizard, ChoiceNameEnum.Lizard)]
    [InlineData(ChoiceNameEnum.Spock, ChoiceNameEnum.Spock)]
    public void PlayRound_Tie(ChoiceNameEnum playerChoiceEnum, ChoiceNameEnum botChoiceEnum)
    {
        // Arrange
        var game = new Domain.Model.Game(TestData.Rules);
        
        var playerChoice =Choice.CreateFrom(playerChoiceEnum);
        var botChoice =Choice.CreateFrom(botChoiceEnum);

        // Act
        var result = game.PlayRound(playerChoice, botChoice);

        // Assert
        Assert.Equal(GameResultEnum.Tie, result.Value);
    }
    
    [Theory]
    [InlineData(ChoiceNameEnum.Paper, ChoiceNameEnum.Rock)]
    [InlineData(ChoiceNameEnum.Rock, ChoiceNameEnum.Lizard)]
    [InlineData(ChoiceNameEnum.Scissors, ChoiceNameEnum.Paper)]
    [InlineData(ChoiceNameEnum.Lizard, ChoiceNameEnum.Spock)]
    [InlineData(ChoiceNameEnum.Spock, ChoiceNameEnum.Rock)]
    public void PlayRound_PlayerWin(ChoiceNameEnum playerChoiceEnum, ChoiceNameEnum botChoiceEnum)
    {
        // Arrange
        var game = new Domain.Model.Game(TestData.Rules);
        var playerChoice = Choice.CreateFrom(playerChoiceEnum);
        var botChoice = Choice.CreateFrom(botChoiceEnum);

        // Act
        var result = game.PlayRound(playerChoice, botChoice);

        // Assert
        Assert.Equal(GameResultEnum.Win, result.Value);
    }
    
    [Theory]
    [InlineData(ChoiceNameEnum.Paper, ChoiceNameEnum.Scissors)]
    [InlineData(ChoiceNameEnum.Rock, ChoiceNameEnum.Paper)]
    [InlineData(ChoiceNameEnum.Scissors, ChoiceNameEnum.Rock)]
    [InlineData(ChoiceNameEnum.Lizard, ChoiceNameEnum.Scissors)]
    [InlineData(ChoiceNameEnum.Spock, ChoiceNameEnum.Paper)]
    public void PlayRound_PlayerLose(ChoiceNameEnum playerChoiceEnum, ChoiceNameEnum botChoiceEnum)
    {
        // Arrange
        var rules = TestData.Rules;
        var game = new Domain.Model.Game(rules);
        var playerChoice = Choice.CreateFrom(playerChoiceEnum);
        var botChoice = Choice.CreateFrom(botChoiceEnum);

        // Act
        var result = game.PlayRound(playerChoice, botChoice);

        // Assert
        Assert.Equal(GameResultEnum.Lose, result.Value);
    }
    
    
    [Fact]
    public void PlayRound_InvalidChoiceId_ThrowsException()
    {
        // Arrange
        var game = new Domain.Model.Game(TestData.Rules);
        var invalidChoice = Choice.CreateFrom(ChoiceNameEnum.Paper); 

        // Act & Assert
        Assert.Throws<InvalidChoiceException>(() => game.PlayRound(new Choice(9, "Invalid"), invalidChoice));
    }
}