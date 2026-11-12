using Xunit;

namespace BottomUpIntegrationExercise.Tests;

public sealed class ShippingQuotePlaceholderTests
{
    [Fact]
    public void CreateQuote_PassesTotalWeightToRateCalculator()
    {
        // Arrange
        var rate = new RecordingRatePlaceholder();
        var service = new ShippingQuoteService(new ParcelWeightCalculator(new ItemWeightCalculator()), rate);
        ParcelItem[] items = [new(0.4m, 2), new(0.2m, 1)];
        // Act
        var quote = service.CreateQuote(items);
        // Assert
        Assert.Equal(1m, quote.TotalWeightKg);
        Assert.Equal(42m, quote.ShippingCostChf);
        Assert.Equal(1m, Assert.Single(rate.Weights));
    }

    private sealed class RecordingRatePlaceholder : IShippingRateCalculator
    {
        public List<decimal> Weights { get; } = [];

        public decimal Calculate(decimal totalWeightKg)
        {
            Weights.Add(totalWeightKg);
            return 42m;
        }
    }
}
