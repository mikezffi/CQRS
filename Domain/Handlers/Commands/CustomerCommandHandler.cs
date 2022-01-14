using AutoMapper;
using Core.CQRS;
using Domain.Interfaces;
using Domain.Commands;
using Domain.Models;

namespace Domain.Handlers.Commands
{
  public class CustomerCommandHandler : IHandler<CreateCustomerCommand>,
                                              IHandler<RemoveCustomerCommand>,
                                              IHandler<UpdateCustomerCommand>
  {
    private readonly IRepository<Customer> _repository;
    private readonly IMapper _mapper;

    public CustomerCommandHandler(IRepository<Customer> repository, IMapper mapper)
    {
      _repository = repository;
      _mapper = mapper;
    }


    public void Handle(CreateCustomerCommand message)
    {
      if(message != null)
      {
        var customer = _mapper.Map<Customer>(message);
        _repository.Add(customer);
      }
    }
    public void Handle(RemoveCustomerCommand message)
    {
      var customer = _repository.Find(message.Id);
      if(customer != null)
      {
        _repository.Remove(message.Id);
      }
    }
    public void Handle(UpdateCustomerCommand message)
        {
            if(message != null)
            {
                var customer = _mapper.Map<Customer>(message);
                _repository.Update(customer);
            }
        }
  }
}