using Infrastructure.Query;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Serilog;

namespace Customer.Microservice.Controllers
{
    [Route("/PrivateCustomer")]
    public class PrivateCustomerQueryController : Controller
    {
        private static ILogger Log = Log.ForContext<PrivateCustomerQueryController>();
        private readonly PrivateCustomerQueries CustomerQueries;

        public PrivateCustomerQueryController(PrivateCustomerQueries customerQueries)
        {
            CustomerQueries = customerQueries;
        }

        [Route("GetAll")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var model = await CustomerQueries.GetAllCustomers();
                return new OkObjectResult(model);
            }
            catch (Exception e)
            {
                e.Message.ToString();
                throw;
            }
        }

        [HttpGet]
        [Route("Id")]
        public async Task<IActionResult> GetCustomerById(PrivateCustomerQueryModels.GetCustomerById request)
        {
            try
            {
                var model = await CustomerQueries.GetCustomerById(request);
                return new OkObjectResult(model);
            }
            catch (Exception e)
            {
                e.Message.ToString();
                throw;
            }
        }
    }
}
