using FinanceDataApi.Interfaces;
using FinanceDataApi.Models;
using System.Text.Json;
using Microsoft.Extensions.Configuration;

namespace FinanceDataApi.Services
{
    public class StockService : IStockService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;

        public StockService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _apiKey = configuration["Finnhub:ApiKey"];
        }

        public async Task<StockQuote> GetStockAsync(string symbol)
        {
            var url = $"https://finnhub.io/api/v1/quote?symbol={symbol}&token={_apiKey}";

            var response = await _httpClient.GetAsync(url);

            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();

            var data = JsonDocument.Parse(json).RootElement;

            return new StockQuote
            {
                Symbol = symbol,
                CurrentPrice = data.GetProperty("c").GetDecimal(),
                High = data.GetProperty("h").GetDecimal(),
                Low = data.GetProperty("l").GetDecimal(),
                Open = data.GetProperty("o").GetDecimal(),
                PreviousClose = data.GetProperty("pc").GetDecimal()
            };
        }
    }
}
