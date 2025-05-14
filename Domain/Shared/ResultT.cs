using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Shared
{
    public class Result<TValue> : Result
    {
        private  TValue? _value { get; }    
        protected internal Result(TValue? value, bool isSuccess, Error error) : base(isSuccess, error)
        {
            _value = value;
        }   
  
        public TValue Value => IsSuccess
                ? _value!
                : throw new InvalidOperationException("Result is not successful, no value present.");



        public static implicit operator Result<TValue>(TValue value) => Create(value);


    }

}
