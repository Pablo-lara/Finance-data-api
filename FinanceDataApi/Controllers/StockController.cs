using FinanceDataApi.DTOs;
using FinanceDataApi.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FinanceDataApi.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class StockController : ControllerBase
    {
        private readonly IStockService _stockService;

        public  StockController(IStockService stockService)
        {
            _stockService = stockService;
        }

        [HttpGet("Symbol")]
        public async Task<ActionResult<StockQuoteDto>> Get(string symbol)
        {
            var result = await _stockService.GetStockAsync(symbol);

            var dto = new StockQuoteDto
            {
                Symbol = result.Symbol,
                CurrentPrice = result.CurrentPrice,
                High = result.High,
                Low = result.Low,
                Open = result.Open,
                PreviousClose = result.PreviousClose
            };

            return Ok(dto);
        }

    }
}
