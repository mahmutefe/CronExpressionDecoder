using CronExpressionDecoder.Services.Implementations;

namespace CronExpressionDecoder.Tests;

public class CronExpressionValidatorTests
{
    private readonly CronExpressionValidator validator;

    public CronExpressionValidatorTests()
    {
        validator = new CronExpressionValidator();
    }

    [Theory]
    [InlineData("* * * * * /command")]
    [InlineData("1,2 1-5 */2 * 1,2,3 /command")]
    public void Validate_ValidExpressions_DoesNotThrow(string expression)
    {
        var exception = Record.Exception(() => validator.Validate(expression));
        Assert.Null(exception);
    }

    [Theory]
    [InlineData("")]
    [InlineData("* * * * *")]
    [InlineData("* * * * * * *")]
    public void Validate_InvalidExpressions_ThrowsValidationException(string expression)
    {
        Assert.Throws<FluentValidation.ValidationException>(() => validator.Validate(expression));
    }
}
