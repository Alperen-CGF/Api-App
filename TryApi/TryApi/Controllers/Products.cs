using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TryApi.Entities;

namespace TryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Products : ControllerBase
    {
        private readonly YapiContext _context;
        public Products(YapiContext context)
        {
            _context = context;
        }

        //api/products/getProducts
        [HttpGet]
        public IActionResult GetProducts()
        {
            return Ok(_context.Products.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetProductsById(int id)
        {
            return Ok(_context.Products.FirstOrDefault(I => I.ProductID == id));
        }
        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, Product product)
        {
            var updatedProduct = _context.Products.FirstOrDefault(I => I.ProductID == id);
            updatedProduct.ProductName = product.ProductName;
            _context.SaveChanges();
            return NoContent();
        }   

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var deleteProduct = _context.Products.FirstOrDefault(I => I.ProductID == id);
            _context.Remove(deleteProduct);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            _context.Add(product);
          
            _context.SaveChanges();
            return Created("",product);
        }
    }
}
