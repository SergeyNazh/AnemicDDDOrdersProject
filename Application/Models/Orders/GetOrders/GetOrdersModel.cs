namespace Application.Models.Orders.GetOrders
{
    public class GetOrdersModel
    {
        public Guid CustomerId { get; set; }
        public bool? LoadItems { get; set; }
        public int? SkipCount { get; set; }
        public int? TakeCount { get; set; }
    }
}
