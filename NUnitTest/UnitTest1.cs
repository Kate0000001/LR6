using NUnit.Framework;
using LR6;

namespace Core.Tests.NUnit;

[TestFixture]
public class ValidatorTests
{
    [TestCase("a@b.com", true)]
    [TestCase("no_at_symbol", false)]
    public void IsValidEmail_Works(string email, bool expected)
        => Assert.That(Validator.IsValidEmail(email), Is.EqualTo(expected));

    [Test]
    public void EnsureAdult_Throws_WhenMinor()
        => Assert.Throws<ArgumentException>(() => Validator.EnsureAdult(17));
}

[TestFixture]
public class TariffServiceTests
{
    [Test]
    public void CalcPrice_Basic_Correct()
        => Assert.That(TariffService.CalcPrice("basic", 3), Is.EqualTo(15m));

    [Test]
    public void CalcPrice_InvalidPlan_Throws()
        => Assert.Throws<ArgumentException>(() => TariffService.CalcPrice("unknown", 1));
}
