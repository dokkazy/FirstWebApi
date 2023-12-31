using FirstWebApi.Services.Interfaces;
using FirstWebApi.ViewModels;

namespace FirstWebApi.Services
{
    public class CategoryRepositoryInMemory : ICategoryRepository
    {
        static List<CategoryViewModel> list = new List<CategoryViewModel>()
        {
            new CategoryViewModel{Id=1,Name="TV"},
            new CategoryViewModel{Id=2,Name="Machine"},
            new CategoryViewModel{Id=3,Name="Engine"},
            new CategoryViewModel{Id=4,Name="Book"},
        };

        public CategoryViewModel Add(CategoryViewModel model)
        {
            var cate = new CategoryViewModel
            {
                Id = list.Count + 1,
                Name = model.Name,
            };
            list.Add(cate);
            return cate;
        }

        public IEnumerable<CategoryViewModel> GetAll()
        {
           return list;
        }

        public CategoryViewModel GetById(int id)
        {
           return list.SingleOrDefault(x=>x.Id == id);

        }

        public void Remove(int id)
        {
            var cate = list.SingleOrDefault(x => x.Id == id);
            list.Remove(cate);
        }

        public void Update(CategoryViewModel model)
        {
            var cate = list.SingleOrDefault(x => x.Id == model.Id);
            if (cate != null)
            {
                cate.Name = model.Name;
            }
        }
    }
}
