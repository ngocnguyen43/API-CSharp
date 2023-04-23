using WebApi2.Utils.Constants;
using WebApi2.Utils.Exceptions;

namespace WebAPI.Utils.Exceptions
{
    public class UnexpectedException : ExceptionBase
    {
        public UnexpectedException()
        {
            this.message = "Unexpected Error";
            this.statuscode = StatusCode.UNEXPECTED;
            this.errorcode = 2;
        }
        public UnexpectedException(string message)
        {
            this.message = message;
            this.statuscode = StatusCode.UNEXPECTED;
            this.errorcode = 2;
        }
    }
}
