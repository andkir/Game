using Game.Application.Services;
using Game.Domain.Model;
using System.Net.Http.Json;
using Game.Infrastructure.ExternalServices.Model;
using Game.Application.Repositories;

namespace Game.Infrastructure.ExternalServices;

public class ChoiceRandomizerService(HttpClient _httpClient, IChoiceRepository _choiceRepository) : IChoiceRandomizer
{
    public async Task<Choice> GetRandomChoiceAsync(CancellationToken cancellationToken)
    {
        var result = await _httpClient.GetFromJsonAsync<RandomNumberResult>(string.Empty, cancellationToken);

        if (result is null)
        {
            throw new UnexpectedResultException("Unknown response from the RandomizerService");
        }

        var allChoices = _choiceRepository.GetChoices();
        var choiceId = result.Random % allChoices.Count + 1;

        var randomChoice = Choice.CreateFrom((ChoiceNameEnum)choiceId);

        return randomChoice;
    }
}
