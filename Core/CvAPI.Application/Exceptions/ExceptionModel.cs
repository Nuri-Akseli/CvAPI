using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace CvAPI.Application.Exceptions
{
    public class ExceptionModel:ErrorStatusCode
    {
        public IEnumerable<string> Errors { get; set; }
        public override string ToString()=> JsonConvert.SerializeObject(this);
        
    }
    public class ErrorStatusCode
    {
        public int StatusCode { get; set;}
    }
}
