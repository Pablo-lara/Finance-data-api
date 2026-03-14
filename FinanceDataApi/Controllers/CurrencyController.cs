using FinanceDataApi.DTOs;
using FinanceDataApi.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FinanceDataApi.Controllers 
{
    [ApiController]
    [Route("api/[controller]")]

    public class CurrencyController : ControllerBase
    {
        private readonly ICurrencyService _currencyService;

        public CurrencyController(ICurrencyService currencyService)
        {
            _currencyService = currencyService;
        }

        [HttpGet("{pair}")]

        public async Task<ActionResult<CurrencyRateDto>> Get(string pair)
        {
            var result = await _currencyService.GetExchangeRateAsync(pair);

            var dto = new CurrencyRateDto
            {
                From = result.From,
                To = result.To,
                Rate = result.Rate,
                Timestamp = result.Timestamp
            };

            return Ok(dto);
        }
    }
}
