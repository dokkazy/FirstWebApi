using FirstWebApi.ViewModels;

namespace FirstWebApi.Services.Interfaces
{
    public interface ICategoryRepository : IRepository<CategoryViewModel,int>
    {
        new IEnumerable<CategoryViewModel> GetAll();
        new CategoryViewModel GetById(int id);
        new CategoryViewModel Add(CategoryViewModel model);
        new void Update(CategoryViewModel model);
        new void Remove(int id);
    }
}
