using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter.Services
{
    public interface ICurrencyConverterService
    {
        double ConvertCurrency(double fromCurrency, double toCurrency, double amount);
    }
}
