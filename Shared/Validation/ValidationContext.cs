namespace Shared.Validation
{
    public class ValidationContext
    {
        public string? ErrorMessage { get; private set; }
        public bool HasError => ErrorMessage is not null;
        public void SetError(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }
    }
    public class ValidationContext<TData> : ValidationContext
        where TData : new()
    {
        public TData Data { get; } = new TData();
    }
}
