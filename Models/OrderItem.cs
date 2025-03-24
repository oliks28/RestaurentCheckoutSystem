namespace RestaurantCheckoutSystem.Models
{
    public class OrderItem
    {
        public string Name { get; }
        public int Quantity { get; set; }
        public double Price { get; }
        public bool IsFood { get; }
        public bool HasDiscount { get; }
        public int OrderTime { get; }

        public OrderItem(string name, int quantity, double price, bool isFood, bool hasDiscount, int orderTime)
        {
            Name = name;
            Quantity = quantity;
            Price = price;
            IsFood = isFood;
            HasDiscount = hasDiscount;
            OrderTime = orderTime;
        }
    }
}
