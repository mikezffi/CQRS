using AutoMapper;
//using Domain.Commands;
using Domain.Models;
using Services.DTOs;

namespace Services.Mappings
{
  public class MappingProfile : Profile
  {
    public MappingProfile()
    {
      CreateMap<Customer, CustomerDTO>().ReverseMap();
      //CreateMap<CreateCustomerCommand, CreateCustomerDTO>().ReverseMap();
      //CreateMap<UpdateCustomerCommand, UpdateCustomerDTO>().ReverseMap();
      //CreateMap<Customer, CreateCustomerCommand>().ReverseMap();
      //CreateMap<Customer, UpdateCustomerCommand>().ReverseMap();
    }
  }
}