using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Exceptions.Base;

namespace Domain.Exceptions
{
    public sealed class GatheringInvitationValidBeforeInHoursIsNullException : DomainException
    {
        public GatheringInvitationValidBeforeInHoursIsNullException(string message) : base(message)
        {
        }
    }
}
