using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Serilog;
using Infrastructure.Query;

namespace Customer.Microservice.Controllers
{
    [Route("/BusinessCustomer")]
    public class BusinessCustomerQueryController : Controller
    {
        private static ILogger Log = Log.ForContext<BusinessCustomerQueryController>();
        private readonly BusinessCustomerQueries CustomerQueries;

        public BusinessCustomerQueryController(BusinessCustomerQueries customerQueries)
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
        public async Task<IActionResult> GetCustomerById(BusinessCustomerQueryModels.GetCustomerById request)
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
