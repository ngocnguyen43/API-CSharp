using WebApi2.Utils.Constants;
using WebApi2.Utils.Exceptions;

namespace WebAPI.Utils.Exceptions
{
    public class DuplicateEntryException:ExceptionBase
    {
        public DuplicateEntryException(string message = "duplicate")
        {
            this.message = message;
            this.statuscode = StatusCode.DUPLICATE;
            this.errorcode = StatusCode.DUPLICATE;
        }
    }
}
