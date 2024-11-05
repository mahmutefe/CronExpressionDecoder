using CronExpressionDecoder.Services.Interfaces;

namespace CronExpressionDecoder.Services.Implementations;

/// <summary>
/// Implementation of cron field parsing logic
/// </summary>
public class CronFieldParser : ICronFieldParser
{
    public List<int> Parse(string expression, int min, int max)
    {
        // Handle all values case
        if (expression == "*")
        {
            return Enumerable.Range(min, max - min + 1).ToList();
        }

        var result = new HashSet<int>();

        foreach (var part in expression.Split(','))
        {
            if (part.Contains('/'))
            {
                ParseStep(part, min, max, result);
            }
            else if (part.Contains('-'))
            {
                ParseRange(part, min, max, result);
            }
            else
            {
                ParseSingle(part, min, max, result);
            }
        }

        return result.OrderBy(x => x).ToList();
    }

    private void ParseStep(string expression, int min, int max, HashSet<int> result)
    {
        var parts = expression.Split('/');
        var start = parts[0] == "*" ? min : int.Parse(parts[0]);
        var step = int.Parse(parts[1]);

        ValidateValue(start, min, max, "Step start value");
        ValidateValue(step, 1, max - min + 1, "Step value");

        for (int i = start; i <= max; i += step)
        {
            result.Add(i);
        }
    }

    private void ParseRange(string expression, int min, int max, HashSet<int> result)
    {
        var parts = expression.Split('-');
        var start = int.Parse(parts[0]);
        var end = int.Parse(parts[1]);

        ValidateValue(start, min, max, "Range start value");
        ValidateValue(end, min, max, "Range end value");
        ValidateRange(start, end);

        for (int i = start; i <= end; i++)
        {
            result.Add(i);
        }
    }

    private void ParseSingle(string expression, int min, int max, HashSet<int> result)
    {
        var value = int.Parse(expression);
        ValidateValue(value, min, max, "Single value");
        result.Add(value);
    }

    private void ValidateValue(int value, int min, int max, string fieldName)
    {
        if (value < min || value > max)
        {
            throw new ArgumentException($"{fieldName} must be between {min} and {max}");
        }
    }

    private void ValidateRange(int start, int end)
    {
        if (start > end)
        {
            throw new ArgumentException("Range start value must be less than or equal to end value");
        }
    }
}
