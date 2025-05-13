using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Abstractions.Messaging;

namespace Application.Webinars.Queries.GetWebinarById
{
    public sealed record GetWebinarByIdQuery(Guid webinarId): IQuery<WebinarResponse>;

}
