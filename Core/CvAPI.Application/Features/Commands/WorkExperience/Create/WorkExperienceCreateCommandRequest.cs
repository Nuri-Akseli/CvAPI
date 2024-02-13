using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Commands.WorkExperience.Create
{
    public class WorkExperienceCreateCommandRequest:IRequest<WorkExperienceCreateCommandResponse>
    {
        public int CvPartId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; } = null;
        public string? Title { get; set; }
        public string? Company { get; set; }
        public string? ShortDescription { get; set; }
        public string? City { get; set; }
        public int Order { get; set; }
    }
}
