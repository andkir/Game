namespace Game.Domain.Model;

public record GameResult(GameResultEnum Value, int PlayerChoiceId, int BotChoiceId);


public enum GameResultEnum
{
    Win,
    Lose,
    Tie
}