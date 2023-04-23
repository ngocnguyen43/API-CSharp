namespace WebApi2.Dtos
{
    public class OrderProductDto
    {
        internal string Id { get; set; }
        internal string OrderId { get; set; }
        public string ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
