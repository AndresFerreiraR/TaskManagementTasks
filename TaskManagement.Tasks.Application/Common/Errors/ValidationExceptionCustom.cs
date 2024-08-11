using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagement.Tasks.Common.Common.Errors;

namespace TaskManagement.Tasks.Application.Common.Errors
{
    public class ValidationExceptionCustom : Exception
    {
        public IEnumerable<BaseError>? Errors{ get; }

        public ValidationExceptionCustom() : base("One or more validations failures")
        {
            Errors = new List<BaseError>();
        }

        public ValidationExceptionCustom(IEnumerable<BaseError>? errors) : this()
        {
            Errors = errors;            
        }
    }
}