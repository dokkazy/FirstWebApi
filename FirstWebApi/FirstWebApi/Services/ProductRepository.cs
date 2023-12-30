using FirstWebApi.Data;
using FirstWebApi.Models;
using FirstWebApi.Services.Interfaces;
using FirstWebApi.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace FirstWebApi.Services
{
    public class ProductRepository : IProductRepository
    {
        private readonly MyDbContext _context;
        public ProductRepository(MyDbContext context)
        {
            _context = context;
        }
        public ProductViewModel Add(ProductViewModel model)
        {
            var product = new Product
            {
                Id = Guid.NewGuid(),
                Name = model.Name,
                Price = model.Price,
                Description = model.Description,
                UnitInStock = model.UnitInStock,
                CategoryId = model.CategoryId,
            };
            _context.Add(product);
            _context.SaveChanges();
            return new ProductViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                UnitInStock = product.UnitInStock,
                CategoryId = model.CategoryId,
            };
        }

        public IEnumerable<ProductViewModel> GetAll()
        {
            var list = _context.Products
                        .AsNoTracking().Select(x => new ProductViewModel
                        {
                            Id = x.Id,
                            Name = x.Name,
                            Description = x.Description,
                            Price = x.Price,
                            UnitInStock = x.UnitInStock,
                            CategoryId = (int)x.CategoryId,
                        }).ToList();
            return list;
        }

        public ProductViewModel GetById(string id)
        {
            var product = _context.Products.SingleOrDefault(x => x.Id.ToString() == id);
            return
                (product == null) ? null : new ProductViewModel
                {
                    Id = product.Id,
                    Name = product.Name,
                    Description = product.Description,
                    Price = product.Price,
                    UnitInStock = product.UnitInStock,
                    CategoryId = (int)product.CategoryId,
                };
        }

        public void Remove(string id)
        {
            var product = _context.Products.SingleOrDefault(x => x.Id.ToString() == id);
            if (product != null)
            {
                _context.Remove(product);
                _context.SaveChanges();
            }
        }

        public void Update(ProductViewModel model)
        {
            var product = _context.Products.SingleOrDefault(x => x.Id == model.Id);
            if (product != null)
            {
                product.Name = model.Name;
                product.Description = model.Description;
                product.Price = model.Price;
                product.UnitInStock = model.UnitInStock;
                product.CategoryId = model.CategoryId;  
                _context.Update(product);
                _context.SaveChanges();
            }
        }
    }
}
