using FirstWebApi.Models;
using FirstWebApi.Services;
using FirstWebApi.Services.Interfaces;
using FirstWebApi.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace FirstWebApi.Controllers
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
        public async Task<IActionResult> GetAll(string? search, double? from, double? to, string? sortBy, int page = 1)
        {
            try
            {
                var list = await _productRepository.GetAll(search, from, to, sortBy,page);
                return Ok(list);
            }
            catch
            {
                return BadRequest("We can't get product");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            try
            {
                var product = _productRepository.GetById(id);
                if (product == null) return NotFound();
                return Ok(product);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult Create(ProductViewModel model)
        {

            try
            {
                var product = _productRepository.Add(model);
                return StatusCode(StatusCodes.Status201Created, product);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public IActionResult Edit(string id, ProductViewModel model)
        {
            try
            {
                if (id != model.Id.ToString()) return NotFound();
                _productRepository.Update(model);
                return NoContent();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            try
            {
                _productRepository.Remove(id);
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
