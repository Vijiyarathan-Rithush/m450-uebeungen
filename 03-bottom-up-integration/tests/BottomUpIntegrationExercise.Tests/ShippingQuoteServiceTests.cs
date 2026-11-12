using Xunit;

namespace BottomUpIntegrationExercise.Tests;

public sealed class ShippingQuoteServiceTests
{
    [Theory]
    [InlineData(400, 200, 1, 1000, 5)]
    [InlineData(400, 300, 1, 1100, 9)]
    [InlineData(2000, 1000, 1, 5000, 9)]
    [InlineData(2000, 1000, 2, 6000, 15)]
    public void CreateQuote_UsesRealWeightAndRateCalculators(int firstGrams, int secondGrams, int secondQuantity, int expectedGrams, int expectedPrice)
    {
        // Arrange
        var service = new ShippingQuoteService(
            new ParcelWeightCalculator(new ItemWeightCalculator()), new ShippingRateCalculator());
        ParcelItem[] items = [new(firstGrams / 1000m, 2), new(secondGrams / 1000m, secondQuantity)];
        // Act
        var quote = service.CreateQuote(items);
        // Assert
        Assert.Equal(expectedGrams / 1000m, quote.TotalWeightKg);
        Assert.Equal((decimal)expectedPrice, quote.ShippingCostChf);
    }

    [Fact]
    public void CreateQuote_EmptyParcel_Throws()
    {
        // Arrange
        var service = new ShippingQuoteService(
            new ParcelWeightCalculator(new ItemWeightCalculator()), new ShippingRateCalculator());
        // Act
        var exception = Assert.Throws<ArgumentException>(() => service.CreateQuote([]));
        // Assert
        Assert.Equal("items", exception.ParamName);
    }
}
