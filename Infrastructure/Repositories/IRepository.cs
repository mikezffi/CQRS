using System.Collections.Generic;
using Domain.Models;

namespace Infrastructure.Repositories
{
    public interface IRepository
    {
        bool SaveChanges();
        IEnumerable<Customer> GetAllPlatforms();
        void CreatePlatform(Customer model);
    }
}