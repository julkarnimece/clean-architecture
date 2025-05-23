﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Application.Abstractions.Messaging;
using Domain.Abstractions;

namespace Application.Webinars.Commands.CreateWebinar
{
    internal sealed class CreateWebinarCommandHandler : ICommandHandler<CreateWebinarCommand, Guid>
    {
        private readonly IWebinarRepository _webinarRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateWebinarCommandHandler(IWebinarRepository webinarRepository, IUnitOfWork unitOfWork)
        {
                _webinarRepository = webinarRepository;
                _unitOfWork = unitOfWork;   
        }

        public async Task<Guid> Handle(CreateWebinarCommand request, CancellationToken cancellationToken)
        {
            var webinar = new Domain.Entities.Webinar(Guid.NewGuid(), request.Name, request.ScheduledOn);
            _webinarRepository.Insert(webinar);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return webinar.Id;
        }


    }
}
