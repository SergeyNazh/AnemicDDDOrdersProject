namespace Application.Models.Orders.CreateOrder
{
    public class OrderModel
    {
        public Guid CustomerId { get; set; }
        public IReadOnlyCollection<OrderItemModel> Items { get; set; }
    }
}
