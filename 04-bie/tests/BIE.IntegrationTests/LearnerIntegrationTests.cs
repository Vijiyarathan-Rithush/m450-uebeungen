using System.Net;
using System.Net.Http.Json;
using BIE.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bie.IntegrationTests;

[TestClass]
public sealed class LearnerIntegrationTests
{
    [TestMethod]
    public async Task PostAndGet_TouristAt30Days_PersistsApprovedCase()
    {
        // Arrange
        using var app = new BieFactory();
        using var client = app.CreateClient();
        var entry = new Entry("Sam Test", "Orion", "Tourismus", 30, false, false, false, true);
        // Act
        using var response = await client.PostAsJsonAsync("/api/cases", entry);
        var records = await client.GetFromJsonAsync<List<Case>>("/api/cases");
        // Assert
        Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
        Assert.IsNotNull(records);
        Assert.AreEqual(1, records.Count);
        var record = records[0];
        Assert.AreEqual(entry, record.Applicant);
        Assert.IsTrue(record.Id > 0);
        Assert.AreEqual("approved", record.Decision.Status);
    }
}
