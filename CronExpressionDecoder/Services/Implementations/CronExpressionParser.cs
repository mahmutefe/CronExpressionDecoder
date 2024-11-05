using CronExpressionDecoder.Models;
using CronExpressionDecoder.Services.Interfaces;

namespace CronExpressionDecoder.Services.Implementations;

/// <summary>
/// Main parser implementation using Builder pattern
/// </summary>
public class CronExpressionParser : ICronExpressionParser
{
    private readonly ICronExpressionValidator validator;
    private readonly ICronFieldParser fieldParser;

    public CronExpressionParser(
        ICronExpressionValidator validator,
        ICronFieldParser fieldParser)
    {
        this.validator = validator;
        this.fieldParser = fieldParser;
    }

    public CronExpression Parse(string cronString)
    {
        validator.Validate(cronString);

        var parts = cronString.Split(' ');
        var fields = new List<CronField>
        {
            ParseField("minute", parts[0], 0, 59),
            ParseField("hour", parts[1], 0, 23),
            ParseField("day of month", parts[2], 1, 31),
            ParseField("month", parts[3], 1, 12),
            ParseField("day of week", parts[4], 1, 7)
        };

        return new CronExpression(fields, parts[5]);
    }

    private CronField ParseField(string name, string expression, int min, int max)
    {
        var field = new CronField(name, min, max);
        var values = fieldParser.Parse(expression, min, max);
        field.SetValues(values);
        return field;
    }
}
