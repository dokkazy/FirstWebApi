using FirstWebApi.Services.Pagination;
using FirstWebApi.ViewModels;

namespace FirstWebApi.Services.Interfaces
{
    public interface IProductRepository
    {
        Task<PaginatedList<ProductViewModel>> GetAll(string? search, double? from, double? to, string? sortBy, int page = 1);
        ProductViewModel GetById(string id);
        ProductViewModel Add(ProductViewModel model);
        void Update(ProductViewModel model);
        void Remove(string id);
    }
}
