using WebApi2.Utils.Constants;
using WebApi2.Utils.Exceptions;

namespace WebAPI.Utils.Exceptions
{
    public class InvalidCredentialsException:ExceptionBase
    {
        public InvalidCredentialsException(string message = "Invalid Credentials Exception") { 
            this.message = message;
            this.statuscode = StatusCode.INVALID_CREDENTIALS;
            this.errorcode = StatusCode.INVALID_CREDENTIALS;
        }
    }
}
