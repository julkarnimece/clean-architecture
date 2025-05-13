using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Exceptions.Base;

namespace Domain.Exceptions
{
    public sealed class WebinarNotFoundException : NotFoundException
    {
        public WebinarNotFoundException(Guid webinarId)
            : base($"Webinar with id: {webinarId} was not found.")
        {
                
        }
    }
}
