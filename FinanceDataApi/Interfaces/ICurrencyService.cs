
using FinanceDataApi.Models;
namespace FinanceDataApi.Interfaces


{
    public interface ICurrencyService
    {
        Task<CurrencyRate> GetExchangeRateAsync(string pair);
    }
}
