namespace Application.Models.Orders.GetOrders
{
    public class OrderItemModel
    {
        public ProductModel Product { get; set; }
        public int Count { get; set; }
        public double Price { get; set; }
    }
}
