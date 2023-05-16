using CurrencyConverter.Models;
using CurrencyConverter.Services;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CurrencyConverter.ViewModels
{
    public class CurrencyConverterViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private readonly ICurrencyConverterService _currencyConverterService;
		private double _amount;
        private IList<CurrencyDetail> _currencies;
        private CurrencyDetail _selectedFromCurrency;
        private CurrencyDetail _selectedToCurrency;
		private double _convertedCurrency;
        private bool _dataIsLoaded = false;

		public CurrencyConverterViewModel(ICurrencyConverterService currencyConverterService)
		{
            _currencyConverterService = currencyConverterService;
        }

        public async Task LoadDataAsync()
        {
            await _currencyConverterService.GetExchangeRates();

            Currencies = _currencyConverterService.ExchangeRates.CurrencyDetails.OrderBy(c => c.Currency).ToList();

            SelectedFromCurrency = Currencies.FirstOrDefault(c => c.IsoA3Code.Equals("EUR"));
            SelectedToCurrency = Currencies.FirstOrDefault(c => c.IsoA3Code.Equals("DKK"));

            _dataIsLoaded = true;

            Amount = 1;
        }

		public double Amount
		{
			get { return _amount; }
			set
			{
				_amount = value;
                ConvertedCurrency = ConvertCurrencyWhenDataIsLoaded();
                OnPropertyChanged(nameof(Amount));
			}
		}

		public IList<CurrencyDetail> Currencies
		{
			get { return _currencies; }
			set
            {
                _currencies = value;
                OnPropertyChanged(nameof(Currencies));
            }
		}

		public CurrencyDetail SelectedFromCurrency
		{
			get { return _selectedFromCurrency; }
			set
			{
				_selectedFromCurrency = value;
                ConvertedCurrency = ConvertCurrencyWhenDataIsLoaded();
                OnPropertyChanged(nameof(SelectedFromCurrency));
			}
		}

		public CurrencyDetail SelectedToCurrency
		{
			get { return _selectedToCurrency; }
			set
			{
				_selectedToCurrency = value;
                ConvertedCurrency = ConvertCurrencyWhenDataIsLoaded();
                OnPropertyChanged(nameof(SelectedToCurrency));
			}
		}

        public double ConvertedCurrency
        {
            get { return _convertedCurrency; }
            set
            {
                _convertedCurrency = value;
                OnPropertyChanged(nameof(ConvertedCurrency));
            }
        }

        public void OnPropertyChanged([CallerMemberName] string name = "") =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        private double ConvertCurrencyWhenDataIsLoaded()
        {
            return (_dataIsLoaded) ? _currencyConverterService.ConvertCurrency(SelectedFromCurrency.Value, SelectedToCurrency.Value, _amount) : 1;
        }
    }
}
