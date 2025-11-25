using Microsoft.VisualStudio.TestTools.UnitTesting;
using LR6;

[TestClass]
public class ValidatorTests
{
    [DataTestMethod]
    [DataRow("a@b.com", true)]
    [DataRow("no_at_symbol", false)]
    public void IsValidEmail_Works(string email, bool expected)
        => Assert.AreEqual(expected, Validator.IsValidEmail(email));

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void EnsureAdult_Throws_WhenMinor()
        => Validator.EnsureAdult(17);
}

[TestClass]
public class TariffServiceTests
{
    [TestMethod]
    public void CalcPrice_Basic_Correct()
        => Assert.AreEqual(15m, TariffService.CalcPrice("basic", 3));

    [TestMethod]
    public void CalcPrice_InvalidPlan_Throws()
        => Assert.ThrowsException<ArgumentException>(() => TariffService.CalcPrice("unknown", 1));
}
