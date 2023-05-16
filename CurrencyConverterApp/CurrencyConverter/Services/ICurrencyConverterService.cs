using CurrencyConverter.Models;

namespace CurrencyConverter.Services
{
    public interface ICurrencyConverterService
    {
        ExchangeRates ExchangeRates { get; set; }

        Task GetExchangeRates();

        double ConvertCurrency(double fromCurrency, double toCurrency, double amount);
    }
}
