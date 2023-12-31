using FirstWebApi.Data;
using FirstWebApi.Models;
using FirstWebApi.Services.Interfaces;
using FirstWebApi.Services.Pagination;
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
                CategoryId = model.Category.Id,
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
                Category = product.Category,
            };
        }

        public async Task<PaginatedList<ProductViewModel>> GetAll(string? search, double? from, double? to, string? sortBy, int page = 1)
        {
            var products = _context.Products.AsQueryable();
            #region Filtering
            if (!string.IsNullOrEmpty(search))
            {
                products = products.Where(x => x.Name.Contains(search));
            }
            if (from.HasValue)
            {
                products = products.Where(x => x.Price >= from);
            }
            if (to.HasValue)
            {
                products = products.Where(x => x.Price <= to);
            }
            #endregion
            #region Sorting
            //Default sort by name
            products = products.OrderBy(x => x.Name);
            if (!string.IsNullOrEmpty(sortBy))
            {
                switch (sortBy)
                {
                    case "name_desc":
                        products = products.OrderByDescending(x => x.Name);
                        break;
                    case "price_desc":
                        products = products.OrderByDescending(x => x.Price);
                        break;
                    case "price_asc":
                        products = products.OrderBy(x => x.Price);
                        break;
                }
            }
            #endregion
            var list = await products.Include(x => x.Category).AsNoTracking()
                        .Select(x => new ProductViewModel
                        {
                            Id = x.Id,
                            Name = x.Name,
                            Description = x.Description,
                            Price = x.Price,
                            UnitInStock = x.UnitInStock,
                            Category = x.Category,
                        }).PaginatedListAsync<ProductViewModel>(page, 10);

            return list;
        }

        public ProductViewModel GetById(string id)
        {
            var product = _context.Products.Include(x => x.Category).SingleOrDefault(x => x.Id.ToString() == id);
            return
                (product == null) ? null : new ProductViewModel
                {
                    Id = product.Id,
                    Name = product.Name,
                    Description = product.Description,
                    Price = product.Price,
                    UnitInStock = product.UnitInStock,
                    Category = product.Category,
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
            var product = _context.Products.Include(x => x.Category).SingleOrDefault(x => x.Id == model.Id);
            if (product != null)
            {
                product.Name = model.Name;
                product.Description = model.Description;
                product.Price = model.Price;
                product.UnitInStock = model.UnitInStock;
                product.Category = model.Category;
                _context.Update(product);
                _context.SaveChanges();
            }
        }
    }
}
