using Newtonsoft.Json;

namespace WebApi2.Models.Message
{

    public class Response
    {
        public Meta meta { get; set; }
        public Body? body { get; set; }
        public Pagination? pagination { get; set; }
        public class Builder
        {
            private Meta meta;
            private Body? body;
            private Pagination? pagination;
            public Builder(Meta meta)
            {
                this.meta = meta;
            }
            public Builder WithBody(Body? body)
            {
                this.body = body;
                return this;
            }
            public Builder WithPagination(Pagination? pagination)
            {
                this.pagination = pagination;
                return this;
            }
            public Response Build()
            {
                Response response = new Response();
                response.meta = meta;
                response.pagination = pagination;
                response.body = body;
                return response;
            }
        }
    }
}
