using Domain.Enums;

namespace Domain.Entities
{
    public class Order : EntityBase
    {
        public Guid CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public OrderStatusEnum OrderStatus { get; set; }

        #region NavigationProperties
        public Customer Customer { get; set; }
        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
        #endregion
    }
}
