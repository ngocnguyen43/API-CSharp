using AutoMapper;
using Newtonsoft.Json.Linq;
using System.IdentityModel.Tokens.Jwt;
using WebAPI.Utils.Exceptions;
using WebAPI.Utils.Helpers;
using WebApi2.Database;
using WebApi2.Dtos;
using WebApi2.Models;
using WebApi2.Models.Message;
using WebApi2.Services.Interfaces;

namespace WebApi2.Services
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;
        public AuthService(AppDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }
        public Response Login(UserLoginDto userLoginDto)
        {
            var user = _appDbContext.Users.Where(p => p.Email == userLoginDto.Email).FirstOrDefault();
            if (user == null)
            {
                throw new NotFoundException("User Not Found");
            }
            var isPasswordSimilar = BCrypt.Net.BCrypt.Verify(userLoginDto.Password, user.Password);
            if (!isPasswordSimilar)
            {
                throw new InvalidCredentialsException("Wrong Password");
            }
            JwtSecurityToken token = JWTGeneration.get(user);
            Meta meta = new Meta.Builder("OK").WithStatusCode(200).Build();
            Body body = new Body.Builder(new JwtSecurityTokenHandler().WriteToken(token)).WithRole(user.Role).WithUserId(user.Id).Build();
            return new Response.Builder(meta).WithBody(body).Build();
        }

        public Response Register(UserRegisterDto userRegisterDto)
        {
            User user = _mapper.Map<User>(userRegisterDto);
            var isExisted = _appDbContext.Users.Any(p => p.Email == user.Email);
            if (isExisted)
            {
                throw new DuplicateEntryException("Email already in used");
            }
            user.Id = Guid.NewGuid().ToString();
            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
            try
            {
                _appDbContext.Users.Add(user);
                _appDbContext.SaveChanges();
            }catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw new UnexpectedException();
            }
            Meta meta = new Meta.Builder("OK").WithStatusCode(201).Build();
            return new Response.Builder(meta).Build();
        }
    }
}
