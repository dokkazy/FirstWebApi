using FirstWebApi.Data;
using FirstWebApi.Models;
using FirstWebApi.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FirstWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly MyDbContext _db;
        public CategoryController(MyDbContext db)
        {
            _db = db;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var categories = await _db.Categories.ToListAsync();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var cate = await _db.Categories.SingleOrDefaultAsync(c => c.Id == id);
            if(cate == null) return NotFound();
            return Ok(cate);
        }

        [HttpPost]
        public IActionResult Create(CategoryViewModel model)
        {
            try
            {
                var cate = new Category()
                {
                    Name = model.Name,
                };
                _db.Add(cate);
                _db.SaveChanges();
                return Ok(cate);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public IActionResult Create(int id, CategoryViewModel model)
        {
            try
            {
                var cate = _db.Categories.SingleOrDefault(c => c.Id == id);
                if(cate == null) return NotFound();
                cate.Name = model.Name;

                _db.Update(cate);
                _db.SaveChanges();
                return Ok(cate);
            }
            catch
            {
                return BadRequest();
            }
        }

    }
}
