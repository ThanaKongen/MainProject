using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using DanBase.Shared.CustomerModels.Command;
using DanBase.Shared.CustomerModels.Query;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;
using Microsoft.JSInterop;

namespace Danbase.WebClient.Services
{
    public class PrivateCustomerService : IPrivateCustomerService
    {
        private HttpClient Client;
        private IConfiguration Configuration;
        private NavigationManager NavigationManager;

        IJSRuntime Js;

        public PrivateCustomerService(HttpClient _client, IConfiguration _configuration, NavigationManager _navigationManager)
        {
            Client = _client;
            Configuration = _configuration;
            NavigationManager = _navigationManager;
        }


        public async Task Create(PrivateCustomerCommandDto.AddCustomer CustomerDto)
        {
            var Response = await Client.PostAsJsonAsync
                (
                $"PrivateCustomer/Create?CompanyId={CustomerDto.CompanyId}&FirstName={CustomerDto.FirstName}&LastName={CustomerDto.LastName}" +
                $"&CPR={CustomerDto.CPR}&Username={CustomerDto.Username}&Password={CustomerDto.Password}&Text={CustomerDto.Text}" +
                $"&AccountNo={CustomerDto.AccountNo}",CustomerDto
                );

            if (Response.IsSuccessStatusCode)
            {

                await Js.InvokeVoidAsync("alert", $"Kunden er nu oprettet!");
            }
            else
            {
                await Js.InvokeVoidAsync("alert", $"Noget gik galt! Prøv igen.");
            }

        }
        public async Task<List<Models.PrivateCustomer.PrivateCustomerDetails>> GetAll()
        {
            try
            {
                List<Models.PrivateCustomer.PrivateCustomerDetails> details = (await Client.GetFromJsonAsync<List<Models.PrivateCustomer.PrivateCustomerDetails>>
                    (
                        $"PrivateCustomer/GetAll"
                    )).ToList();

                return details;
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public async Task<Models.PrivateCustomer.PrivateCustomerDetails> GetById(int Id)
        {
            try
            {
            var Respone = await Client.GetFromJsonAsync<Models.PrivateCustomer.PrivateCustomerDetails>
                (
                    $"PrivateCustomer/Id?Id={Id}"
                );

            return Respone;
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public async Task Update(Models.PrivateCustomer.PrivateCustomerDetails CustomerDto)
        {
            var Response = await Client.PutAsJsonAsync
                (
                $"PrivateCustomer/Update?Id={CustomerDto.id}&CompanyId={CustomerDto.companyId}&FirstName={CustomerDto.firstName}" +
                $"&LastName={CustomerDto.lastName}&Username={CustomerDto.username}&Password={CustomerDto.password}" +
                $"&Text={CustomerDto.text}&AccountNo={CustomerDto.accountNo}",CustomerDto
                );

            if (Response.IsSuccessStatusCode)
            {

                await Js.InvokeVoidAsync("alert", $"Kunden er nu opdateret!");
            }
            else
            {
                await Js.InvokeVoidAsync("alert", $"Noget gik galt! Prøv igen.");
            }
        }
    }
}
