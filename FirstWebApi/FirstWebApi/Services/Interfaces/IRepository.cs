
namespace FirstWebApi.Services.Interfaces
{
    public interface IRepository<T, E> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(E id);
        T Add(T model);
        void Update(T model);
        void Remove(E id);
    }
}
