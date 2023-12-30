using FirstWebApi.Data;
using FirstWebApi.Models;
using FirstWebApi.Services.Interfaces;
using FirstWebApi.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace FirstWebApi.Services
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly MyDbContext _context;
        public CategoryRepository(MyDbContext context)
        {
            _context = context;
        }
        public IEnumerable<CategoryViewModel> GetAll()
        {
            var list = _context.Categories
                        .AsNoTracking().Select(x => new CategoryViewModel { Id = x.Id, Name = x.Name }).ToList();
            return list;
        }

     

        public CategoryViewModel GetById(int id)
        {
            var category = _context.Categories.SingleOrDefault(x => x.Id == id);
            return
                (category == null) ? null : new CategoryViewModel { Id = category.Id, Name = category.Name };

        }

        public CategoryViewModel Add(CategoryViewModel model)
        {
            var cate = new Category
            {
                Name = model.Name,
            };
            _context.Add(cate);
            _context.SaveChanges();
            return new CategoryViewModel { Id = cate.Id, Name = cate.Name };
        }

        public void Update(CategoryViewModel model)
        {
            var category = _context.Categories.SingleOrDefault(x => x.Id == model.Id);
            if (category != null)
            {
                category.Name = model.Name;
                _context.Update(category);
                _context.SaveChanges();
            }
        }

        public void Remove(int id)
        {
            var category = _context.Categories.SingleOrDefault(x => x.Id == id);
            if (category != null)
            {
                _context.Remove(category);
                _context.SaveChanges();
            }
        }
    }
}
