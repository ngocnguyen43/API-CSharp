using Newtonsoft.Json;

namespace WebApi2.Models.Message
{
    public class Pagination
    {
        private Pagination() { }
        [JsonProperty]
        public int? currentPage { get; set; }
        [JsonProperty]
        public int? totalPages { get; set; }
        [JsonProperty]
        public int? totalResults { get; set; }
        public class Builder
        {
            private int? currentPage;
            private int? totalPages;
            private int? totalResults;
            public Builder(int currentPage)
            {
                this.currentPage = currentPage;
            }
            public Builder WithTotalPages(int totalPages)
            {
                this.currentPage = totalPages;
                return this;
            }
            public Builder WithTotalResults(int totalResults)
            {
                this.totalResults = totalResults;
                return this;
            }
            public Pagination Build()
            {
                Pagination pagination = new Pagination();
                pagination.currentPage = currentPage;
                pagination.totalPages = totalPages;
                pagination.totalResults = totalResults;
                return pagination;
            }
        }
    }
}
