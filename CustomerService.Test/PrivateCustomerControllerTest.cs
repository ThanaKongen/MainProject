using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Application.Command;
using Customer.Microservice.Controllers;
//using Danbase.WebClient.Models;
using Domain.Models;
using Danbase.WebClient.Services;
using Infrastructure;
using Infrastructure.Data;
using Infrastructure.Query;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;
using static Danbase.WebClient.Models.PrivateCustomer;
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;

namespace CustomerService.Test
{
    public class PrivateCustomerControllerTest
    {
        //    private Mock<ICustomerRepository> MockCustomer;

        //    [Fact]
        //    public void GetCustomerById()
        //    {
        //        var customer = new PrivateCustomer();
        //        MockCustomer = new Mock<ICustomerRepository>();
        //        MockCustomer.Setup(c => c.LoadPrivateCustomerAsync(It.IsAny<int>)).Returns(Task.FromResult(
        //            new PrivateCustomer
        //            {
        //                CompanyId = 1,
        //                FirstName = "Allan",
        //                LastName = "Thana",
        //                Username = "AllanThana",
        //                Password = "1234",
        //                AccountNo = "2345113",
        //                CPR = "329482938",
        //            }));
        //        var controller = new PrivateCustomerQueryController(MockCustomer.Object);
        //    }

        //    //private Mock<ICustomerRepository> MockCustomer;

        //    //[Fact]
        //    //public void GetAllPrivateCustomersTest()
        //    //{
        //    //    //Arrange

        //    //    var Customer = new PrivateCustomer();
        //    //    MockCustomer = new Mock<ICustomerRepository>();
        //    //    MockCustomer.Setup(c => c.LoadPrivateCustomerAsync(It.IsAny<int>)).Returns(Task.FromResult(new PrivateCustomer
        //    //    {
        //    //        CompanyId = 1,
        //    //        FirstName = "Allan",
        //    //        LastName = "Thana",
        //    //        Username = "AllanThana",
        //    //        Password = "1234",
        //    //        AccountNo = "2345113",
        //    //        CPR = "329482938",
        //    //    }));
        //    //}

        //    //PrivateCustomerCommandsController CommandController;
        //    //PrivateCustomerQueryController QueryController;
        //    //private readonly PrivateCustomerApplicationService ApplicationService;
        //    //private readonly PrivateCustomerQueries PrivateCustomerQueries;
        //    //IPrivateCustomerService CustomerService;

        //    //public PrivateCustomerControllerTest()
        //    //{
        //    //    CustomerService = new PrivateCustomerService();
        //    //    CommandController = new PrivateCustomerCommandsController(ApplicationService);
        //    //    QueryController = new PrivateCustomerQueryController(PrivateCustomerQueries);
        //    //}

        //    [Fact]
        //    public void GetAllTest()
        //    {
        //        //arrange
        //        var mockrepo = new Mock<IPrivateCustomerService>();
        //        //mockrepo.Setup(n => n.GetAll()).Returns((Task<List<PrivateCustomerDetails>>)MockDataCustomer.GetCustomers());
        //        mockrepo.Setup(n => n.GetAll()).Returns(MockDataCustomer.GetCustomers());
        //        var controller = new PrivateCustomerQueryController((PrivateCustomerQueries)mockrepo.Object);
        //        //act
        //        //var result = QueryController.GetAll();
        //        //assert

        //        //Assert.IsType<Task<IActionResult>>(result);

        //        //var list = Assert.IsType<OkObjectResult>(result.Result);
        //        //var n = Assert.IsType<List<PrivateCustomer>>(list.Value);
        //        Assert.Equal(16, n.Count);

        //        //Assert.IsType<Task<IActionResult<List<PrivateCustomer>>>>(list);

        //        //var listPrivateCustomers = list.Value as List<PrivateCustomer>;
        //        //Assert.Equal(15, listPrivateCustomers.Count);


        //    }


        //private CustomerRepository Repository;
        //public static DbContextOptions<CostomerDbContext> DbContextOptions { get; }
        //public static string ConnectionString = "Server=den1.mssql7.gear.host;Database=hovedopgave;User Id=hovedopgave;Password=Lg3sE?-EI62g;";

        //static PostUnitTestController()
        //{
        //    DbContextOptions = new DbContextOptionsBuilder<CostomerDbContext>()
        //        .UseSqlServer(ConnectionString)
        //        .Options;
        //}
        //public PostUnitTestController()
        //{
        //    var Context = new CostomerDbContext();
        //}
    }

    public static class MockDataCustomer
    {
        public static async Task<List<PrivateCustomerDetails>> GetCustomers()
        {
            var Customers = new List<PrivateCustomerDetails>
            {
                new PrivateCustomerDetails
                {
                    companyId = 1,
                    firstName = "Allan",
                    lastName = "Thana",
                    username ="AllanThana",
                    password="1234",
                    accountNo="2345113",
                    cpr ="329482938",

                },
                new PrivateCustomerDetails
                {
                    companyId = 1,
                    firstName = "Timba",
                    lastName = "THK",
                    username ="TTTHK",
                    password="1234",
                    accountNo="2345113",
                    cpr ="329482938",

                },
                new PrivateCustomerDetails
                {
                    companyId = 1,
                    firstName = "ROZ",
                    lastName = "jdks",
                    username ="ROZT",
                    password="1234",
                    accountNo="2345113",
                    cpr ="329482938",

                }
            };
            return await Task.FromResult(Customers);
        }
    }
}
