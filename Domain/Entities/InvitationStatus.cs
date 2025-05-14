using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public enum InvitationStatus
    {
        Pending = 0,
        Accepted = 1,
        Rejected = 2,
        Expired = 4
    }
}
