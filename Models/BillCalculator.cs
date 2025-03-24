using System.Linq;

namespace RestaurantCheckoutSystem.Models
{
    public static class BillCalculator
    {
        public static double CalculateTotal(Order order)
        {
            double total = 0;
            double foodTotal = 0;

            foreach (var item in order.Items)
            {
                double itemPrice = item.Price * item.Quantity;

                // Apply 30% discount on drinks before 19:00
                if (item.HasDiscount && item.OrderTime < 19)
                {
                    itemPrice *= 0.7;
                }

                total += itemPrice;

                // Ensure ONLY Starters & Mains contribute to the service charge
                if (item.IsFood)
                {
                    foodTotal += itemPrice;  // Now using the already discounted price
                }
            }

            // Apply 10% service charge only on food total
            double serviceCharge = foodTotal * 0.10;
            return total + serviceCharge;
        }

    }
}
