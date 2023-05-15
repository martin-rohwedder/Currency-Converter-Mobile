using CurrencyConverter.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter.ViewModels
{
    public class CurrencyConverterViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private readonly ICurrencyConverterService _currencyConverterService;
		private double _amount;
        private IList<Currency> _currencies;
        private Currency _selectedFromCurrency;
        private Currency _selectedToCurrency;
		private double _convertedCurrency;

		public CurrencyConverterViewModel(ICurrencyConverterService currencyConverterService)
		{
            _currencyConverterService = currencyConverterService;

            Currencies = new List<Currency>
            {
                new Currency()
                {
                    Name = "EUR",
                    Price = 1
                },
                new Currency()
                {
                    Name = "DKK",
                    Price = 7.45
                },
                new Currency()
                {
                    Name = "SEK",
                    Price = 5.5
                },
                new Currency()
                {
                    Name = "NOK",
                    Price = 7.30
                },
                new Currency()
                {
                    Name = "USD",
                    Price = 1.2
                },
            };

			SelectedFromCurrency = Currencies.FirstOrDefault();
			SelectedToCurrency = Currencies[1];

            Amount = 1;
        }

		public double Amount
		{
			get { return _amount; }
			set
			{
				_amount = value;
                ConvertedCurrency = _currencyConverterService.ConvertCurrency(SelectedFromCurrency.Price, SelectedToCurrency.Price, _amount);
                OnPropertyChanged(nameof(Amount));
			}
		}

		public IList<Currency> Currencies
		{
			get { return _currencies; }
			set { _currencies = value; }
		}

		public Currency SelectedFromCurrency
		{
			get { return _selectedFromCurrency; }
			set
			{
				_selectedFromCurrency = value;
				OnPropertyChanged(nameof(SelectedFromCurrency));
			}
		}

		public Currency SelectedToCurrency
		{
			get { return _selectedToCurrency; }
			set
			{
				_selectedToCurrency = value;
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
    }

	public class Currency
	{
        public string Name { get; set; }
        public double Price { get; set; }
    }
}
