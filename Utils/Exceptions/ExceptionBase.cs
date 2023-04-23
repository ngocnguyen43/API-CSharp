namespace WebApi2.Utils.Exceptions
{
    public class ExceptionBase : Exception
    {
        protected string? message;
        protected int statuscode;
        protected int errorcode;
        public string GetMessage() { return message; }
        public int GetStatusCode() { return this.statuscode; }
        public int GetErrorCode() { return this.errorcode; }
        
    }
}
