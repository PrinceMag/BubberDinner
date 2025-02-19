using System.Net;

namespace BuberDinner.Application.Common.Interfaces.Errors
{
    public class DuplicateEmailException : Exception, IServiceExption
    {
        public DuplicateEmailException(string message) : base(message)
        {
        }

        public HttpStatusCode StatusCode => HttpStatusCode.Conflict;

        public string ErrorMessage => "Email already exists.";
    }
}
