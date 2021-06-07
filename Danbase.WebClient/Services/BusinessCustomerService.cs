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
    public class BusinessCustomerService : IBusinessCustomerService
    {
        private HttpClient Client;
        private IConfiguration Configuration;
        private NavigationManager NavigationManager;

        IJSRuntime Js;

        public BusinessCustomerService(HttpClient _client, IConfiguration _configuration, NavigationManager _navigationManager)
        {
            Client = _client;
            Configuration = _configuration;
            NavigationManager = _navigationManager;
        }


        public async Task Create(BusinessCustomerCommandDto.AddCustomer CustomerDto)
        {
            var Response = await Client.PostAsJsonAsync
                (
                $"BusinessCustomer?CompanyId={CustomerDto.CompanyId}&FirstName={CustomerDto.FirstName}&LastName={CustomerDto.LastName}" +
                $"&CVR={CustomerDto.CVR}&EAN={CustomerDto.EAN}&WWW={CustomerDto.WWW}&VatCode={CustomerDto.VatCode}" +
                $"&DebitorNo={CustomerDto.DebitorNo}&Username={CustomerDto.Username}&Password={CustomerDto.Password}" +
                $"&Text={CustomerDto.Text}&AccountNo={CustomerDto.AccountNo}", CustomerDto
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
        public async Task<List<Models.BusinessCustomer.BusinessCustomerDetails>> GetAll()
        {
            try
            {
                List<Models.BusinessCustomer.BusinessCustomerDetails> details = (await Client.GetFromJsonAsync<List<Models.BusinessCustomer.BusinessCustomerDetails>>
                    (
                        $"BusinessCustomer/GetAll"
                    )).ToList();

                return details;
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public async Task<Models.BusinessCustomer.BusinessCustomerDetails> GetById(int Id)
        {
            try
            {
                var Response = await Client.GetFromJsonAsync<Models.BusinessCustomer.BusinessCustomerDetails>
                    (
                        $"BusinessCustomer/Id?Id={Id}"
                    );

                return Response;
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public async Task Update(Models.BusinessCustomer.BusinessCustomerDetails CustomerDto)
        {
            var Response = await Client.PutAsJsonAsync
                (
                $"BusinessCustomer/Update?Id={CustomerDto.Id}&CompanyId={CustomerDto.CompanyId}&FirstName={CustomerDto.FirstName}" +
                $"&LastName={CustomerDto.LastName}&CVR={CustomerDto.CVR}&EAN={CustomerDto.EAN}&WWW={CustomerDto.WWW}" +
                $"&VatCode={CustomerDto.Vatcode}&DebitorNo={CustomerDto.DebitorNo}&Username={CustomerDto.Username}" +
                $"&Password={CustomerDto.Password}&Text={CustomerDto.Text}&AccountNo={CustomerDto.AccountNo}", CustomerDto
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

        public async Task Delete(int Id)
        {
            try
            {
                var Response = await Client.DeleteAsync
                    (
                        $"BusinessCustomer/Delete?Id={Id}"
                    );
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}
