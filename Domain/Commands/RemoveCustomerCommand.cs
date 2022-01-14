using System;
using Core.CQRS;

namespace Domain.Commands
{
    public class RemoveCustomerCommand : Command
    {
        public Guid Id { get; set; }
        public RemoveCustomerCommand(Guid id)
        {
            Id = id;
        }
    }
}