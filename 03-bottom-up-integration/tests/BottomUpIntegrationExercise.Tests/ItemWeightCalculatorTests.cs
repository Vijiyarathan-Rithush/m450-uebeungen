using Xunit;

namespace BottomUpIntegrationExercise.Tests;

public sealed class ItemWeightCalculatorTests
{
    [Fact]
    public void Calculate_TwoItems_ReturnsCombinedWeight()
    {
        // Arrange
        var calculator = new ItemWeightCalculator();
        var item = new ParcelItem(0.4m, 2);
        // Act
        decimal weight = calculator.Calculate(item);
        // Assert
        Assert.Equal(0.8m, weight);
    }

    [Theory]
    [InlineData(0, 2)]
    [InlineData(1, 0)]
    public void Calculate_InvalidWeightOrQuantity_Throws(decimal unitWeight, int quantity)
    {
        // Arrange
        var calculator = new ItemWeightCalculator();
        var item = new ParcelItem(unitWeight, quantity);
        // Act
        var exception = Assert.Throws<ArgumentOutOfRangeException>(() => calculator.Calculate(item));
        // Assert
        Assert.Equal("item", exception.ParamName);
    }
}
