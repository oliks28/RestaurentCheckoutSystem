using System.Collections.Generic;
using System.Linq;

namespace RestaurantCheckoutSystem.Models
{
    public class Order
    {
        public List<OrderItem> Items { get; private set; }
        public List<string> CanceledItems { get; private set; }  // ✅ Track canceled items

        public Order()
        {
            Items = new List<OrderItem>();
            CanceledItems = new List<string>();  // ✅ Initialize cancellation tracking
        }

        public void AddItem(OrderItem item)
        {
            Items.Add(item);
        }

        public void CancelItem(string itemName)
        {
            CanceledItems.Add(itemName);  // ✅ Store the canceled item
        }
    }
}
