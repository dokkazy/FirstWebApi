using FirstWebApi.Data;
using FirstWebApi.Models;
using FirstWebApi.Services.Interfaces;
using FirstWebApi.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FirstWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var categories = _categoryRepository.GetAll();
                return Ok(categories);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var cate = _categoryRepository.GetById(id);
            if (cate == null) return NotFound();
            return Ok(cate);
        }

        [HttpPost]
        public IActionResult Create(CategoryViewModel model)
        {
            try
            {
                var cate = _categoryRepository.Add(model);
                return StatusCode(StatusCodes.Status201Created, cate);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpPut]
        public IActionResult Update(int id, CategoryViewModel model)
        {
            try
            {
                if (id != model.Id) return NotFound();
                _categoryRepository.Update(model);
                return NoContent();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _categoryRepository.Remove(id);
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
