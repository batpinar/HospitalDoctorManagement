using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HospitalDoctorManagement.Common.Models.RequestModels
{
    public class CreateDoctorCommand : IRequest<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IdentityNumbner { get; set; }
        public CreateDoctorCommand()
        {
            
        }
        public CreateDoctorCommand(string firstname, string lastname, string identitynumber)
        {
            FirstName = firstname;
            LastName = lastname;
            IdentityNumbner = identitynumber;
            
        }
    }
}
