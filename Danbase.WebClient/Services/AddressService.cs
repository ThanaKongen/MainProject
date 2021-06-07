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
    public class AddressService : IAddressService
    {
        private HttpClient Client;
        private IConfiguration Configuration;
        private NavigationManager NavigationManager;

        IJSRuntime Js;

        public AddressService(HttpClient _client, IConfiguration _configuration, NavigationManager _navigationManager)
        {
            Client = _client;
            Configuration = _configuration;
            NavigationManager = _navigationManager;
        }

        public async Task Create(AddressCommandDto.AddAddress Address)
        {
            var Response = await Client.PostAsJsonAsync
                (
                $"Address?CustomerId={Address.CustomerId}&Street={Address.Street}&Zip={Address.Zip}&City={Address.City}&Country={Address.Country}", Address
                );

        }

        public async Task<List<Models.Address>> GetAll()
        {
            try
            {
                List<Models.Address> details = (await Client.GetFromJsonAsync<List<Models.Address>>
                    (
                        $"Address/GetAll"
                    )).ToList();

                return details;
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public async Task Update(Models.Address address)
        {
            var Response = await Client.PutAsJsonAsync
            (
                $"Address/Update?Id={address.Id}&CustomerId={address.CustomerId}&Street={address.Street}" +
                $"&Zip={address.Zip}&City={address.City}&Country={address.Country}", address
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
                        $"Address/Delete?Id={Id}"
                    );
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}
