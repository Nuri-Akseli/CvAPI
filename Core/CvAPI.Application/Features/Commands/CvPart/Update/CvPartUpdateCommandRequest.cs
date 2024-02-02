using MediatR;
using Microsoft.AspNetCore.Http;

namespace CvAPI.Application.Features.Commands.CvPart.Update
{
    public class CvPartUpdateCommandRequest:IRequest<CvPartUpdateCommandResponse>
    {
        public int Id { get; set; }
        public int CvInformationId { get; set; } = 0;
        public string? Name { get; set; }
        public IFormFile? Icon { get; set; }
        public int Order { get; set; } = 0;
        public bool IsContactInfo { get; set; } = false;
    }
}
