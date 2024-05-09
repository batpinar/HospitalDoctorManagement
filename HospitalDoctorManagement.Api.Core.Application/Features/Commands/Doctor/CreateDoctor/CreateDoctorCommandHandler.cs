using AutoMapper;
using HospitalDoctorManagement.Api.Core.Application.Interfaces.Repositories;
using HospitalDoctorManagement.Common.Models.RequestModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalDoctorManagement.Api.Core.Application.Features.Commands.CreateDoctor.Create
{
    public class CreateDoctorCommandHandler : IRequestHandler<CreateDoctorCommand, Guid>
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly IMapper _mapper;

        public CreateDoctorCommandHandler(IDoctorRepository doctorRepository, IMapper mapper)
        {
            _doctorRepository = doctorRepository;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CreateDoctorCommand request, CancellationToken cancellationToken)
        {
            var dbDoctor = _mapper.Map<Domain.Model.Doctor>(request);

            await _doctorRepository.AddAsync(dbDoctor);

            return dbDoctor.Id;
        }
    }
}
