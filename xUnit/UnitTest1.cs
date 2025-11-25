using LR6;
using xUnit;

public class ValidatorTests
{
    [Theory]
    [InlineData("a@b.com", true)]
    [InlineData("no_at_symbol", false)]
    public void IsValidEmail_Works(string email, bool expected)
        => Assert.Equal(expected, Validator.IsValidEmail(email));

    [Fact]
    public void EnsureAdult_Throws_WhenMinor()
        => Assert.Throws<ArgumentException>(() => Validator.EnsureAdult(17));
}

public class TariffServiceTests
{
    [Fact]
    public void CalcPrice_Basic_Correct()
        => Assert.Equal(15m, TariffService.CalcPrice("basic", 3));

    [Fact]
    public void CalcPrice_InvalidPlan_Throws()
        => Assert.Throws<ArgumentException>(() => TariffService.CalcPrice("unknown", 1));
}
