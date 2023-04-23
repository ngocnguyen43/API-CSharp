using WebApi2.Dtos;
using WebApi2.Models.Message;

namespace WebApi2.Services.Interfaces
{
    public interface IAuthService
    {
        public Response Login(UserLoginDto userLoginDto);
        public Response Register(UserRegisterDto userRegisterDto);
    }
}
