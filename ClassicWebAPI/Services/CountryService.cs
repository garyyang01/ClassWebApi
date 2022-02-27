using ClassicWebAPI.Models;
using ClassicWebAPI.Services.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClassicWebAPI.Services
{
    public class CountryService : ICountryService
    {
        private readonly IHttpClientService _httpClientService;

        public CountryService(IHttpClientService httpClientService)
        {
            _httpClientService = httpClientService;
        }

        public async Task<IEnumerable<CountryInfo>> GetAll()
        {
            var httpResponseMessage = await _httpClientService.GetAsync("https://restcountries.com/v3.1/all");
            if (!httpResponseMessage.IsSuccessStatusCode) return null;
            var data = await httpResponseMessage.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<IEnumerable<CountryInfo>>(data);
        }
    }
}