using CronExpressionDecoder.Services.Implementations;
using CronExpressionDecoder.Services.Interfaces;
using Moq;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CronExpressionDecoder.Tests;

public class CronExpressionParserTests
{
    private readonly Mock<ICronExpressionValidator> validatorMock;
    private readonly Mock<ICronFieldParser> fieldParserMock;
    private readonly CronExpressionParser parser;

    public CronExpressionParserTests()
    {
        validatorMock = new Mock<ICronExpressionValidator>();
        fieldParserMock = new Mock<ICronFieldParser>();
        parser = new CronExpressionParser(validatorMock.Object, fieldParserMock.Object);
    }

    [Fact]
    public void Parse_ValidExpression_ReturnsFormattedOutput()
    {
        // Arrange
        var expression = "*/15 0 1,15 * 1-5 /usr/bin/find";
        fieldParserMock.Setup(x => x.Parse("*/15", 0, 59))
            .Returns(new List<int> { 0, 15, 30, 45 });
        fieldParserMock.Setup(x => x.Parse("0", 0, 23))
            .Returns(new List<int> { 0 });
        fieldParserMock.Setup(x => x.Parse("1,15", 1, 31))
            .Returns(new List<int> { 1, 15 });
        fieldParserMock.Setup(x => x.Parse("*", 1, 12))
            .Returns(Enumerable.Range(1, 12).ToList());
        fieldParserMock.Setup(x => x.Parse("1-5", 1, 7))
            .Returns(new List<int> { 1, 2, 3, 4, 5 });

        // Act
        var output = parser.Parse(expression).FormatOutput();

        // Assert
        var expected = new StringBuilder();
        expected.AppendLine("minute        0 15 30 45");
        expected.AppendLine("hour          0");
        expected.AppendLine("day of month  1 15");
        expected.AppendLine("month         1 2 3 4 5 6 7 8 9 10 11 12");
        expected.AppendLine("day of week   1 2 3 4 5");
        expected.AppendLine("command       /usr/bin/find");
        Assert.Equal(expected.ToString(), output);
    }

    [Fact]
    public void Parse_InvalidExpression_ThrowsValidationException()
    {
        // Arrange
        var expression = "invalid";
        validatorMock.Setup(x => x.Validate(expression))
            .Throws(new ValidationException("Invalid expression"));

        // Act & Assert
        Assert.Throws<ValidationException>(() => parser.Parse(expression));
    }
}
