using WebApi2.Dtos;
using WebApi2.Models.Message;

namespace WebApi2.Services.Interfaces
{
    public interface IProductService
    {
        public Response GetAll();
        public Response GetById(string id);
        public Response Create(ProductDto productDto);
        public Response Update(ProductDto productDto);
        public Response DeleteById(string id);  
    }
}
