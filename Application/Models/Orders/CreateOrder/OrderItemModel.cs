using System.ComponentModel.DataAnnotations;

namespace Application.Models.Orders.CreateOrder
{
    public class OrderItemModel
    {
        public Guid ProductId { get; set; }
        [Range(1, int.MaxValue)]
        public int Count { get; set; }
    }
}
