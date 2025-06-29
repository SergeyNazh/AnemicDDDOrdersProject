using Domain.Queries;
using Domain.Validation.Shared;
using Shared.Validation;

namespace Domain.Validation.GetOrders
{
    [ValidationOrder(0)]
    public class CustomerExistingValidationHandler : IValidationHandler<GetOrdersQuery>
    {
        private CustomerExistingHelper _customerExistingHelper;
        public CustomerExistingValidationHandler(CustomerExistingHelper customerExistingHelper)
        {
            _customerExistingHelper = customerExistingHelper;
        }
        public async Task Validate(ValidationContext validationContext, GetOrdersQuery input)
        {
            bool customerExists = await _customerExistingHelper.Exists(input.CustomerId);
            if (!customerExists)
            {
                validationContext.SetError($"Customer with Id '{input.CustomerId}' does not exists");
            }
        }
    }
}
