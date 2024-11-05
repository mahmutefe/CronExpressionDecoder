using CronExpressionDecoder.Services.Implementations;
using CronExpressionDecoder.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

public class Program
{
    public static void Main(string[] args)
    {
        if (args.Length != 1)
        {
            Console.WriteLine("Please provide a cron expression as a single argument.");
            return;
        }

        try
        {
            var serviceProvider = ConfigureServices();
            var parser = serviceProvider.GetRequiredService<ICronExpressionParser>();
            var cronExpression = parser.Parse(args[0]);
            Console.Write(cronExpression.FormatOutput());
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    private static ServiceProvider ConfigureServices()
    {
        var services = new ServiceCollection();
        services.AddScoped<ICronExpressionValidator, CronExpressionValidator>();
        services.AddScoped<ICronFieldParser, CronFieldParser>();
        services.AddScoped<ICronExpressionParser, CronExpressionParser>();
        return services.BuildServiceProvider();
    }
}