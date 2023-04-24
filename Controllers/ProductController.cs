using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using WebApi2.Dtos;
using WebApi2.Models.Message;
using WebApi2.Services.Interfaces;
using WebApi2.Utils.Exceptions.ErrorHandler;

namespace WebApi2.Controllers
{
    [Route("api/product")]
    [ApiController]
    //[EnableCors("API-Cors")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpPost]
        [Authorize(Roles = "admin")]
        [ProducesResponseType(typeof(Meta), 200)]
        public ActionResult<Response> Create([FromBody] ProductDto productDto)
        {
            return ErrorHandler.Handle(Response, () => _productService.Create(productDto));
        }
        [HttpGet("{id}")]
        public ActionResult<Response> GetById(string id)
        {
            return ErrorHandler.Handle(Response, () => _productService.GetById(id));
        }
        [HttpGet]
        public ActionResult<Response> GetAll()
        {
            return ErrorHandler.Handle(Response, () => _productService.GetAll());
        }
        [HttpPatch]
        [Authorize(Roles = "admin")]
        [ProducesResponseType(typeof(Meta), 200)]
        public ActionResult<Response> Update([FromBody] ProductDto productDto)
        {
            return ErrorHandler.Handle(Response, () => _productService.Update(productDto));
        }
        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        [ProducesResponseType(typeof(Meta), 200)]
        public ActionResult<Response> DeleteById( string id)
        {
            return ErrorHandler.Handle(Response, () => _productService.DeleteById(id));
        }
    }
}
