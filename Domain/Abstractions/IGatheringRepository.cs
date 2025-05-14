using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Abstractions
{
    public interface IGatheringRepository
    {
        Task<Gathering?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

        Task<Gathering?> GetByIdWithCreatorAsync(Guid id, CancellationToken cancellationToken = default);

        void Add(Gathering gathering);

    }
}
