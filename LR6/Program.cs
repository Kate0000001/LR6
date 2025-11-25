using System;

namespace LR6
{
    public interface IDiscountProvider
    {
        decimal GetDiscount(string plan);
    }

    public class TariffWithDiscount
    {
        private readonly IDiscountProvider _discountProvider;

        public TariffWithDiscount(IDiscountProvider discountProvider)
        {
            _discountProvider = discountProvider ?? throw new ArgumentNullException(nameof(discountProvider));
        }

        public decimal Calc(string plan, int months, decimal basePrice)
        {
            decimal discount = _discountProvider.GetDiscount(plan);
            return months * basePrice * (1m - discount);
        }
    }

    public record User(string Login, string Email, int Age);

    public static class Validator
    {
        public static bool IsValidEmail(string email) =>
            !string.IsNullOrWhiteSpace(email) && email.Contains('@') && email.Contains('.');

        public static void EnsureAdult(int age)
        {
            if (age < 18) throw new ArgumentException("User must be 18+");
        }
    }

    public static class TariffService
    {
        public static decimal CalcPrice(string plan, int months)
        {
            if (months <= 0) throw new ArgumentOutOfRangeException(nameof(months));
            return plan switch
            {
                "basic" => 5m * months,
                "pro" => 12m * months,
                "enterprise" => 25m * months,
                _ => throw new ArgumentException("Unknown plan")
            };
        }
    }
}
