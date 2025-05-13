using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Exceptions;
using Dapper;
using Application.Abstractions.Messaging;

namespace Application.Webinars.Queries.GetWebinarById
{
    internal sealed class GetWebinarQueryHandler : IQueryHandler<GetWebinarByIdQuery, WebinarResponse>
    {
        private readonly IDbConnection _dbConnection;
        public GetWebinarQueryHandler(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }
        public async Task<WebinarResponse> Handle(GetWebinarByIdQuery request, CancellationToken cancellationToken)
        {
            const string sql = @"SELECT * FROM ""Webinars"" WHERE ""Id"" Id = @Id";

            var webinar = await _dbConnection.QuerySingleOrDefaultAsync<WebinarResponse>(sql, new { Id = request.webinarId });

            if(webinar is null)
            {
                throw new WebinarNotFoundException(request.webinarId);
            }


            return webinar;
            //  return new WebinarResponse(webinar.Id, webinar.Name, webinar.ScheduledOn);
        }
    }

}
