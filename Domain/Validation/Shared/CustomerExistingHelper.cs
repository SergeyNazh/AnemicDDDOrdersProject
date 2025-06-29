using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Domain.Validation.Shared
{
    public class CustomerExistingHelper
    {
        private IDatabaseContext _databaseContext;
        public CustomerExistingHelper(IDatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
        public Task<bool> Exists(Guid customerId) => _databaseContext.Customers.AnyAsync(c => c.Id == customerId);
    }
}
