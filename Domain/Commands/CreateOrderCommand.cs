using Domain.Dtos.CreateOrder;
using MediatR;
using Shared;

namespace Domain.Commands
{
    public record CreateOrderCommand(Guid CustomerId, IReadOnlyCollection<OrderItemDto> OrderItems) : IRequest<Result<Guid>>;
}
