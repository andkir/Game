namespace Game.Domain.Model;

public class GameRule
{
    public GameRule(Choice winner, Choice loser)
    {
        Winner = winner;
        Loser = loser;
    }

    public Choice Winner { get; private set; }
    public Choice Loser { get; private set; }
}
