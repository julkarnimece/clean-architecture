using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Application.Invitations.Commands.AcceptInvitation
{
    public sealed record AcceptInvitationCommand(Guid GatheringId,Guid InvitationId) : IRequest;
}
