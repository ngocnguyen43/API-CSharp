using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using WebApi2.Dtos;
using WebApi2.Models.Message;
using WebApi2.Services.Interfaces;
using WebApi2.Utils.Exceptions.ErrorHandler;

namespace WebApi2.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet("{id}")]
        public ActionResult<Response> GetUserById(string id)
        {
            return ErrorHandler.Handle(Response, () => _userService.GetUserById(id));
        }
        [HttpGet]
        [Authorize(Roles = "admin")]
        public ActionResult<Response> GetAllUsers()
        {
            return ErrorHandler.Handle(Response, () => _userService.GetAllUsers());
        }
        [HttpPost]
        [Authorize(Roles = "admin")]
        [ProducesResponseType(typeof(Meta), 200)]
        public ActionResult<Response> AddUser([FromBody]UserDto userDto)
        {
            return ErrorHandler.Handle(Response, () => _userService.AddUser(userDto));
        }
        [HttpPatch]
        [ProducesResponseType(typeof(Meta), 200)]
        public ActionResult<Response> UpdateUser([FromBody] UserDto userDto)
        {
            return ErrorHandler.Handle(Response, () => _userService.UpdateUser(userDto));
        }
        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        [ProducesResponseType(typeof(Meta), 200)]
        public ActionResult<Response> DeleteUser(string id)
        {
            return ErrorHandler.Handle(Response, () => _userService.DeleteUserById(id));
        }
    }
}
