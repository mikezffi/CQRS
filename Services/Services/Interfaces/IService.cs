using Domain.Models;
using Services.DTOs;
using System;
using System.Collections.Generic;

namespace Services.Services.Interfaces
{
    public interface IService
    {
        void Save(CreateCustomerDTO model);
        void Update(UpdateCustomerDTO model);
        void Delete(Guid id);
        CustomerDTO Get(Guid id);
        IEnumerable<CustomerDTO> GetAll();
    }
}