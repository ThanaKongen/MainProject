using DanBase.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static DanBase.Shared.CustomerModels.Command.CustomerCommandDto;

namespace Application.Command
{
    public class CustomerApplicationService : IApplicationService
    {
        private readonly ICustomerRepository CustomerRepository;
        private readonly IUnitOfWork UnitOfWork;

        public CustomerApplicationService(ICustomerRepository customerRepository,  IUnitOfWork unitOfWork)
        {
            CustomerRepository = customerRepository;
            UnitOfWork = unitOfWork;
        }

        public Task Handle(object Command)
        {
            return Command switch
            {
                AddCustomer cmd => HandleCreate(cmd),
                UpdateCustomer cmd => HandleUpdate(cmd.Id, c => c.PrivateCustomerUpdate(cmd.CompanyId, cmd.FirstName, cmd.LastName, cmd.Username, cmd.Password, cmd.Text, cmd.AccountNo,cmd.LastUpdate)),
                DeleteCustomer cmd => HandleDelete(cmd.Id),

                _ => Task.CompletedTask
            };
        }
        private async Task HandleCreate(AddCustomer cmd)
        {
            //if (await CustomerRepository.CustomerExistsAsync(cmd.Id))
            //    throw new InvalidOperationException($"Entity with id {cmd.Id} already exists");

            var Customer = new Domain.Models.PrivateCustomer(
                cmd.CompanyId,
                cmd.FirstName,
                cmd.LastName,
                cmd.CPR,
                cmd.Username,
                cmd.Password,
                cmd.Text,
                cmd.AccountNo,
                cmd.Created,
                cmd.LastUpdate
                );

            await CustomerRepository.AddPrivateCustomerAsync(Customer);
            await UnitOfWork.Commit();
        }

        private async Task HandleUpdate(int Id, Action<Domain.Models.PrivateCustomer> action)
        {
            var customer = await CustomerRepository.LoadPrivateCustomerAsync(Id);
            

            if (customer == null)
            {
                throw new InvalidOperationException($"Id with Id {Id} cannot be found");
            }

            action(customer);

            await UnitOfWork.Commit();
        }

        private async Task HandleDelete(int id)
        {
            var customer = await CustomerRepository.LoadPrivateCustomerAsync(id);

            if (customer == null)
            {
                throw new InvalidOperationException($"Customer with id {id} cannot be found");
            }

            await CustomerRepository.DeletePrivateCustomer(id);

            await UnitOfWork.Commit();
        }
    }
}
