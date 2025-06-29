namespace Shared.Validation
{
    public interface IValidator
    {
        Task<Result> Validate<TInput>(TInput input);
        Task<Result<TData>> Validate<TInput, TData>(TInput input)
            where TData : new();
    }
}
