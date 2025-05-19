using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Abstractions;
using Domain.Abstractions;
using Domain.Entities;
using MediatR;

namespace Application.Invitations.Commands.AcceptInvitation
{
    internal sealed class AcceptInvitationCommandHandler : IRequestHandler<AcceptInvitationCommand>
    {
        private readonly IInvitationRepository _invitationRepository;
        private readonly IUnitOfWork _unitOfWork;   
        private readonly IMemberRepository _memberRepository;
        private readonly IGatheringRepository _gatheringRepository; 
        private readonly IAttendeeRepository _attendeeRepository;
        private readonly IEmailService _emailService;

        public AcceptInvitationCommandHandler(IInvitationRepository invitationRepository, IUnitOfWork unitOfWork, IMemberRepository memberRepository, IGatheringRepository gatheringRepository, IEmailService emailService, IAttendeeRepository attendeeRepository)
        {
            _invitationRepository = invitationRepository;
            _unitOfWork = unitOfWork;
            _memberRepository = memberRepository;
            _gatheringRepository = gatheringRepository;
            _emailService = emailService;
            _attendeeRepository = attendeeRepository;
        }

        public async Task<Unit> Handle(AcceptInvitationCommand request, CancellationToken cancellationToken)
        {

            var gathering = await _gatheringRepository.GetByIdWithCreatorAsync(request.GatheringId, cancellationToken);

            var invitation = gathering.Invitations.FirstOrDefault(i => i.Id == request.InvitationId);    

            if (invitation is null || invitation.Status != InvitationStatus.Pending)
            {
                return Unit.Value;
            }

            var member = await _memberRepository.GetByIdAsync(invitation.MemberId, cancellationToken);



            if (member is null || gathering is null)
            {
                return Unit.Value;
            }


            var attendee = gathering.AcceptInvitation(invitation);

            if(attendee is not null)
            {
                _attendeeRepository.Add(attendee);
            }

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            if(invitation.Status == InvitationStatus.Accepted)
            {
                await _emailService.SendInvitationAcceptedEmailAsync(gathering, cancellationToken);
            }

            return Unit.Value;







        }

        Task IRequestHandler<AcceptInvitationCommand>.Handle(AcceptInvitationCommand request, CancellationToken cancellationToken)
        {
            return Handle(request, cancellationToken);
        }
    }
}
