using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Abstractions;
using Domain.Entities;

namespace Infrastructure.Repositories
{
    public sealed class WebinarRepository : IWebinarRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public WebinarRepository(ApplicationDbContext applicationDbContext)
        {
            _dbContext = applicationDbContext;  
        }
        public void Insert(Webinar webinar)
        {
            _dbContext.Set<Webinar>().Add(webinar);
        }
    }
}
