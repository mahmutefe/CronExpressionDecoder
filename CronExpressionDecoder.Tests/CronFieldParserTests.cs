using CronExpressionDecoder.Services.Implementations;

namespace CronExpressionDecoder.Tests;

public class CronFieldParserTests
{
    private readonly CronFieldParser parser;

    public CronFieldParserTests()
    {
        parser = new CronFieldParser();
    }

    [Theory]
    [InlineData("*", 0, 5, new[] { 0, 1, 2, 3, 4, 5 })]
    [InlineData("1,3,5", 1, 5, new[] { 1, 3, 5 })]
    [InlineData("1-3", 1, 5, new[] { 1, 2, 3 })]
    [InlineData("*/2", 0, 6, new[] { 0, 2, 4, 6 })]
    public void Parse_ValidExpressions_ReturnsExpectedValues(string expression, int min, int max, int[] expected)
    {
        var result = parser.Parse(expression, min, max);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("6", 0, 5, "Single value must be between 0 and 5")]
    [InlineData("1-6", 0, 5, "Range end value must be between 0 and 5")]
    [InlineData("*/0", 0, 5, "Step value must be between 1 and 6")]
    public void Parse_InvalidExpressions_ThrowsException(string expression, int min, int max, string expectedError)
    {
        var exception = Assert.Throws<ArgumentException>(() => parser.Parse(expression, min, max));
        Assert.Equal(expectedError, exception.Message);
    }
}