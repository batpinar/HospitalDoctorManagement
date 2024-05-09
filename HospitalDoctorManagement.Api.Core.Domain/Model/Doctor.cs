using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalDoctorManagement.Api.Core.Domain.Model;

public class Doctor : BaseEntity
{
    //public Guid DoctorID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string IdentityNumber { get; set; }
    public ICollection<Hospital> Hospitals { get; set; }
}
