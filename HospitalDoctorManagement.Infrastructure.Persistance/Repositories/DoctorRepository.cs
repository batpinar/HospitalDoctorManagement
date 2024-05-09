using HospitalDoctorManagement.Api.Core.Application.Interfaces.Repositories;
using HospitalDoctorManagement.Api.Core.Domain.Model;
using HospitalDoctorManagement.Infrastructure.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalDoctorManagement.Infrastructure.Persistance.Repositories;

public class DoctorRepository : GenericRepository<Doctor>, IDoctorRepository
{
    public DoctorRepository(HospitalDoctorDbContext context) : base(context)
    {
        
    }
}
