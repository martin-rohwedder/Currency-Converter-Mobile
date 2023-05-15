using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter.Services
{
    public class CurrencyConverterService : ICurrencyConverterService
    {
        public double ConvertCurrency(double fromCurrency, double toCurrency, double amount)
        {
            return (amount < 0) ? 0 : (toCurrency / fromCurrency) * amount;
        }
    }
}
