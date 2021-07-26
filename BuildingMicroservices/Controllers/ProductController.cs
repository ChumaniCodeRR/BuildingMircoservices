using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuildingMicroservices.Models;
using BuildingMicroservices.Repository;

namespace BuildingMicroservices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        { 
            _productRepository = productRepository;
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            var products = _productRepository.GetProducts();
            return new OkObjectResult(products);
        }

     
        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
            var product = _productRepository.GetProductByID(id);
            return new OkObjectResult(product);
        }

        [HttpPost]
        public Product Add([FromBody] Product product)
        {
            _productRepository.CreateProduct(product);
            return product;
        }

        [HttpPut]
        public IActionResult Edit([FromBody] Product product)
        {
            if(product != null)
            {
                _productRepository.EditProduct(product);
                return new OkResult();
            }

            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _productRepository.DeleteProduct(id);
            return new OkResult();
        }

       
    }
}
