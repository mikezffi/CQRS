using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Configurations
{
  public class ConfigurationContext : DbContext
  {
    public ConfigurationContext(DbContextOptions<ConfigurationContext> options) : base(options)
    {
      Database.Migrate();
    }

    public DbSet<Customer> Customers { get; set; }
  }
}