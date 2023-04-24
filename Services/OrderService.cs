using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebAPI.Utils.Exceptions;
using WebApi2.Database;
using WebApi2.Dtos;
using WebApi2.Models;
using WebApi2.Models.Message;
using WebApi2.Services.Interfaces;

namespace WebApi2.Services
{
    public class OrderService : IOrderService

    {
        private readonly IMapper _mapper;
        private readonly AppDbContext _appDbContext;
        public OrderService(IMapper mapper, AppDbContext appDbContext)
        {
            _mapper = mapper;
            _appDbContext = appDbContext;
        }
        public Response Create(OrderDto orderDto)
        {
            Order order = _mapper.Map<Order>(orderDto);
            order.Id = Guid.NewGuid().ToString();
            order.OrderDate = DateTime.Now;
            order.Total = 0;
            try
            {
                foreach (var orderProductDto in orderDto.OrderProducts)
                {
                    Product? product = _appDbContext.Products.Where(x => x.Id == orderProductDto.ProductId).FirstOrDefault();
                    if (product == null)
                    {
                        throw new NotFoundException("Product Not Found");
                    }
                    if (product.Stock < orderProductDto.Quantity)
                    {
                        throw new UnexpectedException("Invalid Quntity");
                    }
                    var total = product.Price * orderProductDto.Quantity;
                    order.Total += total;
                    product.Stock -= orderProductDto.Quantity;
                    OrderProduct orderProduct = _mapper.Map<OrderProduct>(orderProductDto);
                    orderProduct.Id = Guid.NewGuid().ToString();
                    orderProduct.OrderId = order.Id;
                }
                _appDbContext.Orders.Add(order);
                _appDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw new UnexpectedException();
            }
            Meta meta = new Meta.Builder("OK").WithStatusCode(201).Build();
            return new Response.Builder(meta).Build();
        }

        public Response Delete(string id)
        {
            throw new NotImplementedException();
        }

        public Response GetAll()
        {
            try
            {
                var orders = _appDbContext.Orders.Select(x => new
                {
                    orderId = x.Id,
                    userId = x.UserId,
                    date = x.OrderDate,
                    total = x.Total,

                }).ToList();

                Meta meta = new Meta.Builder("OK").WithStatusCode(200).Build();
                Body body = new Body.Builder(null).WithData(orders).Build();
                return new Response.Builder(meta).WithBody(body).Build();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw new UnexpectedException();
            }
        }

        public Response GetById(string id)
        {
            IQueryable order;
            try
            {
                order = _appDbContext.Orders
                   .Where(z=>z.Id == id)
                   .Include(o => o.OrderProducts)
                   .ThenInclude(op => op.Product)
                   .Select(o => new
                   {
                       OrderId = o.Id,
                       UserId = o.UserId,
                       Product = o.OrderProducts.Select(c => new
                       {
                           productId = c.ProductId,
                           productName = c.Product.Name,
                           description = c.Product.Description,
                           price = c.Product.Price,

                       }).ToList(),
                       Date = o.OrderDate,
                       Total = o.Total,
                   });

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw new UnexpectedException();
            }
            if (order == null)
            {
                throw new NotFoundException("Order Not Found");
            }
            Meta meta = new Meta.Builder("OK").WithStatusCode(200).Build();
            Body body = new Body.Builder(null).WithData(order).Build();
            return new Response.Builder(meta).WithBody(body).Build();
        }

        public Response Update(OrderDto orderDto)
        {
            throw new NotImplementedException();
        }
    }
}
