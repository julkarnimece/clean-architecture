using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Exceptions.Base;

namespace Application.Exceptions
{
    public sealed class ValidationException : BadRequestException
    {

        public ValidationException(Dictionary<string, string[]> errors) : base("Validation Errors Occures")
        {
            Errors = errors;
        }

        public Dictionary<string, string[]> Errors { get; }

    }
}
