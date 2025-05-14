using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Abstractions
{
    public interface IEmailService
    {

        Task SendInvitationSentEmailAsync(Member member, Gathering gathering, CancellationToken cancellationToken=default);

        Task SendInvitationAcceptedEmailAsync( Gathering gathering, CancellationToken cancellationToken = default);


    }
}
