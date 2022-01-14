using Core.CQRS;

namespace Domain.Commands
{
  public class CreateCustomerCommand : Command
  {
    public string name { get; set; }
    public string email { get; set; }
    public CreateCustomerCommand(string name, string email)
    {
      this.name = name;
      this.email = email;

    }
  }
}