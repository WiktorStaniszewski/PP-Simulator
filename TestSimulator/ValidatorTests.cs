using Simulator;

namespace TestSimulator;

public class ValidatorTests
{
    [Theory]
    [InlineData(5, 1, 10, 5)]
    [InlineData(0, 1, 10, 1)]
    [InlineData(15, 1, 10, 10)]
    public void Limiter_ReturnsExpectedValue(int value, int min, int max, int expected)
    {
        // Act
        int result = Validator.Limiter(value, min, max);

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("abc", 2, 5, '-', "Abc")]
    [InlineData("abcdef", 2, 5, '-', "Abcde")]
    [InlineData("a", 2, 5, '-', "A-")]
    [InlineData("a      b", 2, 5, '-', "A-")]
    public void Shortener_ReturnsExpectedValue(string value, int min, int max, char placeholder, string expected)
    {
        // Act
        string result = Validator.Shortener(value, min, max, placeholder);

        // Assert
        Assert.Equal(expected, result);
    }
}
