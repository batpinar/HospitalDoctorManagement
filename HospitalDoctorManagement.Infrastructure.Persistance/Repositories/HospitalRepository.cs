using HospitalDoctorManagement.Api.Core.Application.Interfaces.Repositories;
using HospitalDoctorManagement.Api.Core.Domain.Model;
using HospitalDoctorManagement.Infrastructure.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalDoctorManagement.Infrastructure.Persistance.Repositories
{
    public class HospitalRepository : GenericRepository<Hospital>, IHospitalRepository
    {
        public HospitalRepository(HospitalDoctorDbContext context): base(context)
        { 
        }
    }
}
