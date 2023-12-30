using FirstWebApi.Models;
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
        public static List<Product> list = new List<Product>();

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(list);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            try
            {
                var product = list.SingleOrDefault(x => x.Id == Guid.Parse(id));
                if (product == null) return NotFound();
                return Ok(product);
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Create(ProductViewModel model)
        {

            var product = new Product()
            {
                Id = Guid.NewGuid(),
                Name = model.Product.Name,
                Price = model.Product.Price,
            };
            list.Add(product);
            return Ok(new { success = true, data = product });
        }

        [HttpPut("{id}")]
        public IActionResult Edit(string id, ProductViewModel model)
        {
            try
            {
                var product = list.SingleOrDefault(x => x.Id == Guid.Parse(id));
                if (product == null) return NotFound();
                if (id != product.Id.ToString()) 
                    return BadRequest();
                product.Name = model.Product.Name;
                product.Price = model.Product.Price;
                return Ok();
                
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
                var product = list.SingleOrDefault(x => x.Id == Guid.Parse(id));
                if (product == null) return NotFound();
                list.Remove(product);
                return Ok();

            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
