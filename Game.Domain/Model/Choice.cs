using Game.Domain.Exceptions;

namespace Game.Domain.Model;

public class Choice
{
    public Choice(int id, string name)
    {
        if(!Enum.GetValues<ChoiceNameEnum>().Cast<int>().Contains(id))
        {
            throw new InvalidChoiceException($"Unknown Choice Id has been passed as parameter: {id}");
        }
        
        Id = id;
        Name = name;
    }

    public int Id { get; init; }

    public string Name { get; init; }

    public override bool Equals(object? obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }

        return Id == ((Choice)obj).Id;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Id);
    }

    public static bool operator ==(Choice choice1, Choice choice2)
    {
        return choice1.Equals(choice2);
    }

    public static bool operator !=(Choice choice1, Choice choice2)
    {
        return !choice1.Equals(choice2);
    }

    public static Choice CreateFrom(ChoiceNameEnum choiceName)
    {
        return new Choice((int)choiceName, choiceName.ToString());
    }
}

public enum ChoiceNameEnum
{
    Paper = 1,
    Rock,
    Scissors,
    Lizard,
    Spock
}
