namespace Game.Domain.Model;

public class Game
{
    public Game(IReadOnlyCollection<GameRule> rules)
    {
        Rules = rules;
    }
    
    public IReadOnlyCollection<GameRule> Rules { get; }

    public GameResult PlayRound(Choice playerChoice, Choice botChoice)
    {
        if (playerChoice == botChoice)
        {
            return new GameResult(GameResultEnum.Tie, playerChoice.Id, botChoice.Id);
        }

        var successfulGameRule = Rules.SingleOrDefault(x => x.Winner == playerChoice && x.Loser == botChoice);

        if (successfulGameRule != null)
        {
            return new GameResult(GameResultEnum.Win, playerChoice.Id, botChoice.Id);
        }

        return new GameResult(GameResultEnum.Lose, playerChoice.Id, botChoice.Id);
    }
}
