using CronExpressionDecoder.Services.Interfaces;
using FluentValidation;

namespace CronExpressionDecoder.Services.Implementations;

/// <summary>
/// Fluent validator for cron expressions
/// </summary>
public class CronExpressionValidator : AbstractValidator<string>, ICronExpressionValidator
{
    public CronExpressionValidator()
    {
        RuleFor(expression => expression)
            .NotEmpty().WithMessage("Cron expression cannot be empty")
            .Must(expression => expression.Split(' ').Length == 6)
            .WithMessage("Cron expression must have exactly 6 parts");
    }

    public new void Validate(string cronExpression)
    {
        var result = base.Validate(cronExpression);
        if (!result.IsValid)
        {
            throw new FluentValidation.ValidationException(result.Errors);
        }
    }
}
