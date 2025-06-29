namespace Shared.Validation
{
    [AttributeUsage(AttributeTargets.Class)]
    public class ValidationOrderAttribute : Attribute
    {
        public int Order { get; }
        public ValidationOrderAttribute(int order)
        {
            Order = order;
        }
    }
}
