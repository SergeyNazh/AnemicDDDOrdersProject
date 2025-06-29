using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
