using Game.Application.Repositories;
using Game.Application.Services;
using Game.Domain.Model;
using Moq;

namespace Game.Application.Tests;

public class GameManagerTests
{
    private readonly Mock<IChoiceRepository> _choiceRepositoryMock = new();
    private readonly Mock<IGameRuleRepository> _gameRuleRepositoryMock = new();
    private readonly Mock<IChoiceRandomizer> _choiceRandomizerMock = new();

    [Fact]
    public async Task PlayWithBotAsync_PlayerWin()
    {
        // Arrange
        var playerChoice = Choice.CreateFrom(ChoiceNameEnum.Paper);
        var botChoice = Choice.CreateFrom(ChoiceNameEnum.Rock);
        _choiceRepositoryMock.Setup(r => r.GetChoiceById(It.IsAny<int>())).Returns(playerChoice);
        _choiceRandomizerMock.Setup(r => r.GetRandomChoiceAsync(It.IsAny<CancellationToken>())).ReturnsAsync(botChoice);
        _gameRuleRepositoryMock.Setup(r => r.GetGameRules()).Returns(TestData.Rules);
        var gameManager = new GameManager(_choiceRepositoryMock.Object, _gameRuleRepositoryMock.Object,
            _choiceRandomizerMock.Object);

        // Act
        var result = await gameManager.PlayWithBotAsync(playerChoice.Id, CancellationToken.None);

        // Assert
        Assert.Equal(GameResultEnum.Win, result.Value);
    }

    [Fact]
    public async Task PlayWithBotAsync_PlayerLose()
    {
        // Arrange
        var playerChoice = Choice.CreateFrom(ChoiceNameEnum.Rock);
        var botChoice = Choice.CreateFrom(ChoiceNameEnum.Paper);
        _choiceRepositoryMock.Setup(r => r.GetChoiceById(It.IsAny<int>())).Returns(playerChoice);
        _choiceRandomizerMock.Setup(r => r.GetRandomChoiceAsync(It.IsAny<CancellationToken>())).ReturnsAsync(botChoice);
        _gameRuleRepositoryMock.Setup(r => r.GetGameRules()).Returns(TestData.Rules);
        var gameManager = new GameManager(_choiceRepositoryMock.Object, _gameRuleRepositoryMock.Object,
            _choiceRandomizerMock.Object);

        // Act
        var result = await gameManager.PlayWithBotAsync(playerChoice.Id, CancellationToken.None);

        // Assert
        Assert.Equal(GameResultEnum.Lose, result.Value);
    }
    
    [Fact]
    public async Task PlayWithBotAsync_ThrowsTimeout()
    {
        // Arrange
        var playerChoice = Choice.CreateFrom(ChoiceNameEnum.Rock);
        _choiceRepositoryMock.Setup(r => r.GetChoiceById(It.IsAny<int>())).Returns(playerChoice);
        _choiceRandomizerMock.Setup(r => r.GetRandomChoiceAsync(It.IsAny<CancellationToken>()))
            .Throws<TaskCanceledException>();
        
        _gameRuleRepositoryMock.Setup(r => r.GetGameRules()).Returns(TestData.Rules);
        var gameManager = new GameManager(_choiceRepositoryMock.Object, _gameRuleRepositoryMock.Object,
            _choiceRandomizerMock.Object);

        // Act
        GameResult? result = null;
        await Assert.ThrowsAsync<TaskCanceledException>(async () =>
        {
            result = await gameManager.PlayWithBotAsync(playerChoice.Id, CancellationToken.None);
        });

        // Assert
        Assert.Null(result);
    }
}