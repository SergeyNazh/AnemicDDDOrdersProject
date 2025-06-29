using Domain.Dtos.GetOrders;
using Domain.Entities;
using MediatR;
using Shared;

namespace Domain.Queries
{
    public record GetOrdersQuery(Guid CustomerId, bool? LoadItems, int? SkipCount, int? TakeCount) : IRequest<Result<IReadOnlyCollection<Order>>>;
}
