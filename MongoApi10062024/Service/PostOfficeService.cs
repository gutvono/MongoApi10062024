using Microsoft.AspNetCore.Mvc;
using MongoApi10062024.Models;
using Newtonsoft.Json;

namespace MongoApi10062024.Service
{
    public class PostOfficeService
    {
        static readonly HttpClient address = new HttpClient();

        public static async Task<AddressDTO> GetAddress(string cep)
        {
            try
            {
                HttpResponseMessage response = await address.GetAsync($"https://viacep.com.br/ws/{cep}/json/");
                response.EnsureSuccessStatusCode();
                return JsonConvert.DeserializeObject<AddressDTO>(await response.Content.ReadAsStringAsync());
            }
            catch (HttpRequestException e) { throw; }
        }
    }
}
