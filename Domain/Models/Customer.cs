using Core.Models;

namespace Domain.Models
{
  public class Customer : BaseModel
  {
    public string Name { get; set; }
    public string Email { get; set; }
  }
}