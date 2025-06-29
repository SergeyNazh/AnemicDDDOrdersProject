using System.Text.Json.Serialization;

namespace Application.Models.Orders.GetOrders
{
    public class OrderModel
    {
        public Guid Id { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IReadOnlyCollection<OrderItemModel> Items { get; set; }
        public DateTime OrderDate { get; set; }
        public string Status { get; set; }
    }
}
