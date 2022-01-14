using AutoMapper;
using Core.CQRS;
using Core.Models;
using Domain.Commands;
using Domain.Interfaces;
using Domain.Models;
using Services.DTOs;
using Services.Services.Interfaces;

namespace Services.Services
{
    public class Service<TEntity> : IService
        where TEntity : Customer
    {
        private readonly IRepository<TEntity> _repository;
        private readonly IBus _bus;
        private readonly IMapper _mapper;

        public Service(IRepository<TEntity> repository, IBus bus, IMapper mapper)
        {
            _repository = repository;
            _bus = bus;
            _mapper = mapper;
        }

        public void Delete(Guid id)
        {
            _bus.SendCommand(new RemoveCustomerCommand(id));
        }

        public CustomerDTO Get(Guid id)
        {
            var model = _repository.Find(id);

            if (model != null)
            {
                return _mapper.Map<CustomerDTO>(model);
            }
            return null;
        }

        public IEnumerable<CustomerDTO> GetAll()
        {
        IEnumerable<Customer> entityList = _repository.Get();
        List<CustomerDTO> entityDTOList = new List<CustomerDTO>();
        foreach (Customer entity in entityList)
        {
            entityDTOList.Add(_mapper.Map<CustomerDTO>(entity));
        }
        return entityDTOList;
        }

        public void Save(CreateCustomerDTO model)
        {
          if (model != null)
          {
            var customer = _mapper.Map<CreateCustomerCommand>(model);
            _bus.SendCommand(customer);
          }
        }
    
        public void Update(UpdateCustomerDTO model)
        {
          if (model != null)
          {
            var customer = _mapper.Map<UpdateCustomerCommand>(model);
            _bus.SendCommand(customer);
          }
        }
        }
}