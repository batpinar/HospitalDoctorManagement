using AutoMapper;
using HospitalDoctorManagement.Api.Core.Domain.Model;
using HospitalDoctorManagement.Common.Models.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalDoctorManagement.Api.Core.Application.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateHospitalCommand, Hospital>();

        CreateMap<CreateDoctorCommand, Doctor>();
    }
}
