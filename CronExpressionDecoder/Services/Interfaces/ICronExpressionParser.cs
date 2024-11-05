using CronExpressionDecoder.Models;

namespace CronExpressionDecoder.Services.Interfaces;

/// <summary>
/// Interface for parsing complete cron expressions
/// </summary>
public interface ICronExpressionParser
{
    CronExpression Parse(string cronString);
}
