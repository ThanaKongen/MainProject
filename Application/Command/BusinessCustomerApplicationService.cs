using DanBase.Framework;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static DanBase.Shared.CustomerModels.Command.BusinessCustomerCommandDto;

namespace Application.Command
{
    public class BusinessCustomerApplicationService : IApplicationService
    {
        private readonly ICustomerRepository CustomerRepository;
        private readonly IUnitOfWork UnitOfWork;

        public BusinessCustomerApplicationService(ICustomerRepository customerRepository, IUnitOfWork unitOfWork)
        {
            CustomerRepository = customerRepository;
            UnitOfWork = unitOfWork;
        }

        public Task Handle(object Command)
        {
            return Command switch
            {
                AddCustomer cmd => HandleCreate(cmd),
                UpdateCustomer cmd => HandleUpdate(cmd.Id, c => c.BusinessCustomerUpdate(cmd.CompanyId, cmd.FirstName, cmd.LastName, cmd.CVR, cmd.EAN, cmd.WWW, cmd.VatCode, cmd.DebitorNo, cmd.Username, cmd.Password, cmd.Text, cmd.AccountNo, cmd.LastUpdate)),
                DeleteCustomer cmd => HandleDelete(cmd.Id),

                _ => Task.CompletedTask
            };
        }

        private async Task HandleCreate(AddCustomer cmd)
        {
            var Customer = new Domain.Models.BusinessCustomer(
                cmd.CompanyId,
                cmd.FirstName,
                cmd.LastName,
                cmd.CVR,
                cmd.EAN,
                cmd.WWW,
                cmd.VatCode,
                cmd.DebitorNo,
                cmd.Username,
                cmd.Password,
                cmd.Text,
                cmd.AccountNo,
                cmd.Created,
                cmd.LastUpdate
                );

            await CustomerRepository.AddBusinessCustomer(Customer);
            await UnitOfWork.Commit();
        }

        private async Task HandleUpdate(int Id, Action<BusinessCustomer> action)
        {
            var customer = await CustomerRepository.LoadBusinessCustomerAsync(Id);


            if (customer == null)
            {
                throw new InvalidOperationException($"Id with Id {Id} cannot be found");
            }

            action(customer);

            await UnitOfWork.Commit();
        }

        private async Task HandleDelete(int id)
        {
            var customer = await CustomerRepository.LoadBusinessCustomerAsync(id);

            if (customer == null)
            {
                throw new InvalidOperationException($"Customer with id {id} cannot be found");
            }

            await CustomerRepository.DeleteBusinessCustomer(id);

            await UnitOfWork.Commit();
        }
    }
}
