using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using WebApi2.Dtos;
using WebApi2.Models.Message;
using WebApi2.Services.Interfaces;
using WebApi2.Utils.Exceptions.ErrorHandler;

namespace WebApi2.Controllers
{
    [Route("api/order")]
    [ApiController]
    //[EnableCors("API-Cors")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService orderService;
        public OrderController(IOrderService orderService)
        {
            this.orderService = orderService;
        }
        [HttpPost]
        [ProducesResponseType(typeof(Meta), 200)]
        public ActionResult<Response> Create([FromBody] OrderDto orderDto)
        {
            return ErrorHandler.Handle(Response, () => orderService.Create(orderDto));
        }
        [HttpGet]
        [Authorize(Roles = "admin")]
        public ActionResult<Response> GetAll()
        {
            return ErrorHandler.Handle(Response, () => orderService.GetAll());
        }
        [HttpGet("{id}")]
        public ActionResult<Response> Get(string id)
        {
            return ErrorHandler.Handle(Response, () => orderService.GetById(id));
        }
    }
}
