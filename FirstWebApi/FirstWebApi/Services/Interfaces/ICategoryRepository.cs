using FirstWebApi.ViewModels;

namespace FirstWebApi.Services.Interfaces
{
    public interface ICategoryRepository
    {
        IEnumerable<CategoryViewModel> GetAll();
        CategoryViewModel GetById(int id);
        CategoryViewModel Add(CategoryViewModel model);
        void Update(CategoryViewModel model);
        void Remove(int id);
    }
}
