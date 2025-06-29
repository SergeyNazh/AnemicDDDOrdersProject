namespace Domain.Entities
{
    public class ProductCategory : EntityBase
    {
        public string CategoryName { get; set; }

        #region NavigationProperties
        public List<Product> Products { get; set; } = new List<Product>();
        #endregion
    }
}
