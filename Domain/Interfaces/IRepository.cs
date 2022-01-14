using Core.Models;
using Domain.Models;

namespace Domain.Interfaces
{
    public interface IRepository<T> where T : Customer
    {
        T Find(Guid id);
        IEnumerable<T> Get();
        void Add(T t);
        void Remove(Guid id);
        void Update(T t);
    }
}