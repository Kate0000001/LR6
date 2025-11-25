using Moq;
using Xunit;
using LR6;

public class TariffWithDiscountTests
{
    [Fact]
    public void Applies_Discount_From_Provider()
    {
        var mock = new Moq.Mock<IDiscountProvider>();
        mock.Setup(m => m.GetDiscount("pro")).Returns(0.1m);

        var sut = new TariffWithDiscount(mock.Object);
        var total = sut.Calc("pro", 3, 10m);

        Assert.Equal(27m, total); // 3 * 10 * (1 - 0.1)
        mock.Verify(m => m.GetDiscount("pro"), Times.Once);
    }
}
