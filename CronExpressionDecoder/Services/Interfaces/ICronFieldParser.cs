namespace CronExpressionDecoder.Services.Interfaces;

/// <summary>
/// Interface for parsing individual cron fields
/// </summary>
public interface ICronFieldParser
{
    List<int> Parse(string expression, int min, int max);
}
