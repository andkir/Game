namespace Game.Infrastructure.Configurations;

internal class RandomizerServiceSettings
{
    public const string ConfigSectionName = "RandomizerServiceSettings";
    
    public required string Url { get; init; }
    public int Timeout { get; init; }
    public int RetryCount { get; init; }
    public int RetryDelay { get; init; }
}
