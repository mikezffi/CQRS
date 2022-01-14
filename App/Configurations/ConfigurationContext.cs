using App.Models;
using Microsoft.EntityFrameworkCore;

namespace App.Configurations
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