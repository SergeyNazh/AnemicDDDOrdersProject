namespace Domain.Entities
{
    public class OrderItem : EntityBase
    {
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public int Count { get; set; }
        public double Price { get; set; }

        #region NavigationProperties
        public Order Order { get; set; }
        public Product Product { get; set; }
        #endregion
    }
}
