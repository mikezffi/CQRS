namespace Services.DTOs
{
  public class CustomerDTO : BaseDTO
  {
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
  }
}