using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalDoctorManagement.Common.Models.RequestModels;

public class CreateHospitalCommand : IRequest<Guid>
{
    public string HospitalName { get; set; }
    public string Address { get; set; }

    public CreateHospitalCommand(string hospitalName, string address)
    {
        HospitalName = hospitalName;
        Address = address;
    }

    public CreateHospitalCommand()
    {
            
    }
}
