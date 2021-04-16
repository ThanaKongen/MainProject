using Application.Command;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Serilog;
using DanBase.Shared.CustomerModels.Command;
using Infrastructure.Shared;

namespace Customer.Microservice.Controllers
{
    [Route("/BusinessCustomer")]
    public class BusinessCustomerCommandsController : Controller
    {
        private readonly BusinessCustomerApplicationService Application;
        private static readonly ILogger Log = Serilog.Log.ForContext<BusinessCustomerCommandsController>();

        public BusinessCustomerCommandsController(BusinessCustomerApplicationService application)
        {
            Application = application;
        }

        [HttpPost]
        public Task<IActionResult> PostCustomer(BusinessCustomerCommandDto.AddCustomer request)
           => RequestHandler.HandleCommand(request, Application.Handle, Log);


        [Route("Update")]
        [HttpPut]
        public Task<IActionResult> PutCustomer(BusinessCustomerCommandDto.UpdateCustomer request)

            => RequestHandler.HandleCommand(request, Application.Handle, Log);


        [Route("Delete")]
        [HttpDelete]
        public Task<IActionResult> DeleteCustomer(BusinessCustomerCommandDto.DeleteCustomer request)
            => RequestHandler.HandleCommand(request, Application.Handle, Log);
    }
}
