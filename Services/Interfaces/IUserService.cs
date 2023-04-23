using WebApi2.Dtos;
using WebApi2.Models.Message;

namespace WebApi2.Services.Interfaces
{
    public interface IUserService
    {
        public Response GetAllUsers();
        public Response AddUser(UserDto userDto);
        public Response GetUserById(string id);
        public Response UpdateUser(UserDto userDto);
        public Response DeleteUserById(string id);

    }
}
