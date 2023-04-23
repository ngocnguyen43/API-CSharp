using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using WebApi2.Dtos;
using WebApi2.Models.Message;
using WebApi2.Services.Interfaces;
using WebApi2.Utils.Exceptions.ErrorHandler;

namespace WebApi2.Controllers
{
    [Route("api")]
    [ApiController]
    //[EnableCors("API-Cors")] 
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost]
        [Route("/login")]
        public ActionResult<Response> Login([FromBody] UserLoginDto userLoginDto)
        {
            return ErrorHandler.Handle(Response, () => _authService.Login(userLoginDto));
        }       
        [HttpPost]
        [Route("/signup")]
        [ProducesResponseType(typeof(Meta), 200)]
        public ActionResult<Response> Register([FromBody] UserRegisterDto userRegisterDto)
        {
            return ErrorHandler.Handle(Response, () => _authService.Register(userRegisterDto));
        }
    }
}
