using System;
using System.Collections.Generic;
using System.Linq;
using Infrastructure.Configurations;
using Infrastructure.Models;

namespace Infrastructure.Repositories
{
    public class Repository : IRepository
    {
        private readonly ConfigurationContext _context;

        public Repository(ConfigurationContext context)
        {
            _context = context;
        }
        public void CreatePlatform(Customer model)
        {
        if (model == null)
        {
            throw new ArgumentNullException(nameof(model));
        }
        
        _context.Customers.Add(model);
        }

        public IEnumerable<Customer> GetAllPlatforms()
        {
        return _context.Customers.ToList();
        }
        public bool SaveChanges()
        {
        return (_context.SaveChanges() >= 0);
        }

    }
}