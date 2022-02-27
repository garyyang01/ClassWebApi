using ClassicWebAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ClassicWebAPI.Controllers
{
    public class CountryController : ControllerBase
    {
        private readonly ICountryService _countryService;

        public CountryController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        [HttpGet]
        public IActionResult Welcome()
        {
            return Ok("Welcome to ClassicWebAPI.");
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            return new JsonResult(await _countryService.GetAll());
        }
    }
}