namespace CronExpressionDecoder.Services.Interfaces;

/// <summary>
/// Interface for cron expression validation
/// </summary>
public interface ICronExpressionValidator
{
    void Validate(string cronExpression);
}
