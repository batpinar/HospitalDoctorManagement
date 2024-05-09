using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalDoctorManagement.Api.Core.Domain.Model;

public class Hospital : BaseEntity
{
    //public Guid HospitalID { get; set; }
    public string HospitalName { get; set; }
    public string Address { get; set; }
    public ICollection<Doctor> Doctors { get; set; }
}
