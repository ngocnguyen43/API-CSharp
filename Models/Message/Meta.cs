using Newtonsoft.Json;

namespace WebApi2.Models.Message
{
    public class Meta
    {
        private Meta() { }
        public string message { get; set; }
        public int statuscode { get; set; }
        public int errorcode { get; set; }
        public int GetStatusCode()
        {
            return this.statuscode;
        }
        public int GetErrorCode() { return this.errorcode; }
        public class Builder
        {
            private string message;
            private int statuscode;
            private int errorcode;
            public Builder(string message)
            {
                this.message = message;
            }
            public Builder WithStatusCode(int statuscode)
            {
                this.statuscode = statuscode;
                return this;
            }
            public Builder WithErrorCode(int errorcode)
            {
                this.errorcode = errorcode;
                return this;
            }
            public Meta Build()
            {
                Meta meta = new Meta();
                meta.message = message;
                meta.statuscode = statuscode;
                meta.errorcode = errorcode;
                return meta;
            }
        }
    }
}
