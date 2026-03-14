namespace FinanceDataApi.DTOs
{
    public class CurrencyRateDto
    {
        public string From { get; set; }

        public string To { get; set; }

        //public decimal Price { get; set; }

        public decimal Rate { get; set; }

        public DateTime Timestamp { get; set; }
    }
}
