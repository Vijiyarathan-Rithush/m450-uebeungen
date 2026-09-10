using BankAccount.Domain;
using BasicAccount = BankAccount.Domain.BankAccount;

namespace BankAccount.Tests;

public sealed class AccountTests
{
    private static readonly DateOnly OpenedOn = new(2026, 3, 1);
    private static readonly InterestRates Rates = new(0.036m, 0.072m);

    [Fact]
    public void Deposit_CreditsImmediately()
    {
        // Arrange
        BasicAccount account = new(OpenedOn, Rates);
        // Act
        account.Deposit(1_000m, OpenedOn);
        // Assert
        Assert.Equal(1_000m, account.Balance);
    }

    [Fact]
    public void ValidationScenario_BooksDailyCreditAndDebitInterestAtYearEnd()
    {
        // Arrange
        BasicAccount account = new(OpenedOn, Rates);
        // Act
        account.Deposit(1_000m, new DateOnly(2026, 3, 1));
        account.Deposit(1_000m, new DateOnly(2026, 7, 1));
        account.Withdraw(3_000m, new DateOnly(2026, 8, 1));
        account.Deposit(2_000m, new DateOnly(2026, 10, 1));
        decimal interest = account.CloseYear(new DateOnly(2026, 12, 31));
        // Assert
        Assert.Equal(15.30m, interest);
        Assert.Equal(1_015.30m, account.Balance);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void Deposit_NonPositiveAmount_Throws(decimal amount)
    {
        // Arrange
        BasicAccount account = new(OpenedOn, Rates);
        // Act
        Action action = () => account.Deposit(amount, OpenedOn);
        // Assert
        Assert.Throws<ArgumentOutOfRangeException>(action);
    }

    [Fact]
    public void Transfer_BooksBothAccounts()
    {
        // Arrange
        BasicAccount source = new(OpenedOn, Rates);
        BasicAccount target = new(OpenedOn, Rates);
        source.Deposit(100m, OpenedOn);
        // Act
        source.TransferTo(target, 40m, OpenedOn);
        // Assert
        Assert.Equal(60m, source.Balance);
        Assert.Equal(40m, target.Balance);
    }
}
