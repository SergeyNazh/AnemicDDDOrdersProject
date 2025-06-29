namespace Application.Models.Orders.GetOrders
{
    public class ProductModel
    {
        public Guid Id { get; set; }
        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Name { get; set; }
    }
}
