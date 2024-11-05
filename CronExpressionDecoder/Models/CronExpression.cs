using System.Text;

namespace CronExpressionDecoder.Models;

/// <summary>
/// Represents a complete parsed cron expression
/// </summary>
public class CronExpression
{
    private readonly List<CronField> fields;
    public string Command { get; }

    public CronExpression(List<CronField> fields, string command)
    {
        this.fields = fields;
        Command = command;
    }

    public string FormatOutput()
    {
        var sb = new StringBuilder();

        foreach (var field in fields)
        {
            sb.Append(field.Name.PadRight(14));
            sb.AppendLine(string.Join(" ", field.Values));
        }

        sb.Append("command".PadRight(14));
        sb.AppendLine(Command);

        return sb.ToString();
    }
}
