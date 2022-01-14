using Domain.Models;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class CustomerController : ControllerBase
  {
    private readonly IRepository _repository;
    public CustomerController(IRepository repository)
    {
      _repository = repository;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Customer>> GetCustomers()
    {
      var platformItems = _repository.GetAllPlatforms();
      return Ok(platformItems);
    }

    [HttpPost]
    public async Task<ActionResult<Customer>> CreatePlatform(Customer platformCreateDto)
    {
      _repository.CreatePlatform(platformCreateDto);
      _repository.SaveChanges();
      return Ok(platformCreateDto);
    }
  }
}