using FirstWebApi.ViewModels;

namespace FirstWebApi.Services.Interfaces
{
    public interface IProductRepository : IRepository<ProductViewModel, string>
    {
        new IEnumerable<ProductViewModel> GetAll();
        new ProductViewModel GetById(string id);
        new ProductViewModel Add(ProductViewModel model);
        new void Update(ProductViewModel model);
        new void Remove(string id);
    }
}
