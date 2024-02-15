using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Commands.PersonalInformation.Delete
{
    public class PersonalInformationDeleteCommandRequest:IRequest<PersonalInformationDeleteCommandResponse>
    {
        public int Id { get; set; }
    }
}
