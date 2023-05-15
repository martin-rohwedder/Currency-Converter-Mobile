using CurrencyConverter.Services;

namespace UnitTest
{
    public class CurrencyConverterServiceTest
    {
        private readonly ICurrencyConverterService _currencyConverterService = new CurrencyConverterService();

        [Fact]
        public void ConvertCurrency_AmountIsNegative_ReturnAmountAsZero()
        {
            double convertedCurrency = _currencyConverterService.ConvertCurrency(1, 7.45, -1);
            
            Assert.Equal(0, convertedCurrency);
        }
    }
}
