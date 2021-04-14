using Infrastructure.Query;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Serilog;

namespace Customer.Microservice.Controllers
{
    [Route("/Customer")]
    public class CustomerQueryController : Controller
    {
        private static ILogger Log = Log.ForContext<CustomerQueryController>();
        private readonly CustomerQueries CustomerQueries;

        public CustomerQueryController(CustomerQueries customerQueries)
        {
            CustomerQueries = customerQueries;
        }
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

                throw;
            }
        }

        [HttpGet]
        [Route("Id")]
        public async Task<IActionResult> GetCustomerById(CustomerQueryModels.GetCustomerById request)
        {
            try
            {
                var model = await CustomerQueries.GetCustomerById(request);
                return new OkObjectResult(model);
            }
            catch (Exception e)
            {

                throw;
            }
        }
    }
}
