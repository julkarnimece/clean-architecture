using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Exceptions.Base;

namespace Domain.Exceptions
{
    public sealed class GatheringMaximumNumberOfAttendeesIsNullException : DomainException
    {
        public GatheringMaximumNumberOfAttendeesIsNullException(string message) : base(message)
        {

        }
    }
}
