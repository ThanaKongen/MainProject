using DanBase.Framework;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static DanBase.Shared.CustomerModels.Command.AddressCommandDto;

namespace Application.Command
{
    public class AddressApplicationService : IApplicationService
    {
        private readonly ICustomerRepository CustomerRepository;
        private readonly IUnitOfWork UnitOfWork;

        public AddressApplicationService(ICustomerRepository customerRepository, IUnitOfWork unitOfWork)
        {
            CustomerRepository = customerRepository;
            UnitOfWork = unitOfWork;
        }

        public Task Handle(object Command)
        {
            return Command switch
            {
                AddAddress cmd => HandleCreate(cmd),
                UpdateAddress cmd => HandleUpdate(cmd.Id, c=>c.AddressUpdate(cmd.CustomerId, cmd.Street, cmd.Zip, cmd.City, cmd.Country)),
                DeleteAddress cmd => HandleDelete(cmd.Id),

                _ => Task.CompletedTask
            };
        }

        private async Task HandleCreate(AddAddress cmd)
        {
            var Address = new Address(
                cmd.CustomerId,
                cmd.Street,
                cmd.Zip,
                cmd.City,
                cmd.Country
                );

            await CustomerRepository.AddAddress(Address);
            await UnitOfWork.Commit();
        }

        private async Task HandleUpdate(int Id, Action<Address> action)
        {
            var Address = await CustomerRepository.LoadAddressAsync(Id);


            if (Address == null)
            {
                throw new InvalidOperationException($"Id with Id {Id} cannot be found");
            }

            action(Address);

            await UnitOfWork.Commit();
        }

        private async Task HandleDelete(int id)
        {
            var Address = await CustomerRepository.LoadAddressAsync(id);

            if (Address == null)
            {
                throw new InvalidOperationException($"Customer with id {id} cannot be found");
            }

            await CustomerRepository.DeleteAddress(id);

            await UnitOfWork.Commit();
        }
    }
}
