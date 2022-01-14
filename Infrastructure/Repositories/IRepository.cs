using System.Collections.Generic;
using Infrastructure.Models;

namespace Infrastructure.Repositories
{
    public interface IRepository
    {
        bool SaveChanges();
        IEnumerable<Customer> GetAllPlatforms();
        void CreatePlatform(Customer model);
    }
}