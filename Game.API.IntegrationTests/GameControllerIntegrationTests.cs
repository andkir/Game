using System.Net;
using Game.API.DTO;
using Game.Domain.Model;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;

namespace Game.API.IntegrationTests;

public class GameControllerIntegrationTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;
    private readonly HttpClient _client;

    public GameControllerIntegrationTests(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
        _client = _factory.CreateClient();
    }

    [Fact]
    public async Task PlayGameAsync_ReturnsOkResult()
    {
        // Arrange
        var playerChoiceRequest = new PlayerChoiceRequest((int)ChoiceNameEnum.Paper);

        // Act
        var response = await _client.PostAsJsonAsync("/api/game/play", playerChoiceRequest);

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        var content = await response.Content.ReadAsStringAsync();
        var gameRoundResponse = JsonConvert.DeserializeObject<GameRoundResponse>(content);
        Assert.NotNull(gameRoundResponse);
    }
}