using FinanceDataApi.Models;

namespace FinanceDataApi.Interfaces
{
    public interface IStockService
    {
        Task<StockQuote> GetStockAsync(string symbol);
    }
}
