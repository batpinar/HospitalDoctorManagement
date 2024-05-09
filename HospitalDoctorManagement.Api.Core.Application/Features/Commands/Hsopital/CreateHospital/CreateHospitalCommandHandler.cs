using AutoMapper;
using HospitalDoctorManagement.Api.Core.Application.Interfaces.Repositories;
using HospitalDoctorManagement.Api.Core.Domain.Model;
using HospitalDoctorManagement.Common.Models.RequestModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalDoctorManagement.Api.Core.Application.Features.Commands.Hsopital.CreateHospital;

public class CreateHospitalCommandHandler : IRequestHandler<CreateHospitalCommand, Guid>
{
    private readonly IHospitalRepository _hospitalRepository;
    private readonly IMapper _mapper;

    public CreateHospitalCommandHandler(IHospitalRepository hospitalRepository, IMapper mapper)
    {
        _hospitalRepository = hospitalRepository;
        _mapper = mapper;
    }

    public async Task<Guid> Handle(CreateHospitalCommand request, CancellationToken cancellationToken)
    {
        var dbHospital = _mapper.Map<Domain.Model.Hospital>(request);

        await _hospitalRepository.AddAsync(dbHospital);
        return dbHospital.Id;
    }
}
