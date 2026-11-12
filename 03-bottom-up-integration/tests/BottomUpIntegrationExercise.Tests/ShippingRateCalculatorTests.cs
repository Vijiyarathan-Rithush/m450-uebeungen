using Xunit;

namespace BottomUpIntegrationExercise.Tests;

public sealed class ShippingRateCalculatorTests
{
    [Theory]
    [InlineData(1000, 5)]
    [InlineData(1010, 9)]
    [InlineData(5000, 9)]
    [InlineData(5010, 15)]
    public void Calculate_AtTariffBoundaries_ReturnsExpectedPrice(int grams, int expected)
    {
        // Arrange
        var calculator = new ShippingRateCalculator();
        // Act
        decimal cost = calculator.Calculate(grams / 1000m);
        // Assert
        Assert.Equal((decimal)expected, cost);
    }

    [Fact]
    public void Calculate_ZeroWeight_Throws()
    {
        // Arrange
        var calculator = new ShippingRateCalculator();
        // Act
        var exception = Assert.Throws<ArgumentOutOfRangeException>(() => calculator.Calculate(0m));
        // Assert
        Assert.Equal("totalWeightKg", exception.ParamName);
    }
}
