using AutoMapper;
using Core.Models;
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
        private readonly IMapper _mapper;

        public Service(IRepository<TEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public void Delete(Guid id)
        {
            var model = _repository.Find(id);
            if (model != null)
            {
                model.Delete = true;
                _repository.Update(model);
            }
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

        public void Save(CustomerDTO model)
        {
            if (model != null)
            {
                _repository.Add(_mapper.Map<TEntity>(model));
            }
        }

        public void Update(CustomerDTO model)
        {
            if (model != null)
            {
                _repository.Update(_mapper.Map<TEntity>(model));
            }
        }
    }
}