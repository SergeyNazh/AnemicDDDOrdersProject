using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Validation
{
    public interface IValidationHandler<TInput>
    {
        Task Validate(ValidationContext validationContext, TInput input);
    }
    public interface IValidationHandler<TInput, TData>
        where TData : new ()
    {
        Task Validate(ValidationContext<TData> validationContext, TInput input);
    }
}
