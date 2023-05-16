using CurrencyConverter.Models;
using Newtonsoft.Json;

namespace CurrencyConverter.Services
{
    public class CurrencyConverterService : ICurrencyConverterService
    {
        public ExchangeRates ExchangeRates { get; set; }
        private HttpClient _httpClient;

        public double ConvertCurrency(double fromCurrency, double toCurrency, double amount)
        {
            return (amount < 0) ? 0 : (toCurrency / fromCurrency) * amount;
        }

        public async Task GetExchangeRates()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"https://ec.europa.eu/budg/inforeuro/api/public/monthly-rates?year={DateTime.Now.Year}&month={DateTime.Now.Month}");
            _httpClient = new HttpClient();

            HttpResponseMessage response = await _httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();

                var definition = new[] { new CurrencyDetail { } };
                var results = JsonConvert.DeserializeAnonymousType(json, definition);

                ExchangeRates = new ExchangeRates
                {
                    CurrencyDetails = results
                };

                ExchangeRates.CurrencyDetails.ToList().ForEach(c => c.CreateDisplayName());
            }
        }
    }
}
