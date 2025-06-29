using Domain.Entities;

namespace Domain.Validation.CreateOrder
{
    public class CreateOrderData
    {
        public Dictionary<Guid, Product> Products { get; set; }
    }
}
