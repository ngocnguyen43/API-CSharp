namespace WebApi2.Dtos
{
    public class OrderDto
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        internal DateTime OrderDate { get; set; } = DateTime.Now;
        internal decimal Total { get; set; }
        public List<OrderProductDto> OrderProducts { get; set; }
    }
}
