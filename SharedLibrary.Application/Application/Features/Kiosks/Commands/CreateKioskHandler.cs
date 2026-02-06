using MediatR;
using SharedLibrary.Application.Dtos;
using SharedLibrary.Application.Interface;
using SharedLibrary.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharedLibrary.Application.Features.Kiosks.Commands
{
    public class CreateKioskHandler
    : IRequestHandler<CreateKioskCommand, int>
    {
        private readonly IKioskRepository _repo;

        public CreateKioskHandler(IKioskRepository repo)
        {
            _repo = repo;
        }

        public async Task<int> Handle(
            CreateKioskCommand request, CancellationToken ct)
        {
            var kiosk = new InvKioskDetail(
                request.Location,
                request.IPAddress);

            await _repo.AddAsync(kiosk);
            return kiosk.Id;
        }


       
    }

}
