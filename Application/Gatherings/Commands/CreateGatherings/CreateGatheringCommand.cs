using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using MediatR;

namespace Application.Gatherings.Commands.CreateGatherings
{
    public sealed record  CreateGatheringCommand(
        Guid MemberId, 
        GatheringType Type,
        DateTime ScheduledAtUtc,    
        string Name,
        string? Location,
        int? MaximumNumberOfAttendees,
        int? InvitationsValidBeforeInHours
        ) : IRequest;
  
}
