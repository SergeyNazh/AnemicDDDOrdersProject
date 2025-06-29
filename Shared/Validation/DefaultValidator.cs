using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Shared.Validation
{
    public class DefaultValidator : IValidator
    {
        private IServiceProvider _serviceProvider;
        public DefaultValidator(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public async Task<Result<TData>> Validate<TInput, TData>(TInput input) where TData : new()
        {
            IEnumerable<IValidationHandler<TInput, TData>> validationHandlers = _serviceProvider.GetServices<IValidationHandler<TInput, TData>>()
                .OrderBy(vh => GetValidationHandlerOrder(vh));
            ValidationContext<TData> validationContext = new ValidationContext<TData>();
            foreach (IValidationHandler<TInput, TData> validationHandler in validationHandlers)
            {
                await validationHandler.Validate(validationContext, input);
                if (validationContext.HasError)
                {
                    return Result<TData>.Failure(validationContext.ErrorMessage!);
                }
            }
            return Result<TData>.Success(validationContext.Data);
        }

        public async Task<Result> Validate<TInput>(TInput input)
        {
            IEnumerable<IValidationHandler<TInput>> validationHandlers = _serviceProvider.GetServices<IValidationHandler<TInput>>()
                .OrderBy(vh => GetValidationHandlerOrder(vh));
            ValidationContext validationContext = new ValidationContext();
            foreach (IValidationHandler<TInput> validationHandler in validationHandlers)
            {
                await validationHandler.Validate(validationContext, input);
                if (validationContext.HasError)
                {
                    return Result.Failure(validationContext.ErrorMessage!);
                }
            }
            return Result.Success();
        }

        private int GetValidationHandlerOrder<TInput, TData>(IValidationHandler<TInput, TData> validationHandler) where TData : new() => GetValidationHandlerOrder(validationHandler.GetType());
        private int GetValidationHandlerOrder<TInput>(IValidationHandler<TInput> validationHandler) => GetValidationHandlerOrder(validationHandler.GetType());
        private int GetValidationHandlerOrder(Type type)
        {
            ValidationOrderAttribute? validationOrderAttribute = type.GetCustomAttribute<ValidationOrderAttribute>();
            return validationOrderAttribute is not null
                ? validationOrderAttribute.Order
                : -1;
        }
    }
}
