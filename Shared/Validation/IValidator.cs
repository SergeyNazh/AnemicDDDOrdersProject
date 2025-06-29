using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Validation
{
    public interface IValidator
    {
        Task<Result> Validate<TInput>(TInput input);
        Task<Result<TData>> Validate<TInput, TData>(TInput input)
            where TData : new ();
    }
}
