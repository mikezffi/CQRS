using System;
using Core.CQRS;

namespace Domain.Commands
{
    public class UpdateCustomerCommand : Command
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public UpdateCustomerCommand(Guid id, string name, string email)
        {
            Id = id;
            Name = name;
            Email = email;
        }
    }
}