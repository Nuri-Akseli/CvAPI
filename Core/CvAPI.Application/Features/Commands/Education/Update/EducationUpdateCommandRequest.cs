﻿using MediatR;

namespace CvAPI.Application.Features.Commands.Education.Update
{
    public class EducationUpdateCommandRequest:IRequest<EducationUpdateCommandResponse>
    {
        public int Id { get; set; }
        public int CvPartId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Title { get; set; }
        public string University { get; set; }
        public string Department { get; set; }
        public string City { get; set; }
        public int Order { get; set; } = 0;
    }
}
