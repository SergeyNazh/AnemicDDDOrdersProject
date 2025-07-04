﻿namespace Domain.Entities
{
    public class Product : EntityBase
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid CategoryId { get; set; }
        public double Price { get; set; }

        #region NavigationProperties
        public ProductCategory Category { get; set; }
        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
        #endregion
    }
}
