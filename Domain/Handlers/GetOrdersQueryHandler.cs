using Domain.Entities;
using Domain.Queries;
using Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shared;
using Shared.Validation;

namespace Domain.Handlers
{
    public class GetOrdersQueryHandler : IRequestHandler<GetOrdersQuery, Result<IReadOnlyCollection<Order>>>
    {
        private IDatabaseContext _databaseContext;
        private IValidator _validator;
        public GetOrdersQueryHandler(IDatabaseContext databaseContext, IValidator validator)
        {
            _databaseContext = databaseContext;
            _validator = validator;
        }
        public async Task<Result<IReadOnlyCollection<Order>>> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
        {
            Result validationResult = await _validator.Validate(request);
            if (!validationResult.IsSuccess)
            {
                return Result<IReadOnlyCollection<Order>>.Failure(validationResult.ErrorMessage);
            }
            IQueryable<Order> ordersQuery = _databaseContext.Orders
                .AsNoTracking();
            if (request.LoadItems == true)
            {
                ordersQuery = ordersQuery
                    .Include(o => o.OrderItems)
                        .ThenInclude(o => o.Product)
                        .ThenInclude(o => o.Category);
            }
            if (request.SkipCount.HasValue)
            {
                ordersQuery = ordersQuery
                    .Skip(request.SkipCount.Value);
            }
            if (request.TakeCount.HasValue)
            {
                ordersQuery = ordersQuery
                    .Take(request.TakeCount.Value);
            }
            List<Order> orders = await ordersQuery.ToListAsync();
            return Result<IReadOnlyCollection<Order>>.Success(orders);
        }
    }
}
