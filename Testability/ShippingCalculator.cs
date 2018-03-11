using System;

namespace Testability
{
    public interface IShippingCalculator
    {
        float CalculatorShipping(Order order);
    }

    public class ShippingCalculator : IShippingCalculator
    {
        public float CalculatorShipping(Order order)
        {
            if (order.TotalPrice < 30f)
                return order.TotalPrice * 0.1f;

            return 0;
        }
    }
}