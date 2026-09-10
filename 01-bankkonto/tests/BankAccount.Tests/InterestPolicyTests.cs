using BankAccount.Domain;

namespace BankAccount.Tests;

public sealed class InterestPolicyTests
{
    public static TheoryData<decimal, AccountStatus, decimal> Boundaries { get; } = new()
    {
        { 0m, AccountStatus.Standard, 0.01m },
        { 9_999.99m, AccountStatus.Vip, 0.01m },
        { 10_000m, AccountStatus.Standard, 0.015m },
        { 49_999.99m, AccountStatus.Vip, 0.015m },
        { 50_000m, AccountStatus.Standard, 0.0175m },
        { 50_000m, AccountStatus.Vip, 0.025m },
        { 99_999.99m, AccountStatus.Standard, 0.0175m },
        { 99_999.99m, AccountStatus.Vip, 0.025m },
        { 100_000m, AccountStatus.Standard, 0.0175m }
    };

    [Theory]
    [MemberData(nameof(Boundaries))]
    public void CreditRate_UsesBalanceClassAndStatus(decimal balance, AccountStatus status, decimal expected)
    {
        // Arrange / Act
        decimal actual = InterestPolicy.CreditRate(balance, status, 0.01m);
        // Assert
        Assert.Equal(expected, actual);
    }
}
