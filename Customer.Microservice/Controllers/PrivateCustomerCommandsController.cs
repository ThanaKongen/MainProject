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
    [Route ("/PrivateCustomer")]
    public class PrivateCustomerCommandsController : Controller
    {
        private readonly PrivateCustomerApplicationService Application;
        private static readonly ILogger Log = Serilog.Log.ForContext<PrivateCustomerCommandsController>();

        public PrivateCustomerCommandsController(PrivateCustomerApplicationService _Application)
        {
            Application = _Application;
        }

        [HttpPost]
        public Task<IActionResult> PostCustomer(PrivateCustomerCommandDto.AddCustomer request)
            => RequestHandler.HandleCommand(request, Application.Handle, Log);


        [Route("Update")]
        [HttpPut]
        public Task<IActionResult> PutCustomer(PrivateCustomerCommandDto.UpdateCustomer request)
        
            => RequestHandler.HandleCommand(request, Application.Handle, Log);
        

        [Route("Delete")]
        [HttpDelete]
        public Task<IActionResult> DeleteCustomer(PrivateCustomerCommandDto.DeleteCustomer request)
            => RequestHandler.HandleCommand(request, Application.Handle, Log);
    }
}
