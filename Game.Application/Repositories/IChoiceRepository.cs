using Game.Domain.Model;

namespace Game.Application.Repositories;

/// <summary>
/// Represents a repository of choices.
/// We could store then in DB but for simplicity I store them in memory
/// </summary>
public interface IChoiceRepository
{
    IReadOnlyCollection<Choice> GetChoices();
    Choice GetChoiceById(int choiceId);
}
