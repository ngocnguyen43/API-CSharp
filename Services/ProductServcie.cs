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
    public class ProductServcie : IProductService
    {
        private readonly IMapper mapper;
        private readonly AppDbContext appDbContext;
        public ProductServcie(AppDbContext appDbContext, IMapper mapper)
        {
            this.appDbContext = appDbContext;
            this.mapper = mapper;
        }
        public Response Create(ProductDto productDto)
        {
            Product product = mapper.Map<Product>(productDto);
            product.Id = Guid.NewGuid().ToString();
            try
            {
                appDbContext.Products.Add(product);
                appDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw new UnexpectedException();
            }
            Meta meta = new Meta.Builder("OK").WithStatusCode(201).Build();
            return new Response.Builder(meta).Build();
        }

        public Response DeleteById(string id)
        {
            Product? product = appDbContext.Products.Where(x => x.Id == id).FirstOrDefault();
            if (product == null)
            {
                throw new NotFoundException("Product Not Found!");
            }
            try
            {
                appDbContext.Products.Remove(product);
                appDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw new UnexpectedException();
            }
            Meta meta = new Meta.Builder("OK").WithStatusCode(201).Build();
            return new Response.Builder(meta).Build();
        }

        public Response GetAll()
        {
            List<Product> products;
            try
            {
                products = appDbContext.Products.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw new UnexpectedException();
            }
            Meta meta = new Meta.Builder("OK").WithStatusCode(200).Build();
            Body body = new Body.Builder(null).WithData(products).Build();
            return new Response.Builder(meta).WithBody(body).Build();
        }

        public Response GetById(string id)
        {
            Product? product;
            bool isExist = appDbContext.Products.Any(x => x.Id == id);
            if (!isExist)
            {
                throw new NotFoundException("Product Not Found");
            }
            try
            {
                product = appDbContext.Products.Where(x => x.Id == id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw new UnexpectedException();
            }
            Meta meta = new Meta.Builder("OK").WithStatusCode(200).Build();
            Body body = new Body.Builder(null).WithData(product).Build();
            return new Response.Builder(meta).WithBody(body).Build();
        }

        public Response Update(ProductDto productDto)
        {
            var isExist = appDbContext.Products.Any(x => x.Id == productDto.Id);
            if (!isExist)
            {
                throw new NotFoundException("Product Not Found");
            }
            Product product = mapper.Map<Product>(productDto);
            try
            {
                appDbContext.Entry(product).State = EntityState.Modified;
                appDbContext.SaveChanges();
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
