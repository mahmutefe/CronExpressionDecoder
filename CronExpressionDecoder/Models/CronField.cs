namespace CronExpressionDecoder.Models;

/// <summary>
/// Represents a single field in a cron expression
/// </summary>
public class CronField
{
    public string Name { get; }
    public int MinValue { get; }
    public int MaxValue { get; }
    public List<int> Values { get; private set; }

    public CronField(string name, int minValue, int maxValue)
    {
        Name = name;
        MinValue = minValue;
        MaxValue = maxValue;
        Values = new List<int>();
    }

    public void SetValues(List<int> values)
    {
        Values = values;
    }
}
