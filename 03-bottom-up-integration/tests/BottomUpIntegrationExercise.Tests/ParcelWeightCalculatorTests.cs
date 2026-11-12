using Xunit;

namespace BottomUpIntegrationExercise.Tests;

public sealed class ParcelWeightCalculatorTests
{
    [Fact]
    public void Calculate_WithTwoPositions_ReturnsTotalWeight()
    {
        // Arrange
        var calculator = new ParcelWeightCalculator(new ItemWeightCalculator());
        ParcelItem[] items = [new(0.4m, 2), new(0.2m, 1)];
        // Act
        decimal weight = calculator.Calculate(items);
        // Assert
        Assert.Equal(1m, weight);
    }

    [Fact]
    public void Calculate_EmptyParcel_Throws()
    {
        // Arrange
        var calculator = new ParcelWeightCalculator(new ItemWeightCalculator());
        // Act
        var exception = Assert.Throws<ArgumentException>(() => calculator.Calculate([]));
        // Assert
        Assert.Equal("items", exception.ParamName);
    }

    [Fact]
    public void Calculate_InvalidItemInParcel_Throws()
    {
        // Arrange
        var calculator = new ParcelWeightCalculator(new ItemWeightCalculator());
        ParcelItem[] items = [new(0.4m, 2), new(0.2m, 0)];
        // Act
        var exception = Assert.Throws<ArgumentOutOfRangeException>(() => calculator.Calculate(items));
        // Assert
        Assert.Equal("item", exception.ParamName);
    }
}
