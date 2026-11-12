using BIE.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BIE.UnitTests;

[TestClass]
public sealed class LearnerUnitTests
{
    [TestMethod]
    [DataRow(29, "approved")]
    [DataRow(30, "approved")]
    [DataRow(31, "rejected")]
    public void Evaluate_TourismAtDurationBoundary_ReturnsExpectedStatus(int days, string expected)
    {
        // Arrange
        var entry = new Entry("Sam Test", "Orion", "Tourismus", days, false, false, false, true);
        // Act
        var decision = EntryPolicy.Evaluate(entry);
        // Assert
        Assert.AreEqual(expected, decision.Status);
    }
}
