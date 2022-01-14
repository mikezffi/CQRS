using App.Models;

namespace App.Configurations
{
    public interface IRepository
    {
        bool SaveChanges();
        IEnumerable<Customer> GetAllPlatforms();
        void CreatePlatform(Customer model);
    }
}