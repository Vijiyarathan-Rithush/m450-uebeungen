using Xunit;

namespace BottomUpIntegrationExercise.Tests;

public sealed class ExpressQuoteTests
{
    [Theory]
    [InlineData(200, 5)]
    [InlineData(300, 9)]
    public void CreateQuote_Express_AddsSevenFrancsWithoutChangingWeight(int secondGrams, int expectedStandard)
    {
        // Arrange
        var service = new ShippingQuoteService(
            new ParcelWeightCalculator(new ItemWeightCalculator()), new ShippingRateCalculator());
        ParcelItem[] items = [new(0.4m, 2), new(secondGrams / 1000m, 1)];
        decimal expectedWeight = (800 + secondGrams) / 1000m;
        // Act
        var standard = service.CreateQuote(items);
        var express = service.CreateQuote(items, express: true);
        // Assert
        Assert.Equal(expectedWeight, standard.TotalWeightKg);
        Assert.Equal(expectedWeight, express.TotalWeightKg);
        Assert.Equal((decimal)expectedStandard, standard.ShippingCostChf);
        Assert.Equal(expectedStandard + 7m, express.ShippingCostChf);
    }
}
