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
                cmd.AccountNo
                );

            await CustomerRepository.AddPrivateCustomerAsync(Customer);
            await UnitOfWork.Commit();
        }
    }
}
