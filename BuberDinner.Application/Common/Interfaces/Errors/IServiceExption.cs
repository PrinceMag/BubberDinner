using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BuberDinner.Application.Common.Interfaces.Errors
{
    public interface IServiceExption
    {
        public HttpStatusCode StatusCode { get; }
        public string ErrorMessage { get; }
    }
}
