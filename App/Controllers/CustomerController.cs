using Domain.Models;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Services.Services.Interfaces;
using Services.DTOs;

namespace App.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class CustomerController : ControllerBase
  {
    private readonly IRepository<Customer> _repository;
    private readonly IService _service;

    public CustomerController(IRepository<Customer> repository, IService service)
    {
      _repository = repository;
      _service = service;
    }

    [HttpGet]
    public ActionResult<IEnumerable<CustomerDTO>> GetAll()
    {
      return Ok(_service.GetAll());
    }
    [HttpGet("{id}")]
    public ActionResult<CustomerDTO> GetById(Guid id)
    {
      var customer = _service.Get(id);
      return Ok(customer);
    }
    [HttpPost]
    public ActionResult Post([FromBody] CustomerDTO customerDTO)
    {
      try
      {
        _service.Save(customerDTO);
        return Ok();
      }
      catch (System.Exception e)
      {
        string errors = e.Message;
        return ValidationProblem(new ValidationProblemDetails()
        {
          Type = "Validation Error",
          Detail = errors
        });
      }
    }
    [HttpPut]
    public ActionResult Put([FromBody] CustomerDTO customerDTO)
    {
      try
      {
        _service.Update(customerDTO);
        return Ok();
      }
      catch (Exception e)
      {
        string errors = e.Message;
        return ValidationProblem(new ValidationProblemDetails()
        {
          Type = "Model Validation Error",
          Detail = errors
        });
      }
    }
    [HttpDelete("{id}")]
    public ActionResult Delete(Guid id)
    {
      try
      {
        _service.Delete(id);
        return Ok();
      }
      catch (Exception e)
      {
        string errors = e.Message;
        return ValidationProblem(new ValidationProblemDetails()
        {
          Type = "Cannot delete",
          Detail = errors
        });
      }
    }
  }
}