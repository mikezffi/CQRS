using Core.Models;

namespace Infrastructure.Repositories
{
    public interface IRepository<T> where T : BaseModel
    {
        T Find(Guid id);
        IEnumerable<T> Get();
        void Add(T t);
        void Remove(Guid id);
        void Update(T t);
    }
}