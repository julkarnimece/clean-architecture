using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Primitives;
using Domain.Shared;

namespace Domain.ValueObjects
{
    public sealed class FirstName : ValueObject
    {
        public const int MaxLength = 50;    
        public FirstName(string value)
        {
                Value = value;
        }
        public string Value { get;  }

        public static Result<FirstName> Create(string firstNameValue)
        {
            if (string.IsNullOrWhiteSpace(firstNameValue))
            {
                return Result.Failure<FirstName>(new Error(
                    "FirstName.Empty", "First Name is Empty"));
            }

            if(firstNameValue.Length > MaxLength)
            {
                return Result.Failure<FirstName>(new Error(
                    "FirstName.TooLong", $"First Name is too long. Max length is {MaxLength}"));
            }

            return Result.Success(new FirstName(firstNameValue));   
        }

        public override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
    }
}
