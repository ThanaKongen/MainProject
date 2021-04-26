using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Serilog;
using Infrastructure.Query;

namespace Customer.Microservice.Controllers
{
    [Route("/Address")]
    public class AddressQueryController : Controller
    {
        private static ILogger Log = Log.ForContext<AddressQueryController>();
        private readonly AddressQueries Queries;

        public AddressQueryController(AddressQueries queries)
        {
            Queries = queries;
        }

        [Route("GetAll")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var model = await Queries.GetAllAddress();
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
        public async Task<IActionResult> GetAddressById(AddressQueryModels.GetAddressById request)
        {
            try
            {
                var model = await Queries.GetAddressById(request);
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
