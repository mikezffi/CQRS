using Core.Models;

namespace Domain.Interfaces
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