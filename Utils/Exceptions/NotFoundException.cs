using WebApi2.Utils.Constants;
using WebApi2.Utils.Exceptions;

namespace WebAPI.Utils.Exceptions
{
    public class NotFoundException : ExceptionBase
    {
        public NotFoundException(string message = "Not Found")
        {
            this.message = message;
            this.statuscode = StatusCode.NOT_FOUND;
            this.errorcode = StatusCode.NOT_FOUND;
        }
    }
}
