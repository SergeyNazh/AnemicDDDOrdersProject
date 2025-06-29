namespace Domain.Entities
{
    public class Customer : EntityBase
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        #region NavigationProperties
        public List<Order> Orders { get; set; } = new List<Order>();
        #endregion
    }
}
