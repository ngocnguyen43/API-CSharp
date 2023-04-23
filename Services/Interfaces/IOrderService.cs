using WebApi2.Dtos;
using WebApi2.Models.Message;

namespace WebApi2.Services.Interfaces
{
    public interface IOrderService
    {
        public Response Create(OrderDto orderDto);
        public Response Update(OrderDto orderDto);
        public Response Delete(string id);
        public Response GetById(string id);
        public Response GetAll();
    }
}
