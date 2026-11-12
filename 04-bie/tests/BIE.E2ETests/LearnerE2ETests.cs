using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace BIE.E2ETests;

[TestClass]
public sealed class LearnerE2ETests : BrowserTestBase
{
    [TestMethod]
    public void Submit_TouristAt30Days_RemainsApprovedAfterReload()
    {
        // Arrange
        Fill("Sam Browser", "Tourismus", "30");
        // Act
        Driver.FindElement(By.Id("submit")).Click();
        var result = Wait.Until(driver =>
        {
            var element = driver.FindElement(By.Id("result"));
            return element.Displayed ? element : null;
        });
        // Assert
        StringAssert.Contains(result.Text, "GENEHMIGT");
        var caseId = result.GetDomAttribute("data-application-id");
        Assert.IsFalse(string.IsNullOrWhiteSpace(caseId));

        Driver.Navigate().Refresh();
        var row = Wait.Until(driver => driver.FindElements(By.CssSelector("#application-list tr"))
            .FirstOrDefault(candidate => candidate.GetDomAttribute("data-id") == caseId));
        var cells = row.FindElements(By.TagName("td"));

        Assert.AreEqual("Sam Browser", cells[1].Text);
        Assert.AreEqual("Orion", cells[2].Text);
        Assert.AreEqual("30 Tage", cells[3].Text);
        Assert.AreEqual("GENEHMIGT", cells[4].Text);
    }
}
