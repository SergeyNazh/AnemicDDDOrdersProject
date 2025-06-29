using Domain.Commands;
using Domain.Validation.Shared;
using Shared.Validation;

namespace Domain.Validation.CreateOrder
{
    [ValidationOrder(0)]
    public class CustomerExistingValidationHandler : IValidationHandler<CreateOrderCommand, CreateOrderData>
    {
        private CustomerExistingHelper _customerExistingHelper;
        public CustomerExistingValidationHandler(CustomerExistingHelper customerExistingHelper)
        {
            _customerExistingHelper = customerExistingHelper;
        }
        public async Task Validate(ValidationContext<CreateOrderData> validationContext, CreateOrderCommand input)
        {
            bool customerExists = await _customerExistingHelper.Exists(input.CustomerId);
            if (!customerExists)
            {
                validationContext.SetError($"Customer with Id '{input.CustomerId}' does not exists");
            }
        }
    }
}
