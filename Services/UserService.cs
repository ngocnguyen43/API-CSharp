using Microsoft.EntityFrameworkCore;
using WebApi2.Database;
using WebApi2.Models;
using WebApi2.Models.Message;
using WebApi2.Services.Interfaces;
using WebAPI.Utils.Exceptions;
using AutoMapper;
using WebApi2.Dtos;

namespace WebApi2.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public UserService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public Response AddUser(UserDto userDto)
        {
            User user = _mapper.Map<User>(userDto);
            user.Id =  Guid.NewGuid().ToString();
            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
            var isExisted = _context.Users.Any(u => u.Email == user.Email);
            if (isExisted)
            {
                throw new DuplicateEntryException("Email is Already in used");
            }
            _context.Users.Add(user);
            try
            {
                _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw new UnexpectedException();
            }
            Meta meta = new Meta.Builder("OK").WithStatusCode(201).Build();
            return new Response.Builder(meta).Build();
        }

        public Response DeleteUserById(string id)
        {
            var user = _context.Users.Where(u => u.Id == id).FirstOrDefault();
            if (user == null)
            {
                throw new NotFoundException("user Not Found");
            }
            try
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw new UnexpectedException();
            }
            Meta meta = new Meta.Builder("OK").WithStatusCode(200).Build();
            return new Response.Builder(meta).Build();
        }

        public Response GetAllUsers()
        {
            object result;
            try
            {
                result = _context.Users.Select(x =>new 
                {
                    role=x.Role,
                    fullname=x.Fullname,
                    email=x.Email,
                    id= x.Id
                    
                }).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw new UnexpectedException();
            }
            Meta meta = new Meta.Builder("OK").WithStatusCode(200).Build();
            Body body = new Body.Builder(null).WithData(result).Build();
            return new Response.Builder(meta).WithBody(body).Build();
        }

        public Response GetUserById(string id)
        {
            object? result;
            try
            {
                result = _context.Users.Where(x => x.Id == id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw new UnexpectedException();
            }
            Meta meta = new Meta.Builder("OK").WithStatusCode(200).Build();
            Body body = new Body.Builder(null).WithData(result).Build();
            return new Response.Builder(meta).WithBody(body).Build();
        }

        public Response UpdateUser(UserDto userDto)
        {
            var user = _context.Users.Where(u => u.Id == userDto.Id).FirstOrDefault();
            if (user == null)
            {
                throw new NotFoundException("user Not Found");
            }
            if (user.Password != null)
            {
                user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
            }
            try
            {
                _context.Entry(user).State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw new UnexpectedException();
            }
            Meta meta = new Meta.Builder("OK").WithStatusCode(200).Build();
            return new Response.Builder(meta).Build();
        }
    }
}
