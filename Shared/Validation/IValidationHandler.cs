namespace Shared.Validation
{
    public interface IValidationHandler<TInput>
    {
        Task Validate(ValidationContext validationContext, TInput input);
    }
    public interface IValidationHandler<TInput, TData>
        where TData : new()
    {
        Task Validate(ValidationContext<TData> validationContext, TInput input);
    }
}
