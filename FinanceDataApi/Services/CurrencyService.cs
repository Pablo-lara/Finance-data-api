using FinanceDataApi.Interfaces;
using System.Text.Json;
using FinanceDataApi.Models;
using System.Globalization;
namespace FinanceDataApi.Services
{
    public class CurrencyService : ICurrencyService
    {
        private readonly HttpClient _httpClient;

        public CurrencyService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<CurrencyRate> GetExchangeRateAsync(string pair)
        {
            var url = $"https://economia.awesomeapi.com.br/json/last/{pair}";

            var response = await _httpClient.GetAsync(url);

            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();

            var document = JsonDocument.Parse(json);

            var propertyName = pair.Replace("-", "");

            var data = document.RootElement.GetProperty(propertyName);

            return new CurrencyRate
            {
                From = data.GetProperty("code").GetString(),
                To = data.GetProperty("codein").GetString(),
                Rate = decimal.Parse(data.GetProperty("bid").GetString(), CultureInfo.InvariantCulture),
                Timestamp = DateTimeOffset.FromUnixTimeSeconds(long.Parse(data.GetProperty("timestamp").GetString())).DateTime
            };
        }
    }
}
