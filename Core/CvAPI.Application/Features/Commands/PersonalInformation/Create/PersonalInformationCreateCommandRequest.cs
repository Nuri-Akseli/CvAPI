using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Commands.PersonalInformation.Create
{
    public class PersonalInformationCreateCommandRequest:IRequest<PersonalInformationCreateCommandResponse>
    {
        public int CvPartId { get; set; }
        public string Name { get; set; }
        public IFormFile? Icon { get; set; }
        public int Order { get; set; }
    }
}
