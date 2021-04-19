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
    [Route("/Address")]
    public class AddressCommandsController : Controller
    {
        private readonly AddressApplicationService Application;
        private static readonly ILogger Log = Serilog.Log.ForContext<AddressCommandsController>();

        public AddressCommandsController(AddressApplicationService application)
        {
            Application = application;
        }

        [HttpPost]
        public Task<IActionResult> PostAddress(AddressCommandDto.AddAddress request)
           => RequestHandler.HandleCommand(request, Application.Handle, Log);


        [Route("Update")]
        [HttpPut]
        public Task<IActionResult> PutAddress(AddressCommandDto.UpdateAddress request)

            => RequestHandler.HandleCommand(request, Application.Handle, Log);


        [Route("Delete")]
        [HttpDelete]
        public Task<IActionResult> DeleteAddress(AddressCommandDto.DeleteAddress request)
            => RequestHandler.HandleCommand(request, Application.Handle, Log);
    }
}
