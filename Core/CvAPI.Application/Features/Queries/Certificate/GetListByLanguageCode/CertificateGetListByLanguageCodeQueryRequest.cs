using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Queries.Certificate.GetListByLanguageCode
{
    public class CertificateGetListByLanguageCodeQueryRequest:IRequest<CertificateGetListByLanguageCodeQueryResponse>
    {
        public string LanguageCode { get; set; }
    }
}
