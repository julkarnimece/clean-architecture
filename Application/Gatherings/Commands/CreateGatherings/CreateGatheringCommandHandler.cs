using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Abstractions;
using Domain.Entities;
using MediatR;

namespace Application.Gatherings.Commands.CreateGatherings
{

    internal sealed class CreateGatheringCommandHandler : IRequestHandler<CreateGatheringCommand>
    {
        private readonly IMemberRepository _memberRepository;
        private readonly IGatheringRepository _gatheringRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateGatheringCommandHandler(
            IMemberRepository memberRepository,
            IGatheringRepository gatheringRepository,
            IUnitOfWork unitOfWork)
        {
            _memberRepository = memberRepository;
            _gatheringRepository = gatheringRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(CreateGatheringCommand request, CancellationToken cancellationToken)
        {
            var member = await _memberRepository.GetByIdAsync(request.MemberId, cancellationToken);

            if (member is null)
            {
                return Unit.Value;
            }

            var gathering = Gathering.Create(
                Guid.NewGuid(),
                member,
                request.Type,
                request.ScheduledAtUtc,
                request.Name,
                request.Location,
                request.MaximumNumberOfAttendees,
                request.InvitationsValidBeforeInHours);

            _gatheringRepository.Add(gathering);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }

        Task IRequestHandler<CreateGatheringCommand>.Handle(CreateGatheringCommand request, CancellationToken cancellationToken)
        {
            return Handle(request, cancellationToken);
        }
    }
}
