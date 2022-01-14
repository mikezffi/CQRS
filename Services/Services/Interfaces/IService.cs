using Domain.Models;
using Services.DTOs;
using System;
using System.Collections.Generic;

namespace Services.Services.Interfaces
{
    public interface IService
    {
        void Save(CustomerDTO model);
        void Update(CustomerDTO model);
        void Delete(Guid id);
        CustomerDTO Get(Guid id);
        IEnumerable<CustomerDTO> GetAll();
    }
}