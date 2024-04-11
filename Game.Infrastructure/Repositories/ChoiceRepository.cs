using Game.Application.Repositories;
using Game.Domain.Exceptions;
using Game.Domain.Model;
using System.Collections.Immutable;

namespace Game.Infrastructure.Repositories;

public class ChoiceRepository : IChoiceRepository
{
    public IReadOnlyCollection<Choice> GetChoices()
    {
        return ChoicesStore.Choices.Values.ToImmutableList();
    }

    public Choice GetChoiceById(int choiceId)
    {
        if (ChoicesStore.Choices.TryGetValue((ChoiceNameEnum)choiceId, out var choice))
        {
            return choice;
        }

        throw new InvalidChoiceException($"Unknown Choice Id has been passed as parameter: {choiceId}");
    }
}
