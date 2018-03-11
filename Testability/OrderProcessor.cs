using System;

namespace Testability
{
    public class OrderProcessor
    {
        private readonly IShippingCalculator _shippingCalculator;
        public OrderProcessor(IShippingCalculator shippingCalculator)
        {
            //_shippingCalculator = new ShippingCalculator();
            //實體改從執行時再注入，由外部決定。=> 依賴性注入
            _shippingCalculator = shippingCalculator;
        }

        public void Process(Order order)
        {
            //測試code: OrderProcessorTest
            if (order.IsShipped)
                throw new InvalidOperationException("This order has been processed.");

            //測試code: Process_OrderIsNotShipped_ShouldSetShipmentPropertyOfTheOrder
            order.Shipment = new Shipment
            {
                Cost = _shippingCalculator.CalculatorShipping(order),
                ShippingDate = DateTime.Today.AddDays(1)
            };
        }
    }
}