using Newtonsoft.Json;

namespace WebApi2.Models.Message
{
    public class Body
    {
        private Body() { }
        [JsonProperty]
        public string? accessToken { get; set; }
        [JsonProperty]
        public string? refreshToken { get; set; }
        [JsonProperty]
        public Object? data { get; set; }       
        [JsonProperty]
        public string? role { get; set; }     
        [JsonProperty]
        public string? id { get; set; }

        public class Builder
        {
            private string? accessToken;
            private string? refreshToken;
            private Object? data;
            private string? role { get; set; }
            private string? id { get; set; }
            public Builder(string? accessToken)
            {
                this.accessToken = accessToken;

            }
            public Builder WithRefreshToken(string? refreshToken)
            {
                this.refreshToken = refreshToken;
                return this;
            }
            public Builder WithData(Object? data)
            {
                this.data = data;
                return this;
            }            public Builder WithRole(string? data)
            {
                this.role = data;
                return this;
            }        
            public Builder WithUserId(string? id)
            {
                this.id = id;
                return this;
            }

            public Body Build()
            {
                Body body = new Body();
                body.accessToken = accessToken;
                body.refreshToken = refreshToken;
                body.data = data;
                body.role = role;
                body.id = id;
                return body;
            }
        }
    }
}
