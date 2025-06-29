using Domain.Commands;
using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Shared.Validation;

namespace Domain.Validation.CreateOrder
{
    [ValidationOrder(1)]
    public class OrderItemsValidationHandler : IValidationHandler<CreateOrderCommand, CreateOrderData>
    {
        private IDatabaseContext _databaseContext;
        public OrderItemsValidationHandler(IDatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
        public async Task Validate(ValidationContext<CreateOrderData> validationContext, CreateOrderCommand input)
        {
            Guid[] productsIds = input.OrderItems
                .Select(x => x.ProductId)
                .Distinct()
                .ToArray();
            if (productsIds.Length != input.OrderItems.Count)
            {
                validationContext.SetError("There are repetitions among the order items");
                return;
            }
            Dictionary<Guid, Product> products = await _databaseContext.Products
                .AsNoTracking()
                .Where(p => productsIds.Contains(p.Id))
                .ToDictionaryAsync(
                    p => p.Id,
                    p => p
                    );
            if (products.Count != input.OrderItems.Count)
            {
                validationContext.SetError("Some products don't exist");
                return;
            }
            validationContext.Data.Products = products;
        }
    }
}
