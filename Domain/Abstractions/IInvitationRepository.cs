using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Abstractions
{
    public interface IInvitationRepository
    {
        Task<Invitation?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

        void Add(Invitation invitation);    



    }
}
