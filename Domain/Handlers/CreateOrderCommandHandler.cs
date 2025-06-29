using Domain.Commands;
using Domain.Entities;
using Domain.Enums;
using Domain.Repositories;
using Domain.Validation.CreateOrder;
using MediatR;
using Shared;
using Shared.Validation;

namespace Domain.Handlers
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Result<Guid>>
    {
        private IDatabaseContext _databaseContext;
        private IValidator _validator;
        public CreateOrderCommandHandler(IDatabaseContext databaseContext, IValidator validator)
        {
            _databaseContext = databaseContext;
            _validator = validator;
        }
        public async Task<Result<Guid>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            Result<CreateOrderData> validationResult = await _validator.Validate<CreateOrderCommand, CreateOrderData>(request);
            if (!validationResult.IsSuccess)
            {
                return Result<Guid>.Failure(validationResult.ErrorMessage!);
            }
            List<OrderItem> orderItems = request.OrderItems
                .Select(i => new OrderItem
                {
                    ProductId = i.ProductId,
                    Count = i.Count,
                    Price = validationResult.Value!.Products[i.ProductId].Price
                })
                .ToList();
            Order order = new Order
            {
                CustomerId = request.CustomerId,
                OrderItems = orderItems,
                OrderDate = DateTime.UtcNow,
                OrderStatus = OrderStatusEnum.Created
            };
            await _databaseContext.Orders.AddAsync(order);
            await _databaseContext.SaveChangesAsync();
            return Result<Guid>.Success(order.Id);
        }
    }
}
