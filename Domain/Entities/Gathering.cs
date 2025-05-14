using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.DomainErrors;
using Domain.Exceptions;
using Domain.Primitives;
using Domain.Shared;
using Domain.DomainErrors;

namespace Domain.Entities
{
    public sealed class Gathering : Entity 
    {

        private readonly List<Invitation> _invitations = new();
        private readonly List<Attendee> _attendees = new();

        private Gathering(
        Guid id,
        Member creator,
        GatheringType type,
        DateTime scheduledAtUtc,
        string name,
        string? location) : base(id)
        {
            Creator = creator;
            Type = type;
            ScheduledAtUtc = scheduledAtUtc;
            Name = name;
            Location = location;
        }


        public Member Creator { get; private set; }

        public GatheringType Type { get; private set; }

        public string Name { get; private set; }

        public DateTime ScheduledAtUtc { get; private set; }

        public string? Location { get; private set; }

        public int? MaximumNumberOfAttendees { get; private set; }

        public DateTime? InvitationsExpireAtUtc { get; private set; }

        public int NumberOfAttendees { get; private set; }

        public IReadOnlyCollection<Attendee> Attendees => _attendees;

        public IReadOnlyCollection<Invitation> Invitations => _invitations;


        public static Gathering Create(
        Guid id,
        Member creator,
        GatheringType type,
        DateTime scheduledAtUtc,
        string name,
        string? location,
        int? maximumNumberOfAttendees,
        int? invitationsValidBeforeInHours)
        {
            // Create gathering
            var gathering = new Gathering(
                Guid.NewGuid(),
                creator,
                type,
                scheduledAtUtc,
                name,
                location);

            gathering.CalculateGatheringTypeDetails(
                maximumNumberOfAttendees,
                invitationsValidBeforeInHours);


            
            return gathering;
        }

        private void CalculateGatheringTypeDetails(int? maximumNumberOfAttendees, int? invitationsValidBeforeInHours)
        {
            // Calculate gathering type details
            switch (Type)
            {
                case GatheringType.WithFixedNumberOfAttendees:
                    if (maximumNumberOfAttendees is null)
                    {
                        throw new GatheringMaximumNumberOfAttendeesIsNullException(
                            $"{nameof(maximumNumberOfAttendees)} can't be null.");
                    }

                    MaximumNumberOfAttendees = maximumNumberOfAttendees;
                    break;
                case GatheringType.WithExpirationForInvitations:
                    if (invitationsValidBeforeInHours is null)
                    {
                        throw new GatheringInvitationValidBeforeInHoursIsNullException(
                            $"{nameof(invitationsValidBeforeInHours)} can't be null.");
                    }

                    InvitationsExpireAtUtc =
                        ScheduledAtUtc.AddHours(-invitationsValidBeforeInHours.Value);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(GatheringType));
            }

        }

        public Result< Invitation > SendInvitation(Member member)
        {
            // Validate
            if (Creator.Id == member.Id)
            {
                return Result.Failure<Invitation>(Exceptions.DomainErrors.Gathering.InvitingError);

  
                //throw new Exception("Can't send invitation to the gathering creator.");
            }

            if (ScheduledAtUtc < DateTime.UtcNow)
            {

                return Result.Failure<Invitation>(Exceptions.DomainErrors.Gathering.GatheringAlreadyPassed);


                //return Result.Failure<Invitation>(new Error("Gathering.AlreadyPassed", "Gathering date already passed !!!"));

                //throw new Exception("Can't send invitation for gathering in the past.");
            }

            var invitation = new Invitation(Guid.NewGuid(), member, this);

            _invitations.Add(invitation);

            return invitation;
        }


        public Attendee? AcceptInvitation(Invitation invitation)
        {
            // Check if expired
            var expired = (Type == GatheringType.WithFixedNumberOfAttendees &&
                           NumberOfAttendees == MaximumNumberOfAttendees) ||
                          (Type == GatheringType.WithExpirationForInvitations &&
                           InvitationsExpireAtUtc < DateTime.UtcNow);
            if (expired)
            {
                invitation.Expire();

                return null;
            }

            var attendee = invitation.Accept();

            _attendees.Add(attendee);
            NumberOfAttendees++;

            return attendee;
        }


    }
}
